using Microsoft.Xna.Framework;
using SpiritMod.Projectiles.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class BismiteWrath : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bismite Wrath");
            Tooltip.SetDefault("Shoots a cluster of bismite wrath shards!\nOccasionally causes foes to receive 'Festering Wounds,' which deal more damage to enemies under half health");
        }


        public override void SetDefaults() {
            item.damage = 9;
            item.magic = true;
            item.mana = 6;
            item.width = 22;
            item.height = 22;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = Terraria.Item.sellPrice(0, 0, 13, 0);
            item.rare = 1;
            item.UseSound = SoundID.Item20;
            item.autoReuse = false;
            item.shoot = ModContent.ProjectileType<BismiteShot>();
            item.shootSpeed = 7f;
        }

        public static Vector2[] randomSpread(float speedX, float speedY, int angle, int num) {
            var posArray = new Vector2[num];
            float spread = (float)(angle * 0.0174532925);
            float baseSpeed = (float)System.Math.Sqrt(speedX * speedX + speedY * speedY);
            double baseAngle = System.Math.Atan2(speedX, speedY);
            double randomAngle;
            for(int i = 0; i < num; ++i) {
                randomAngle = baseAngle + (Main.rand.NextFloat() - 0.5f) * spread;
                posArray[i] = new Vector2(baseSpeed * (float)System.Math.Sin(randomAngle), baseSpeed * (float)System.Math.Cos(randomAngle));
            }
            return (Vector2[])posArray;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            Vector2[] speeds = randomSpread(speedX, speedY, 8, 3);
            for(int i = 0; i < 3; ++i) {
                Projectile.NewProjectile(position.X, position.Y, speeds[i].X, speeds[i].Y, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BismiteCrystal", 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}