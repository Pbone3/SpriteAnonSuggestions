using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.Zombows
{
    public sealed class MushroomZombowSpore : ModProjectile
    {
        public sealed override string Texture => "Terraria/Images/Projectile_" + ProjectileID.TruffleSpore;

        public sealed override void SetStaticDefaults()
        {
            Main.projFrames[Type] = 3;
        }

        public sealed override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.TruffleSpore);
            //Projectile.aiStyle = ProjAIStyleID.Arrow;
        }
    }
}
