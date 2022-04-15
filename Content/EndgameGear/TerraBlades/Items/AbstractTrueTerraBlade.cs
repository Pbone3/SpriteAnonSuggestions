using Microsoft.Xna.Framework;
using SpriteAnonSuggestions.Content.BossGear.LunaticCultist;
using SpriteAnonSuggestions.Utils;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.EndgameGear.TerraBlades.Items
{
    public abstract class AbstractTrueTerraBlade : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

        public abstract int BaseTerraBladeType { get; }
        public abstract int ProjectileType { get; }

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
            Item.shoot = ProjectileType;
            Item.knockBack = 6.5f;
            Item.DamageType = DamageClass.Melee;
            Item.value = Item.sellPrice(0, 25);
            Item.autoReuse = true;
        }

        public sealed override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile pro = Projectile.NewProjectileDirect(source, (position + Vector2.UnitY * 16).RotatedBy(player.DirectionTo(Main.MouseWorld).ToRotation(), position), velocity, type, damage, knockback, player.whoAmI);
            pro.tileCollide = false;
            pro.timeLeft = 240;

            pro = Projectile.NewProjectileDirect(source, (position - Vector2.UnitY * 16).RotatedBy(player.DirectionTo(Main.MouseWorld).ToRotation(), position), velocity, type, damage, knockback, player.whoAmI);
            pro.tileCollide = false;
            pro.timeLeft = 240;

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
            CreateRecipe()
                .AddIngredient(BaseTerraBladeType)
                .AddIngredient(ModContent.ItemType<TerraCore>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
