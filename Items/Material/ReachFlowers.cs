using Terraria.ModLoader;

namespace SpiritMod.Items.Material
{
    public class ReachFlowers : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bloodflower");
            Tooltip.SetDefault("'Who knew flowers could bleed?'");
        }


        public override void SetDefaults() {
            item.width = 24;
            item.height = 30;
            item.value = 100;
            item.rare = 2;

            item.maxStack = 999;
        }
    }
}