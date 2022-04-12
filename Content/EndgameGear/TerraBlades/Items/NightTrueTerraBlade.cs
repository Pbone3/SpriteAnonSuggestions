using SpriteAnonSuggestions.Content.EndgameGear.TerraBlades.Projectiles;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.EndgameGear.TerraBlades.Items
{
    public sealed class NightTrueTerraBlade : AbstractTrueTerraBlade
    {
        public sealed override int BaseTerraBladeType => ModContent.ItemType<NightTrueTerraBlade>();
        public sealed override int ProjectileType => ModContent.ProjectileType<NightTerraBeam>();
    }
}
