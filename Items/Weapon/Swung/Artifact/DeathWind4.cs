using Microsoft.Xna.Framework;
using SpiritMod.Buffs.Artifact;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung.Artifact
{
    public class DeathWind4 : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Death Wind");
            Tooltip.SetDefault("You are the Artifact Keeper of the Undead\nSummons a homing, returning scythe on swing\nEach scythe takes up one minion slot\nAttacks inflict 'Death Wreathe'\nRight-click to cause nearby enemies to take far more damage\n6 second cooldown\nAttacks may ignore enemy defense\nAttacks may grant you 'Soul Reap,' greatly boosting life regeneration\nEnemies affected by the right-click may explode into a cluster of Souls\nEnemies that are killed have a chance to be resurrected as a group of Necromancers\nUp to four Necromancers can exist at once");
        }


        public override void SetDefaults() {
            item.damage = 73;
            item.summon = true;
            item.width = 42;
            item.height = 40;
            item.useTime = 13;
            item.useAnimation = 13;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 8;
            item.value = Item.sellPrice(0, 11, 0, 50);
            item.shoot = mod.ProjectileType("DeathWind4Proj");
            item.rare = 10;
            item.shootSpeed = 16f;
            item.UseSound = SoundID.Item69;
            item.autoReuse = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips) {
            TooltipLine line = new TooltipLine(mod, "ItemName", "Artifact Weapon");
            line.overrideColor = new Color(100, 0, 230);
            tooltips.Add(line);
            foreach(TooltipLine line2 in tooltips) {
                if(line2.mod == "Terraria" && line2.Name == "ItemName") {
                    line2.overrideColor = new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB);
                    break;
                }
            }
        }

        public override bool AltFunctionUse(Player player) {
            return true;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if(player.altFunctionUse == 2) {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 110);
                Main.dust[dust].noGravity = true;
            } else {
                int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 110);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit) {
            if(Main.rand.Next(5) == 2)
                target.AddBuff(mod.BuffType("DeathWreathe3"), 240);
            if(Main.rand.Next(6) == 1)
                damage = damage + (int)(target.defense);
            if(Main.rand.Next(6) == 2)
                player.AddBuff(ModContent.BuffType<SoulReap>(), 240);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            if(player.altFunctionUse == 2) {

                MyPlayer modPlayer = player.GetSpiritPlayer();
                modPlayer.shootDelay1 = 360;
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0, 0, mod.ProjectileType("SoulNet1"), 0, 0, player.whoAmI);
                return true;
            }
            return true;
        }

        public override bool CanUseItem(Player player) {
            if(player.altFunctionUse == 2) {
                MyPlayer modPlayer = player.GetSpiritPlayer();
                if(modPlayer.shootDelay1 == 0)
                    return true;
                return false;
            }
            return true;
        }
    }
}
