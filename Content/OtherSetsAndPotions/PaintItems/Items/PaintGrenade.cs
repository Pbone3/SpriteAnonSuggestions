using Microsoft.Xna.Framework;
using SpriteAnonSuggestions.Content.OtherSetsAndPotions.PaintItems.Projectiles;
using SpriteAnonSuggestions.Utils;
using SpriteAnonSuggestions.Utils.DynamicItemDrawing;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.OtherSetsAndPotions.PaintItems.Items
{
    [Autoload(false)]
    public sealed class PaintGrenade : DynamicallyDrawnItem
    {
        public sealed override string Texture => $"Terraria/Images/Item_{ItemID.Grenade}";
        public sealed override string Name => $"{PaintName}PaintGrenade";

        public string PaintName { init; get; }
        public int PaintItemId { init; get; }
        public int PaintType { init; get; }

        public PaintGrenade(string paintName, int paintItemId, int paintType, params ItemTexturePiece[] texturePieces) : base(texturePieces)
        {
            PaintName = paintName;
            PaintItemId = paintItemId;
            PaintType = paintType;
        }

        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(99);
        }

        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Grenade);
            Item.shoot = ModContent.ProjectileType<PaintGrenadeProjectile>();
            Item.value += 25;
        }

        public sealed override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile proj = Projectile.NewProjectileDirect(source, position, velocity, type, damage, knockback, player.whoAmI);
            proj.ai[1] = PaintType;
            (proj.ModProjectile as PaintGrenadeProjectile).ItemTexturePieces = texturePieces;

            return false;
        }

        public sealed override void AddRecipes()
        {
            CreateRecipe(5)
                 .AddIngredient(ItemID.Grenade, 5)
                 .AddIngredient(PaintItemId, 5)
                 .AddTile(TileID.Anvils)
                 .Register();
        }
    }
}
