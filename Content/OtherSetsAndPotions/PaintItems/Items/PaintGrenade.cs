using SpriteAnonSuggestions.Utils.DynamicItemDrawing;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.OtherSetsAndPotions.PaintItems.Items
{
    [Autoload(false)]
    public sealed class PaintGrenade : DynamicallyDrawnItem
    {
        public int PaintItemId { init; get; }
        public int PaintType { init; get; }

        public PaintGrenade(int paintItemId, int paintType, params ItemTexturePiece[] texturePieces) : base(texturePieces)
        {
            PaintItemId = paintItemId;
            PaintType = paintType;
        }

        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Grenade);
            Item.shoot = ProjectileID.None;
        }

        public sealed override void AddRecipes()
        {
            /*CreateRecipe(5)
                .AddIngredient(ItemID.Grenade, 5)
                .AddIngredient(PaintItemId, 5)
                .AddTile(TileID.Anvils)
                .Register();*/
        }
    }
}
