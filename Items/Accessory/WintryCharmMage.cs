
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class WintryCharmMage : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Wintry Charm");
            Tooltip.SetDefault("Magic attacks may slow down hit enemies\nThis effect does not apply to bosses");

        }


        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 2, 0, 0);
            item.rare = 1;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetSpiritPlayer().winterbornCharmMage = true;
        }
    }
}
