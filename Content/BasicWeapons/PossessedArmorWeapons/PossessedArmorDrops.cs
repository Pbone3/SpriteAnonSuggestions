using SpriteAnonSuggestions.Content.BasicWeapons.PossessedArmorWeapons.Items;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.PossessedArmorWeapons
{
    public sealed class PossessedArmorDrops : GlobalNPC
    {
        public sealed override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.PossessedArmor)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PossessedPartisan>(), 100));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PossessedSword>(), 100));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PossessedWarAxe>(), 100));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PossessedWarHammer>(), 100));
            }
        }
    }
}
