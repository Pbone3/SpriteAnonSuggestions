using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SpriteAnonSuggestions.Content.OtherSetsAndPotions.PaintItems.Items;
using SpriteAnonSuggestions.Utils;
using SpriteAnonSuggestions.Utils.DynamicItemDrawing;
using SpriteAnonSuggestions.Utils.DynamicItemDrawing.Pieces;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.OtherSetsAndPotions.PaintItems
{
    public sealed class PaintItemsSystem : ModSystem
    {
        public static Texture2D PaintGrenadeBody;
        public static Texture2D PaintGrenadeTop_Normal;
        public static Texture2D PaintGrenadeTop_Dark;

        public sealed override void Load()
        {
            LoadingUtils.InvokeOnMainThread(() => {
                PaintGrenadeBody = ModContent.Request<Texture2D>(
                    "SpriteAnonSuggestions/Content/OtherSetsAndPotions/PaintItems/Items/PaintGrenadeBody", AssetRequestMode.ImmediateLoad).Value;
                PaintGrenadeTop_Normal = ModContent.Request<Texture2D>(
                    "SpriteAnonSuggestions/Content/OtherSetsAndPotions/PaintItems/Items/PaintGrenadeTop_Normal", AssetRequestMode.ImmediateLoad).Value;
                PaintGrenadeTop_Dark = ModContent.Request<Texture2D>(
                    "SpriteAnonSuggestions/Content/OtherSetsAndPotions/PaintItems/Items/PaintGrenadeTop_Dark", AssetRequestMode.ImmediateLoad).Value;
            });

            RegisterPaintGrenadeWithNormalTexture(ItemID.RedPaint, PaintID.RedPaint);
        }

        public void RegisterPaintGrenadeWithNormalTexture(int paintItemId, int paintType)
        {
            Mod.AddContent(new PaintGrenade(paintItemId, paintType, GetPaintGrenadeTextureNormal(paintType)));
        }

        public static ItemTexturePiece[] GetPaintGrenadeTextureNormal(int paintId) =>
            new ItemTexturePiece[2] {
                new PaintTintedTexturePiece(PaintGrenadeBody, paintId),
                new BasicTexturePiece(PaintGrenadeTop_Normal)
        };

        public static ItemTexturePiece[] GetPaintGrenadeTextureDark(int paintId) =>
            new ItemTexturePiece[2] {
                new PaintTintedTexturePiece(PaintGrenadeBody, paintId),
                new BasicTexturePiece(PaintGrenadeTop_Dark)
            };
    }
}
