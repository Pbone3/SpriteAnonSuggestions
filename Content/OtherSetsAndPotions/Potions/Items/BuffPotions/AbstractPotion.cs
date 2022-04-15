using SpriteAnonSuggestions.Utils;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.OtherSetsAndPotions.Potions.Items.BuffPotions
{
    public abstract class AbstractPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(20);
        }

        public override void SetDefaults()
        {
			Item.UseSound = SoundID.Item3;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useTurn = true;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
		}
    }
}
