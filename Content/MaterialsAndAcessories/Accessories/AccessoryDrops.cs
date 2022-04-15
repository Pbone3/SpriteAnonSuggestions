using SpriteAnonSuggestions.Content.MaterialsAndAcessories.Accessories.Items.PreHardMode;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.MaterialsAndAcessories.Accessories
{
    public sealed class AccessoryDrops : GlobalNPC
    {
        public sealed override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (NPCID.Sets.DemonEyes[npc.type])
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MagnifyingGlass>(), 100));
        }
    }
}
