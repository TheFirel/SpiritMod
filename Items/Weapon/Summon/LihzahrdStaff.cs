using SpiritMod.Buffs.Summon;
using SpiritMod.Projectiles.Summon;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
    public class LihzahrdStaff : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lihzahrd Staff");
        }


        public override void SetDefaults() {
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 7, 0, 0);
            item.rare = 6;
            item.mana = 10;
            item.damage = 40;
            item.knockBack = 7;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 30;
            item.useAnimation = 30;
            item.summon = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<LihzahrdMinion>();
            item.buffType = ModContent.BuffType<LihzahrdMinionBuff>();
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
    }
}