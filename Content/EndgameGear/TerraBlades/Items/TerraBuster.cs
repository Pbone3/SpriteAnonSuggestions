using Microsoft.Xna.Framework;
using SpriteAnonSuggestions.Content.EndgameGear.TerraBlades.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.EndgameGear.TerraBlades.Items
{
    public sealed class TerraBuster : ModItem
    {
        public override void SetDefaults()
        {
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.damage = 165;
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.width = 48;
            Item.height = 48;
            Item.shootSpeed = 14f;
            Item.shoot = ModContent.ProjectileType<GaiaBeam>();
            Item.knockBack = 6.5f;
            Item.DamageType = DamageClass.Melee;
            Item.value = Item.sellPrice(0, 25);
            Item.autoReuse = true;
        }

        public sealed override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile pro = Projectile.NewProjectileDirect(source, (position + Vector2.UnitY * 16).RotatedBy(player.DirectionTo(Main.MouseWorld).ToRotation(), position), velocity, type, damage, knockback, player.whoAmI);
            pro.tileCollide = false;
            pro.timeLeft = 180;

            pro = Projectile.NewProjectileDirect(source, (position - Vector2.UnitY * 16).RotatedBy(player.DirectionTo(Main.MouseWorld).ToRotation(), position), velocity, type, damage, knockback, player.whoAmI);
            pro.tileCollide = false;
            pro.timeLeft = 180;

            return false;
        }

        public sealed override bool CanShoot(Player player) => player.itemAnimation == player.itemAnimationMax - 1;

        public sealed override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            damage = (int)(damage * 1.65f);
        }

        public sealed override Color? GetAlpha(Color lightColor) => Color.White;

        public sealed override void AddRecipes()
        {
            /*CreateRecipe()
				.AddIngredient(ModContent.ItemType<TrueTerraBlade>())
                .AddIngredient(ModContent.ItemType<NightTrueTerraBlade>())
                .AddIngredient(ItemID.FragmentSolar, 5)
				.AddIngredient(ItemID.FragmentVortex, 5)
				.AddIngredient(ItemID.FragmentNebula, 5)
				.AddIngredient(ItemID.FragmentStardust, 5)
                .AddTile(TileID.LunarCraftingStation)
				.Register();*/
        }
    }
}
