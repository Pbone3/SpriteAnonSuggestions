using SpriteAnonSuggestions.Utils;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.Items
{
    public sealed class BloodyZombow : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TungstenBow);
            Item.damage = 13;
            Item.shootSpeed = 6.75f;
            Item.width = 20;
            Item.height = 44;
            Item.rare = ItemRarityID.Orange;
        }
    }
}
