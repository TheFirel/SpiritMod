using Microsoft.Xna.Framework;
using SpiritMod.Projectiles.Arrow;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class MarbleBow : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Gilded Longbow");
            Tooltip.SetDefault("Shoots heavy arrows that shatter upon hitting enemies or tiles");
        }



        public override void SetDefaults() {
            item.damage = 21;
            item.noMelee = true;
            item.ranged = true;
            item.width = 22;
            item.height = 46;
            item.useTime = 37;
            item.useAnimation = 37;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = 1;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 1;
            item.value = Terraria.Item.sellPrice(0, 0, 50, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.useTurn = false;
            item.shootSpeed = 6.2f;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            type = ModContent.ProjectileType<MarbleLongbowArrow>();
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MarbleChunk", 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}