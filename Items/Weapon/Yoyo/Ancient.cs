using SpiritMod.Projectiles.Yoyo;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Yoyo
{
    public class Ancient : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Ancient");
            Tooltip.SetDefault("Shoots a cluster of Ancient Ice");
        }



        public override void SetDefaults() {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.damage = 104;
            item.value = Terraria.Item.sellPrice(0, 15, 0, 0);
            item.rare = 10;
            item.knockBack = 3;
            item.channel = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 28;
            item.useTime = 25;
            item.shoot = ModContent.ProjectileType<AncientP>();
        }
    }
}