using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace SpriteAnonSuggestions.Utils.DynamicItemDrawing.Pieces
{
    public class PaintTintedTexturePiece : EffectTexturePiece
    {
        public PaintTintedTexturePiece(Texture2D texture, int paintId) : base(texture, Main.tileShader, null)
        {
            int index = Main.ConvertPaintIdToTileShaderIndex(paintId, false, false);

            Effect.Parameters["leafHueTestOffset"].SetValue(0f);
            Effect.Parameters["leafMinHue"].SetValue(0f);
            Effect.Parameters["leafMaxHue"].SetValue(0f);
            Effect.Parameters["leafMinSat"].SetValue(0f);
            Effect.Parameters["leafMaxSat"].SetValue(0f);
            Effect.Parameters["invertSpecialGroupResult"].SetValue(0f);

            Pass = Effect.CurrentTechnique.Passes[index];
        }
    }
}
