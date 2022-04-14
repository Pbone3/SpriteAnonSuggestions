using Microsoft.Xna.Framework;
using SpriteAnonSuggestions.Utils;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.Zombows
{
    public sealed class MushroomZombow : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TungstenBow);
            Item.damage = 12;
            Item.shootSpeed = 6.6f;
            Item.width = 18;
            Item.height = 40;
            Item.rare = ItemRarityID.Orange;
        }

        public sealed override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // As always, thanks EM
            float numberProjectiles = 4;
            float rotation = MathHelper.ToRadians(60);
            position += Vector2.Normalize(velocity) * 15f;
            
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .25f;

                Projectile proj = Projectile.NewProjectileDirect(source, position, perturbedSpeed, ProjectileID.TruffleSpore, damage / 5, knockback, player.whoAmI);
                proj.aiStyle = ProjAIStyleID.Arrow;
                proj.timeLeft = 12;
                proj.alpha = 0;
            }

            return true;
        }
    }
}
