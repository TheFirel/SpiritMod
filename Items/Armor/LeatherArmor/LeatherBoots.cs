using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.LeatherArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class LeatherLegs : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Marksman's Boots");
        }
        public override void SetDefaults() {
            item.width = 22;
            item.height = 18;
            item.value = 100;
            item.rare = 1;
            item.defense = 1;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OldLeather", 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
