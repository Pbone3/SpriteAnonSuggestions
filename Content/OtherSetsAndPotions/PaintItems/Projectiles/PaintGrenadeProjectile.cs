using Microsoft.Xna.Framework;
using SpriteAnonSuggestions.Utils;
using SpriteAnonSuggestions.Utils.DynamicItemDrawing;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.OtherSetsAndPotions.PaintItems.Projectiles
{
    public sealed class PaintGrenadeProjectile : ModProjectile
    {
        public sealed override string Texture => $"Terraria/Images/Projectile_{ProjectileID.Grenade}";

        public List<ItemTexturePiece> ItemTexturePieces;

        public sealed override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 180;
            
            DrawOriginOffsetY = -3;
        }

        public int FallDelay
        {
            get => (int)Projectile.ai[0];
            set => Projectile.ai[0] = value;
        }

        public int PaintType
        {
            get => (int)Projectile.ai[1];
            set => Projectile.ai[1] = value;
        }
        
        public sealed override void AI()
        {
            if (Projectile.owner == Main.myPlayer && Projectile.timeLeft <= 3)
            {
                // Boom
                SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);
                
                // Turn it into a big invisible hitbox
                Projectile.tileCollide = false;
                Projectile.alpha = 255;

                // Make it bigger
                Projectile.Resize(128, 128);
                Projectile.knockBack = 8f;

                const int radius = 4;

                Vector2 compareSpot = Projectile.Center;
                int minI = (int)(compareSpot.X / 16f - radius);
                int maxI = (int)(compareSpot.X / 16f + radius);
                int minJ = (int)(compareSpot.Y / 16f - radius);
                int maxJ = (int)(compareSpot.Y / 16f + radius);
                if (minI < 0)
                {
                    minI = 0;
                }
                if (maxI > Main.maxTilesX)
                {
                    maxI = Main.maxTilesX;
                }
                if (minJ < 0)
                {
                    minJ = 0;
                }
                if (maxJ > Main.maxTilesY)
                {
                    maxJ = Main.maxTilesY;
                }
                
                TileUtils.PaintExplosion(compareSpot, PaintType, radius, minI, maxI, minJ, maxJ, true);
            }

            if (++FallDelay > 10)
            {
                FallDelay = 10;

                if (Projectile.velocity.Y == 0f && Projectile.velocity.X != 0f)
                {
                    Projectile.velocity.X *= 0.97f;

                    if (Projectile.velocity.X > -0.01 && Projectile.velocity.X < 0.01)
                    {
                        Projectile.velocity.X = 0f;
                        Projectile.netUpdate = true;
                    }
                }

                Projectile.velocity.Y += 0.2f;
            }

            Projectile.rotation += Projectile.velocity.X * 0.1f;
        }
        
        public sealed override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X)
                Projectile.velocity.X = oldVelocity.X * -0.4f;
            
            if (Projectile.velocity.Y != oldVelocity.Y && oldVelocity.Y > 0.7)
                Projectile.velocity.Y = oldVelocity.Y * -0.4f;

            return false;
        }

        public sealed override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Projectile.timeLeft > 3)
                Projectile.timeLeft = 3;
            
            target.color = WorldGen.paintColor(PaintType).MultiplyRGB(0.05f);
        }

        public sealed override bool PreDraw(ref Color lightColor)
        {
            Item dummyItem = new();
            dummyItem.Size = Projectile.Size;
            dummyItem.position = Projectile.Center;

            // Cursed drawing
            foreach (ItemTexturePiece piece in ItemTexturePieces)
                piece.DoDrawInWorld(dummyItem, Main.spriteBatch, lightColor, lightColor, ref Projectile.rotation, ref Projectile.scale, -1);

            return false;
        }
    }
}
