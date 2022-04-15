using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace SpriteAnonSuggestions.Utils.DynamicItemDrawing.Pieces
{
    public class EffectTexturePiece : BasicTexturePiece
    {
        public Effect Effect { init; get; }
        public EffectPass Pass { init; get; }

        public EffectTexturePiece(Texture2D texture, Effect effect, EffectPass pass) : base(texture)
        {
            Effect = effect;
            Pass = pass;
        }

        public override void DrawInInventory(Item item, SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, Main.Rasterizer, Effect, Main.UIScaleMatrix);

            Pass.Apply();
            base.DrawInInventory(item, spriteBatch, position, frame, drawColor, itemColor, origin, scale);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, Main.Rasterizer, null, Main.UIScaleMatrix);
        }

        public override void DrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, Main.Rasterizer, Effect, Main.GameViewMatrix.TransformationMatrix);

            Pass.Apply();
            base.DrawInWorld(item, spriteBatch, lightColor, alphaColor, ref rotation, ref scale, whoAmI);

            spriteBatch.End();
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.None, Main.Rasterizer, null, Main.GameViewMatrix.TransformationMatrix);
        }
    }
}
