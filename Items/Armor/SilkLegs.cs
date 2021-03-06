using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class SilkLegs : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Manasilk Leggings");
            Tooltip.SetDefault("Increases minion damage by 1");

        }
        public override void SetDefaults() {
            item.width = 26;
            item.height = 18;
            item.value = 1000;
            item.rare = 1;
            item.defense = 1;
        }

        public override void UpdateEquip(Player player) {
            player.GetSpiritPlayer().silkenLegs = true;
        }

        public override void AddRecipes()  //How to craft this item
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddRecipeGroup("GoldBars");
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.Anvils);   //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}