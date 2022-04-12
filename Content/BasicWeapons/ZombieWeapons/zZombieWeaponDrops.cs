using SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons.ZombieArms;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.BasicWeapons.ZombieWeapons
{
    public sealed class zZombieWeaponDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            // Expert not having increased chances is intentional, vanilla doesn't do it for Zombie Arms either
            switch (npc.type)
            {
                case NPCID.ZombieEskimo:
                case NPCID.ArmedZombieEskimo:
                    npcLoot.RemoveWhere(drop => drop is CommonDrop cDrop && cDrop.itemId == ItemID.ZombieArm);
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrozenZombieArm>(), 250));
                    break;

                case NPCID.BloodZombie:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodyZombieArm>(), 250));
                    break;

                case NPCID.ZombieMushroom:
                case NPCID.ZombieMushroomHat:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MushroomZombieArm>(), 25));
                    break;
            }
        }
    }
}
