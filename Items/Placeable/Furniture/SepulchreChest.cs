using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Placeable.Furniture
{
    public class SepulchreChest : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sepulchre Chest");
        }


        public override void SetDefaults() {
            item.width = 32;
            item.height = 28;
            item.value = 500;

            item.maxStack = 99;
            item.rare = 2;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

            item.createTile = mod.TileType("SepulchreChestTile1");
        }
    }
}