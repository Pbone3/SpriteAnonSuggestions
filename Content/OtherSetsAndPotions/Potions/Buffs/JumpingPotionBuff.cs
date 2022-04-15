using Terraria;
using Terraria.ModLoader;

namespace SpriteAnonSuggestions.Content.OtherSetsAndPotions.Potions.Buffs
{
    public sealed class JumpingPotionBuff : ModBuff
    {
        public sealed override void Update(Player player, ref int buffIndex)
        {
            player.jumpSpeedBoost += 2f;
            player.extraFall += 12;
        }
    }
}
