using SpiritMod.Buffs.Potion;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Consumable.Potion
{
    public class MushroomPotion : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Sporecoid Potion");
            Tooltip.SetDefault("Causes the player to leave behind a damaging trail of mushrooms");
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

            item.buffType = ModContent.BuffType<MushroomPotionBuff>();
            item.buffTime = 7300;

            item.UseSound = SoundID.Item3;
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GlowRoot", 1);
            recipe.AddIngredient(ItemID.GlowingMushroom, 1);
            recipe.AddIngredient(ItemID.Moonglow, 1);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddTile(TileID.Bottles);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
