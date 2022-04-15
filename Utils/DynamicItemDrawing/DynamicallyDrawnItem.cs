using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Utils.DynamicItemDrawing
{
    public abstract class DynamicallyDrawnItem : ModItem
    {
        private readonly List<ItemTexturePiece> texturePieces = new();

        public DynamicallyDrawnItem(params ItemTexturePiece[] pieces)
        {
            texturePieces.AddRange(pieces);
            texturePieces = texturePieces.OrderBy(piece => piece.Depth).ToList();
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            foreach (ItemTexturePiece piece in texturePieces)
                piece.DoDrawInInventory(Item, spriteBatch, position, frame, drawColor, itemColor, origin, scale);

            return false;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            foreach (ItemTexturePiece piece in texturePieces)
                piece.DoDrawInWorld(Item, spriteBatch, lightColor, alphaColor, ref rotation, ref scale, whoAmI);

            return false;
        }
    }
}
