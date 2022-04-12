using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.ZombieArms
{
    public sealed class MushroomZombieArm : ModItem
    {
        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZombieArm);
            Item.damage = 15;
            Item.knockBack = 3.75f;
            Item.useTime = Item.useAnimation = 28;
            Item.rare = ItemRarityID.Orange;

            Item.shootSpeed = 16f;
            Item.shoot = ProjectileID.Mushroom;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position, new Vector2(10f * player.direction, -6f), type, damage, knockback, player.whoAmI);
            Projectile.NewProjectile(source, position, new Vector2(12f * player.direction, 2f), type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}
