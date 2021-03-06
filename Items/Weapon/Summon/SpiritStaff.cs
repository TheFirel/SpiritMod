using Microsoft.Xna.Framework;
using SpiritMod.Buffs.Summon;
using SpiritMod.Projectiles.Summon;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Summon
{
    public class SpiritStaff : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Spirit Staff");
            Tooltip.SetDefault("Summons an unbound soul to shoot Essence-trapping spirit flames at foes!");
        }


        public override void SetDefaults() {
            item.width = 26;
            item.height = 28;
            item.value = Item.buyPrice(0, 6, 0, 0);
            item.rare = 5;
            item.damage = 34;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 36;
            item.useAnimation = 36;
            item.mana = 10;
            item.summon = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<UnboundSoul>();
            item.buffType = ModContent.BuffType<UnboundSoulMinionBuff>();
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
        public override bool AltFunctionUse(Player player) {
            return true;
        }

        public override bool UseItem(Player player) {
            if(player.altFunctionUse == 2) {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            return player.altFunctionUse != 2;
            position = Main.MouseWorld;
            speedX = speedY = 0;
            return true;
        }

    }
}
