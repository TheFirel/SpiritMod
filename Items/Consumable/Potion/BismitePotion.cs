using SpiritMod.Buffs.Potion;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable.Potion
{
    public class BismitePotion : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Toxin Potion");
            Tooltip.SetDefault("Critical strikes may Poison hit foes\nIncreases critical strike chance by 4%");
        }


        public override void SetDefaults() {
            item.width = 20;
            item.height = 30;
            item.rare = 1;
            item.maxStack = 30;

            item.useStyle = 2;
            item.useTime = item.useAnimation = 20;

            item.consumable = true;
            item.autoReuse = false;

            item.buffType = ModContent.BuffType<BismitePotionBuff>();
            item.buffTime = 14400;

            item.UseSound = SoundID.Item3;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BismiteCrystal", 1);
            recipe.AddIngredient(null, "ReachFishingCatch", 1);
            recipe.AddIngredient(ItemID.Waterleaf, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
