using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.ClatterboneArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ClatterboneLeggings : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Clatterbone Greaves");
        }
        public override void SetDefaults() {
            item.width = 34;
            item.height = 30;
            item.value = 5000;
            item.rare = 2;

            item.defense = 6;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "Carapace", 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
