using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.ZombieArms
{
    public sealed class BloodZombieArm : ModItem
    {
        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZombieArm);
            Item.damage = 24;
            Item.knockBack = 5.25f;
            Item.useTime = Item.useAnimation = 20;
            Item.rare = ItemRarityID.Orange;

            Item.UseSound = SoundID.NPCHit18;
        }
    }
}
