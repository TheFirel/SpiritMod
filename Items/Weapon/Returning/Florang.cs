using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Returning
{
    public class Florang : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Florarang");
            Tooltip.SetDefault("Vines occasionally ensnare the foes, reducing their movement speed \n'Sharp as a razorleaf'");
        }


        public override void SetDefaults() {
            item.damage = 23;
            item.melee = true;
            item.width = 44;
            item.height = 40;
            item.useTime = 19;
            item.useAnimation = 19;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.knockBack = 3;
            item.value = Terraria.Item.sellPrice(0, 0, 15, 0);
            item.rare = 2;
            item.shootSpeed = 13f;
            item.shoot = mod.ProjectileType("FloraP");
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }
        public override bool CanUseItem(Player player)       //this make that you can shoot only 1 boomerang at once
        {
            for(int i = 0; i < 1000; ++i) {
                if(Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot) {
                    return false;
                }
            }
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "FloranBar", 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}