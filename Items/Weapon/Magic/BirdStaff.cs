using Microsoft.Xna.Framework;
using SpiritMod.Projectiles.Magic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Magic
{
    public class BirdStaff : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Yaksha's Grace");
            Tooltip.SetDefault("Summons a trail of energy at your cursor position as long as you hold left click\nOccasionally leaves behind a fountain of souls\nTakes up half a minion slot");
        }


        public override void SetDefaults() {
            item.damage = 67;
            item.summon = true;
            item.mana = 3;
            item.width = 44;
            item.height = 48;
            item.useTime = 5;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            Item.staff[item.type] = true;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = 60000;
            item.rare = 8;
            item.UseSound = SoundID.Item66;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<BirdSpiritPortal>();
            item.shootSpeed = 13f;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "WorshipCrystal", 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            Vector2 mouse = new Vector2(Main.mouseX, Main.mouseY) + Main.screenPosition;
            Terraria.Projectile.NewProjectile(mouse.X, mouse.Y, 0f, 0f, type, damage, knockBack, player.whoAmI);
            return false;
        }
    }
}