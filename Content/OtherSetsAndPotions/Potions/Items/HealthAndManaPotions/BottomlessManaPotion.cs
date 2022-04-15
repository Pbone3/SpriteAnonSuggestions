using SpriteAnonSuggestions.Utils;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.OtherSetsAndPotions.Potions.Items.HealthAndManaPotions
{
    public sealed class BottomlessManaPotion : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GreaterManaPotion);
            Item.consumable = false;
            Item.maxStack = 1;
            Item.width = 26;
            Item.height = 32;
            Item.value *= 15;
        }

        public sealed override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GreaterManaPotion, 15)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
