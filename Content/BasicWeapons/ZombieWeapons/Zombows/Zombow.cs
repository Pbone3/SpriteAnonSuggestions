using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.Zombows
{
    public sealed class Zombow : ModItem
    {
        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TungstenBow);
            Item.shootSpeed = 6.5f;
            Item.width = 18;
            Item.height = 40;
        }
    }
}
