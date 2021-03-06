
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class ChaosCrystal : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Chaos Crystal");
            Tooltip.SetDefault("Getting hit has a chance to teleport you to somewhere nearby");
        }


        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 5, 0, 0);
            item.rare = 4;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
            player.GetSpiritPlayer().ChaosCrystal = true;
        }

    }
}
