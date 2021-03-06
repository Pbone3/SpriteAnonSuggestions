using Microsoft.Xna.Framework;
using SpriteAnonSuggestions.Utils;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.Items
{
    public sealed class BloodyZombieArm : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

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
