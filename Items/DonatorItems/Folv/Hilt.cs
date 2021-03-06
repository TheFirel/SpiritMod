using Terraria.ModLoader;

namespace SpiritMod.Items.DonatorItems.Folv
{
    public class Hilt : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ancient Hilt");
            Tooltip.SetDefault("'A hilt of aeons past'");
        }


        public override void SetDefaults() {
            item.width = 28;
            item.height = 30;
            item.maxStack = 999;
            item.rare = 8;
        }
    }
}
