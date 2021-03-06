using Terraria.ID;
using Terraria.ModLoader;
using TreemanStatueTile = SpiritMod.Tiles.Furniture.Reach.TreemanStatue;

namespace SpiritMod.Items.Placeable.Furniture.Reach
{
    public class TreemanStatue : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Statue of the Old Gods");
            Tooltip.SetDefault("Provides the effects of a Workbench, Potion Crafting Station, and Bookcase\n'The Old Ones will protect you'");

        }


        public override void SetDefaults() {
            item.width = 32;
            item.height = 28;
            item.value = 25500;

            item.maxStack = 99;
            item.rare = 3;

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

            item.createTile = ModContent.TileType<TreemanStatueTile>();
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "AncientBark", 50);
            recipe.AddIngredient(null, "EnchantedLeaf", 20);
            recipe.AddIngredient(ItemID.GoldCoin, 10);
            recipe.AddIngredient(ItemID.Book, 5);
            recipe.AddIngredient(ItemID.Bone, 5);
            recipe.AddTile(null, "CreationAltarTile");
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}