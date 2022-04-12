using Microsoft.Xna.Framework;
using SpriteAnonSuggestions.Content.EndgameGear.TerraBlades.Projectiles;
using SpriteAnonSuggestions.Utils;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.EndgameGear.TerraBlades.Items
{
    public sealed class NightTerraBlade : ModItem
    {
        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TerraBlade);
            Item.shoot = ModContent.ProjectileType<NightTerraBeam>();
        }

        public sealed override bool CanShoot(Player player) => player.itemAnimation == player.itemAnimationMax - 1;


        public sealed override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            damage = (int)(damage * 1.5f);
        }

        public sealed override Color? GetAlpha(Color lightColor) => Color.White;

        public sealed override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TrueNightsEdge)
                .AddIngredient(ItemID.TrueExcalibur)
                .AddTile(TileID.MythrilAnvil)
                .AddCondition(new Recipe.Condition(NetworkText.FromKey(L10nUtils.GetModKey("RecipeConditions.NightOnly")), recipe => !Main.dayTime))
                .Register();
        }
    }
}
