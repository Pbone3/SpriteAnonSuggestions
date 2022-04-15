using SpriteAnonSuggestions.Utils;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.OtherSetsAndPotions.Potions.Items.HealthAndManaPotions
{
    public sealed class BottomlessHealingPotion : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GreaterHealingPotion);
            Item.consumable = false;
            Item.maxStack = 1;
            Item.width = 26;
            Item.height = 32;
            Item.value *= 15;
        }

        public sealed override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.GreaterHealingPotion, 15)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddTile(TileID.CrystalBall)
                .Register();
        }
    }
}
