using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.ZombieArms
{
    public sealed class FrozenZombieArm : ModItem
    {
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
