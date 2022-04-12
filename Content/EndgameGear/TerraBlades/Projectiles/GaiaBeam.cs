using Terraria;
using Terraria.ID;

namespace SpriteAnonSuggestions.Content.EndgameGear.TerraBlades.Projectiles
{
    public sealed class GaiaBeam : NightTerraBeam
    {
        public sealed override int DustType => DustID.Clentaminator_Cyan;

        public sealed override void SetDefaults()
        {
            base.SetDefaults();
            Projectile.width = 20;
            Projectile.height = 20;
        }

        public sealed override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            // Reduce damage on hit
            Projectile.damage = (int)(Projectile.damage * 0.95f);
        }
    }
}