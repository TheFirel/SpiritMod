using Microsoft.Xna.Framework;
using SpiritMod.Projectiles.Summon;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.Weapon.Summon
{
    public class StarlightStaff : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Starlight Staff");
            Tooltip.SetDefault("Summons a stationary twinkle popper");
        }


        public override void SetDefaults() {
            item.CloneDefaults(ItemID.QueenSpiderStaff); //only here for values we haven't defined ourselves yet
            item.damage = 71;  //placeholder damage :3
            item.mana = 40;   //somehow I think this might be too much...? -thegamemaster1234
            item.width = 40;
            item.height = 40;
            item.value = Terraria.Item.sellPrice(0, 5, 0, 0);
            item.rare = 9;
            item.knockBack = 2.5f;
            item.UseSound = SoundID.Item25;
            item.shoot = ModContent.ProjectileType<TwinklePopperMinion>();
            item.shootSpeed = 0f;
        }
        public override bool Shoot(Player player, ref Microsoft.Xna.Framework.Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            //remove any other owned SpiritBow projectiles, just like any other sentry minion
            for(int i = 0; i < Main.projectile.Length; i++) {
                Projectile p = Main.projectile[i];
                if(p.active && p.type == item.shoot && p.owner == player.whoAmI) {
                    p.active = false;
                }
            }
            //projectile spawns at mouse cursor
            Vector2 value18 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
            position = value18;
            return true;
        }
    }
}