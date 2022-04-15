using SpriteAnonSuggestions.Utils;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.Items
{
    public sealed class FrozenZombieArm : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZombieArm);
            Item.damage = 14;
            Item.knockBack = 4.5f;
            Item.useTime = Item.useAnimation = 22;
            Item.rare = ItemRarityID.Blue;
        }
    }
}
