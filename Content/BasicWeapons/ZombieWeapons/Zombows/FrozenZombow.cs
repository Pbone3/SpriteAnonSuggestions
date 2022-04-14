using SpriteAnonSuggestions.Utils;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.Zombows
{
    public sealed class FrozenZombow : ModItem
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
            Item.rare = ItemRarityID.Blue;
        }
    }
}
