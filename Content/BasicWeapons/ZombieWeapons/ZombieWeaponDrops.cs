using SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.Items;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons
{
    public sealed class ZombieWeaponDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            bool hasSpecialZombowDrop = false;

            // Expert not having increased chances is intentional, vanilla doesn't do it for Zombie Arms either
            switch (npc.type)
            {
                case NPCID.ZombieEskimo:
                case NPCID.ArmedZombieEskimo:
                    npcLoot.RemoveWhere(drop => drop is CommonDrop cDrop && cDrop.itemId == ItemID.ZombieArm);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrozenZombieArm>(), 250));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrozenZombow>(), 250));
                    hasSpecialZombowDrop = true;
                    break;

                case NPCID.ZombieMushroom:
                case NPCID.ZombieMushroomHat:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MushroomZombieArm>(), 25));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MushroomZombow>(), 250));
                    hasSpecialZombowDrop = true;
                    break;

                case NPCID.BloodZombie:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodyZombieArm>(), 250));
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodyZombow>(), 250));
                    hasSpecialZombowDrop = true;
                    break;
            }

            if (!hasSpecialZombowDrop && NPCID.Sets.Zombies[npc.type] == true)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Zombow>(), 250));
        }
    }
}
