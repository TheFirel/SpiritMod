using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.LeatherArmor
{
    [AutoloadEquip(EquipType.Body)]
    public class LeatherPlate : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Marksman's Plate");
        }
        public override void SetDefaults() {
            item.width = 30;
            item.height = 18;
            item.value = 100;
            item.rare = 1;
            item.defense = 2;
        }
        public override void DrawHands(ref bool drawHands, ref bool drawArms) {
            drawHands = true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "OldLeather", 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
