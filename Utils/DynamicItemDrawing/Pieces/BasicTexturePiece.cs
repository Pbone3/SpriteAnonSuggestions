using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace SpriteAnonSuggestions.Utils.DynamicItemDrawing.Pieces
{
    public class BasicTexturePiece : ItemTexturePiece
    {
        public Texture2D Texture { init; get; }

        public BasicTexturePiece(Texture2D texture)
        {
            Texture = texture;
        }

        public override void DrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            spriteBatch.Draw(Texture, position, frame, drawColor, 0f, origin, scale, SpriteEffects.None, 0f);
        }

        public override void DrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Rectangle? frame = null;
            Vector2? origin = Vector2.Zero;

            if (Main.itemAnimations[item.type] != null)
            {
                frame = Main.itemAnimations[item.type].GetFrame(Texture);
                origin = frame?.Size() / 2f;
            }

            spriteBatch.Draw(Texture, item.position - Main.screenPosition, frame, alphaColor, rotation, origin.GetValueOrDefault(), scale, SpriteEffects.None, 0f);
        }
    }
}
