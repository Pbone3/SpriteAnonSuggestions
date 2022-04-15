using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;

namespace SpriteAnonSuggestions.Utils
{
    public static class TileUtils
    {
        // Modified Collision.HitTiles
        public static void PaintTiles(Vector2 Position, Vector2 Velocity, int Width, int Height, int PaintType)
        {
            Vector2 vector = Position + Velocity;
            int minI = (int)(Position.X / 16f) - 1;
            int maxI = (int)((Position.X + Width) / 16f) + 2;
            int minJ = (int)(Position.Y / 16f) - 1;
            int maxJ = (int)((Position.Y + Height) / 16f) + 2;

            minI = (int)MathHelper.Max(minI, 0);
            maxI = (int)MathHelper.Min(maxI, Main.maxTilesX);

            minJ = (int)MathHelper.Max(minJ, 0);
            maxJ = (int)MathHelper.Min(maxJ, Main.maxTilesY);

            Vector2 vector2 = default;
            for (int i = minI; i < maxI; i++)
            {
                for (int j = minJ; j < maxJ; j++)
                {
                    Tile tile = Main.tile[i, j];

                    if (!tile.IsActuated && tile.HasTile &&
                        (Main.tileSolid[tile.TileType] || (Main.tileSolidTop[tile.TileType] && tile.TileFrameY == 0)))
                    {
                        vector2.X = i * 16;
                        vector2.Y = j * 16;
                        int num5 = 16;
                        if (Main.tile[i, j].IsHalfBlock)
                        {
                            vector2.Y += 8f;
                            num5 -= 8;
                        }
                        if (vector.X + Width >= vector2.X && vector.X <= vector2.X + 16f && vector.Y + Height >= vector2.Y && vector.Y <= vector2.Y + num5)
                            WorldGen.paintTile(i, j, (byte)PaintType);
                    }
                }
            }
        }

        // Modified Projectile.ExplodeTiles
        public static void PaintExplosion(Vector2 compareSpot, int paintType, int radius, int minI, int maxI, int minJ, int maxJ, bool paintWalls)
        {
            for (int i = minI; i <= maxI; i++)
            {
                for (int j = minJ; j <= maxJ; j++)
                {
                    Tile tile = Main.tile[i, j];

                    float distanceI = Math.Abs(i - compareSpot.X / 16f);
                    float distanceJ = Math.Abs(j - compareSpot.Y / 16f);

                    if (!(Math.Sqrt(distanceI * distanceI + distanceJ * distanceJ) < radius))
                        continue;

                    if (tile.HasTile)
                    {
                        WorldGen.paintTile(i, j, (byte)paintType);
                        
                        if (Main.netMode != NetmodeID.SinglePlayer)
                            NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 0, i, j);
                    }

                    for (int k = i - 1; k <= i + 1; k++)
                    {
                        for (int l = j - 1; l <= j + 1; l++)
                        {
                            if (tile.WallType > 0 && paintWalls)
                            {
                                WorldGen.paintWall(k, l, (byte)paintType);
                                
                                if (Main.netMode != NetmodeID.SinglePlayer)
                                    NetMessage.SendData(MessageID.TileManipulation, -1, -1, null, 2, k, l);
                            }
                        }
                    }
                }
            }
        }
    }
}
