using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Yoyo
{
	public class Tao : ModItem
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Taoyo");
			Tooltip.SetDefault("May confuse foes\n'But it keeps your mind clear'");
		}


        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodYoyo);
            item.damage = 45;
            item.value = Terraria.Item.sellPrice(0, 4, 0, 0);
            item.rare = 5;
            item.knockBack = 2;
            item.channel = true;
            item.useStyle = 5;
            item.useAnimation = 25;
            item.useTime = 23;
            item.shoot = mod.ProjectileType("TaoP");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkShard, 1);
            recipe.AddIngredient(ItemID.LightShard, 1);
            recipe.AddIngredient(ItemID.SoulofLight, 5);
            recipe.AddIngredient(ItemID.SoulofNight, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
