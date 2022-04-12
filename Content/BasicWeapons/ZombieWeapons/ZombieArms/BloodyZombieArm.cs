using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.ZombieArms
{
    public sealed class BloodyZombieArm : ModItem
    {
        public sealed override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.ZombieArm);
            Item.damage = 19;
            Item.knockBack = 5.25f;
            Item.Size = new Vector2(38f);
            Item.useTime = Item.useAnimation = 20;
            Item.rare = ItemRarityID.Orange;

            Item.UseSound = SoundID.NPCHit18;
        }
    }
}
