using SpriteAnonSuggestions.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.PossessedArmorWeapons.Items
{
    public sealed class PossessedSword : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

        public sealed override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = false;
            Item.useAnimation = 25;
            Item.useTime = 25;

            Item.width = 44;
            Item.height = 44;

            Item.damage = 46;
            Item.knockBack = 5.15f;
            Item.UseSound = SoundID.Item1;
            Item.scale = 1.1f;
            Item.value = Item.sellPrice(0, 3);
            Item.DamageType = DamageClass.Melee;
            Item.rare = ItemRarityID.LightRed;
        }
    }
}
