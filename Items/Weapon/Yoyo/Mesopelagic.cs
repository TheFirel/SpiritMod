using SpiritMod.Projectiles.Yoyo;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Yoyo
{
    public class Mesopelagic : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("The Mesopelagic");
            Tooltip.SetDefault("Occasionally explodes into seawater on enemy hits, damaging nearby foes");
        }



        public override void SetDefaults() {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.damage = 50;
            item.value = Terraria.Item.sellPrice(0, 1, 80, 0);
            item.rare = 5;
            item.knockBack = 1;
            item.channel = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 25;
            item.useTime = 25;
            item.shoot = ModContent.ProjectileType<MesopelagicProj>();
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DepthShard", 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}