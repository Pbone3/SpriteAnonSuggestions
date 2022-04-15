using Microsoft.Xna.Framework;
using SpriteAnonSuggestions.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BossGear.LunaticCultist
{
    public sealed class TerraCore : ModItem
    {
        public sealed override void SetStaticDefaults()
        {
            this.JourneyResearchNeeded(1);
        }

        public sealed override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(0, 5, 0);
            Item.rare = ItemRarityID.Yellow;
        }

        public sealed override Color? GetAlpha(Color lightColor) => Color.White;
    }
}
