using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Halloween
{
    public class CandyBowl : ModItem
    {
        public static int _type;

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Candy Bowl");
        }


        public override void SetDefaults() {
            item.width = 32;
            item.height = 28;
            item.value = 200000;

            item.maxStack = 99;

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 15;

            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;

            item.createTile = ModContent.TileType<Tiles.Furniture.CandyBowl>();
        }
    }
}