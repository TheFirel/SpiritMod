using Microsoft.Xna.Framework;
using SpiritMod.Buffs.Summon;
using SpiritMod.Projectiles.Summon;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Summon
{
    public class FamineScepter : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Famine Scepter");
            Tooltip.SetDefault("Summons a hungry to fight for you... on you...\nThe hungry will slowly drain your life");
        }


        public override void SetDefaults() {
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 4;
            item.crit = 4;
            item.mana = 14;
            item.damage = 32;
            item.knockBack = 3;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 30;
            item.useAnimation = 30;
            item.summon = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<HungryMinion>();
            item.buffType = ModContent.BuffType<HungryMinionBuff>();
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
        public override bool AltFunctionUse(Player player) {
            return true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            return player.altFunctionUse != 2;
        }

        public override bool UseItem(Player player) {
            if(player.altFunctionUse == 2) {
                player.MinionNPCTargetAim();
            }
            return base.UseItem(player);
        }
    }
}
