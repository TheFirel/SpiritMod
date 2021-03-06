
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class Angelure : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Anglure");
            Tooltip.SetDefault("All ranged projectiles emit light\nRanged projectiles may engulf foes in light\nIncreases ranged critical strike chance by 5%");

        }


        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 5;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetSpiritPlayer().anglure = true;
            player.rangedCrit += 5;
        }
    }
}
