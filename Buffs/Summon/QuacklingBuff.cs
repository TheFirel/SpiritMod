using SpiritMod.Projectiles.DonatorItems;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Buffs.Summon
{
    public class QuacklingBuff : ModBuff
    {
        public override void SetDefaults() {
            DisplayName.SetDefault("Quackling Minion");
            Description.SetDefault("Born with a bandana!");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex) {
            MyPlayer modPlayer = player.GetSpiritPlayer();
            if(player.ownedProjectileCounts[ModContent.ProjectileType<QuacklingMinion>()] > 0) {
                modPlayer.QuacklingMinion = true;
            }

            if(!modPlayer.QuacklingMinion) {
                player.DelBuff(buffIndex);
                buffIndex--;
                return;
            }

            player.buffTime[buffIndex] = 18000;
        }
    }
}
