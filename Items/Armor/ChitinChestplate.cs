using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ChitinChestplate : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chitin Chestplate");

        }
        public override void SetDefaults() {
            item.width = 30;
            item.height = 20;
            item.value = 22000;
            item.rare = 1;
            item.defense = 4;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Chitin", 14);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
