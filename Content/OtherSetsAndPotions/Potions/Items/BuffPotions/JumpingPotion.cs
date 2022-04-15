using SpriteAnonSuggestions.Content.OtherSetsAndPotions.Potions.Buffs;
using SpriteAnonSuggestions.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.OtherSetsAndPotions.Potions.Items.BuffPotions
{
    public sealed class JumpingPotion : AbstractPotion
    {
        public sealed override void SetDefaults()
        {
            base.SetDefaults();
            Item.width = 16;
            Item.height = 34;
            Item.value = Item.sellPrice(0, 50);
            Item.buffType = ModContent.BuffType<JumpingPotionBuff>();
            Item.buffTime = BuffUtils.Minutes(8);
        }

        public sealed override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.BottledWater)
                .AddIngredient(ItemID.Daybloom)
                .AddIngredient(ItemID.PinkGel)
                .AddIngredient(ItemID.Feather)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}
