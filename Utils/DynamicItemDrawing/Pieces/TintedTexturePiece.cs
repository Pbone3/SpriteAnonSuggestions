using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace SpriteAnonSuggestions.Utils.DynamicItemDrawing.Pieces
{
    public class TintedTexturePiece : BasicTexturePiece
    {
        public Color Tint { init; get; }

        public TintedTexturePiece(Texture2D texture, Color tint) : base(texture)
        {
            Tint = tint;
        }

        public override void DrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            drawColor = Tint;
            base.DrawInInventory(item, spriteBatch, position, frame, drawColor, itemColor, origin, scale);
        }

        public override void DrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            alphaColor = item.GetAlpha(Tint).MultiplyRGBA(alphaColor);
            base.DrawInWorld(item, spriteBatch, lightColor, alphaColor, ref rotation, ref scale, whoAmI);
        }
    }
}
