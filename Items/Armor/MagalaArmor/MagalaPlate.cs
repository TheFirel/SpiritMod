using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.MagalaArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class MagalaPlate : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Gore Magala Plate");

        }


        int timer = 0;

        public override void SetDefaults() {
            item.width = 22;
            item.height = 20;
            item.value = 3000;
            item.rare = 5;
            item.vanity = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MagalaScale", 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
