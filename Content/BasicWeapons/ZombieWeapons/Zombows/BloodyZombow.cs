using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.Zombows
{
    public sealed class BloodyZombow : ModItem
    {
        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TungstenBow);
            Item.damage = 13;
            Item.shootSpeed = 6.75f;
            Item.width = 20;
            Item.height = 44;
        }
    }
}
