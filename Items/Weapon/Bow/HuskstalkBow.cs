using Microsoft.Xna.Framework;
using SpiritMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class HuskstalkBow : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Huskstalk Bow");
            Tooltip.SetDefault("Arrows shot inflict Withering Leaf");
        }



        public override void SetDefaults() {
            item.damage = 12;
            item.noMelee = true;
            item.ranged = true;
            item.width = 20;
            item.height = 38;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 3;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.value = Item.sellPrice(0, 0, 12, 0);
            item.autoReuse = false;
            item.shootSpeed = 7f;


        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            int p = Projectile.NewProjectile(position.X, position.Y, speedX, speedY, type, damage, knockBack, player.whoAmI);
            Main.projectile[p].GetGlobalProjectile<SpiritGlobalProjectile>().WitherLeaf = true;
            return false;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AncientBark", 6);
            recipe.AddIngredient(null, "EnchantedLeaf", 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}