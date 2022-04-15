using SpriteAnonSuggestions.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.PossessedArmorWeapons.Items
{
    public sealed class PossessedWarHammer : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

        public sealed override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = false;
            Item.useAnimation = 36;
            Item.useTime = 36;

            Item.width = 40;
            Item.height = 40;

            Item.damage = 41;
            Item.knockBack = 6.25f;
            Item.UseSound = SoundID.Item1;
            Item.scale = 1.1f;
            Item.value = Item.sellPrice(0, 3);
            Item.DamageType = DamageClass.Melee;
            Item.hammer = 20;
            Item.rare = ItemRarityID.LightRed;
        }
    }
}
