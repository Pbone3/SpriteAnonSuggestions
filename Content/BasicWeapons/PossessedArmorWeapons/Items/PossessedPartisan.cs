using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using SpriteAnonSuggestions.Utils;

namespace SpriteAnonSuggestions.Content.BasicWeapons.PossessedArmorWeapons.Items
{
    public sealed class PossessedPartisan : ModItem
    {
		public sealed override void SetStaticDefaults()
		{
			this.JourneyResearchNeeded(1);
		}

		public sealed override void SetDefaults()
        {
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.shootSpeed = 4.3f;

			Item.width = 44;
			Item.height = 46;

			Item.damage = 35;
			Item.knockBack = 4.5f;
			Item.scale = 1.1f;
			Item.UseSound = SoundID.Item1;
			Item.shoot = ProjectileID.CobaltNaginata;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.sellPrice(0, 3);
			Item.noMelee = true;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
		}
    }
}
