using SpiritMod.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Summon
{
    public class PigronMinionBuff : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Pigron Minion");
            Description.SetDefault("Bacon!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            MyPlayer modPlayer = player.GetSpiritPlayer();
            if(player.ownedProjectileCounts[ModContent.ProjectileType<PigronMinion>()] > 0) {
                modPlayer.pigronMinion = true;
            }

            if(!modPlayer.pigronMinion) {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }

            player.buffTime[buffIndex] = 18000;
        }
    }
}
