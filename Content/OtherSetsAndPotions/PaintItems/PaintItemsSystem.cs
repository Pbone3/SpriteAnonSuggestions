using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using SpriteAnonSuggestions.Content.OtherSetsAndPotions.PaintItems.Items;
using SpriteAnonSuggestions.Utils;
using SpriteAnonSuggestions.Utils.DynamicItemDrawing;
using SpriteAnonSuggestions.Utils.DynamicItemDrawing.Pieces;
using Terraria;
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

            RegisterPaintGrenadeWithNormalTexture("Red", ItemID.RedPaint, PaintID.RedPaint);
            RegisterPaintGrenadeWithNormalTexture("Orange", ItemID.OrangePaint, PaintID.OrangePaint);
            RegisterPaintGrenadeWithNormalTexture("Yellow", ItemID.YellowPaint, PaintID.YellowPaint);
            RegisterPaintGrenadeWithNormalTexture("Lime", ItemID.LimePaint, PaintID.LimePaint);
            RegisterPaintGrenadeWithNormalTexture("Green", ItemID.GreenPaint, PaintID.GreenPaint);
            RegisterPaintGrenadeWithNormalTexture("Teal", ItemID.TealPaint, PaintID.TealPaint);
            RegisterPaintGrenadeWithNormalTexture("Cyan", ItemID.CyanPaint, PaintID.CyanPaint);
            RegisterPaintGrenadeWithNormalTexture("SkyBlue", ItemID.SkyBluePaint, PaintID.SkyBluePaint);
            RegisterPaintGrenadeWithNormalTexture("Blue", ItemID.BluePaint, PaintID.BluePaint);
            RegisterPaintGrenadeWithNormalTexture("Purple", ItemID.PurplePaint, PaintID.PurplePaint);
            RegisterPaintGrenadeWithNormalTexture("Violet", ItemID.VioletPaint, PaintID.VioletPaint);
            RegisterPaintGrenadeWithNormalTexture("Pink", ItemID.PinkPaint, PaintID.PinkPaint);

            RegisterPaintGrenadeWithNormalTexture("Black", ItemID.BlackPaint, PaintID.BlackPaint);
            RegisterPaintGrenadeWithNormalTexture("Gray", ItemID.GrayPaint, PaintID.GrayPaint);
            RegisterPaintGrenadeWithNormalTexture("White", ItemID.WhitePaint, PaintID.WhitePaint);
            RegisterPaintGrenadeWithNormalTexture("Brown", ItemID.BrownPaint, PaintID.BrownPaint);
            
            RegisterPaintGrenadeWithDarkTexture("DeepRed", ItemID.DeepRedPaint, PaintID.DeepRedPaint);
            RegisterPaintGrenadeWithDarkTexture("DeepOrange", ItemID.DeepOrangePaint, PaintID.DeepOrangePaint);
            RegisterPaintGrenadeWithDarkTexture("DeepYellow", ItemID.DeepYellowPaint, PaintID.DeepYellowPaint);
            RegisterPaintGrenadeWithDarkTexture("DeepLime", ItemID.DeepLimePaint, PaintID.DeepLimePaint);
            RegisterPaintGrenadeWithDarkTexture("DeepGreen", ItemID.DeepGreenPaint, PaintID.DeepGreenPaint);
            RegisterPaintGrenadeWithDarkTexture("DeepTeal", ItemID.DeepTealPaint, PaintID.DeepTealPaint);
            RegisterPaintGrenadeWithDarkTexture("DeepCyan", ItemID.DeepCyanPaint, PaintID.DeepCyanPaint);
            RegisterPaintGrenadeWithDarkTexture("DeepSkyBlue", ItemID.DeepSkyBluePaint, PaintID.DeepSkyBluePaint);
            RegisterPaintGrenadeWithDarkTexture("DeepBlue", ItemID.DeepBluePaint, PaintID.DeepBluePaint);
            RegisterPaintGrenadeWithDarkTexture("DeepPurple", ItemID.DeepPurplePaint, PaintID.DeepPurplePaint);
            RegisterPaintGrenadeWithDarkTexture("DeepViolet", ItemID.DeepVioletPaint, PaintID.DeepVioletPaint);
            RegisterPaintGrenadeWithDarkTexture("DeepPink", ItemID.DeepPinkPaint, PaintID.DeepPinkPaint);
        }

        public void RegisterPaintGrenadeWithNormalTexture(string paintName, int paintItemId, int paintType) =>
            Mod.AddContent(new PaintGrenade(paintName, paintItemId, paintType, GetPaintGrenadeTextureNormal(paintType)));

        public void RegisterPaintGrenadeWithDarkTexture(string paintName, int paintItemId, int paintType) =>
            Mod.AddContent(new PaintGrenade(paintName, paintItemId, paintType, GetPaintGrenadeTextureDark(paintType)));

        public static ItemTexturePiece[] GetPaintGrenadeTextureNormal(int paintId) =>
            new ItemTexturePiece[2] {
                new TintedTexturePiece(PaintGrenadeBody, WorldGen.paintColor(paintId)),
                new BasicTexturePiece(PaintGrenadeTop_Normal)
        };

        public static ItemTexturePiece[] GetPaintGrenadeTextureDark(int paintId) =>
            new ItemTexturePiece[2] {
                new TintedTexturePiece(PaintGrenadeBody, WorldGen.paintColor(paintId)),
                new BasicTexturePiece(PaintGrenadeTop_Dark)
            };
    }
}
