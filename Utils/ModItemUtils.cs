using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Utils
{
    public static class ModItemUtils
    {
        public static void JourneyResearchNeeded(this ModItem modItem, int amount)
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[modItem.Type] = amount;
        }
    }
}
