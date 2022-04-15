using SpriteAnonSuggestions.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.PossessedArmorWeapons.Items
{
    public sealed class PossessedWarAxe : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

        public sealed override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = false;
            Item.useAnimation = 34;
            Item.useTime = 34;

            Item.width = 44;
            Item.height = 44;

            Item.damage = 56;
            Item.knockBack = 6f;
            Item.UseSound = SoundID.Item1;
            Item.scale = 1.1f;
            Item.value = Item.sellPrice(0, 3);
            Item.DamageType = DamageClass.Melee;
            Item.axe = 20;
            Item.rare = ItemRarityID.LightRed;
        }
    }
}
