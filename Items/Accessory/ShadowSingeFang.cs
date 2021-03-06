
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class ShadowSingeFang : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Shadow-Singed Fang");
            Tooltip.SetDefault("Increases critical strike chance by 4%\nThis effect is doubled at nighttime or while underground\nAttacking enemies that have less than half health may strike them with shadows\nThis effect costs the player some life");
        }


        public override void SetDefaults() {
            item.width = 48;
            item.height = 49;
            item.value = Item.sellPrice(0, 0, 76, 0);
            item.rare = 2;

            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetSpiritPlayer().shadowFang = true;
            player.magicCrit += 4;
            player.meleeCrit += 4;
            player.rangedCrit += 4;
            if(player.ZoneRockLayerHeight || player.ZoneUnderworldHeight || !Main.dayTime) {
                player.magicCrit += 4;
                player.meleeCrit += 4;
                player.rangedCrit += 4;
            }
        }
    }
}
