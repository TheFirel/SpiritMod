
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Items.Accessory
{
    public class ManaFlame : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Lunar Wisp");
            Tooltip.SetDefault("You emit light at nighttime\nReduces mana cost by 5% at nighttime");

        }


        public override void SetDefaults() {
            item.width = 18;
            item.height = 18;
            item.value = Item.buyPrice(0, 4, 0, 0);
            item.rare = 1;
            item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual) {
            if(!Main.dayTime) {
                Lighting.AddLight(player.position, 0.0f, .75f, 1.25f);
                player.manaCost -= 0.05f;
            }
        }
    }
}
