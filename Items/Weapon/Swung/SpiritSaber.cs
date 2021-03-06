using Microsoft.Xna.Framework;
using SpiritMod.Items.Material;
using SpiritMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Swung
{
    public class SpiritSaber : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Spirit Saber");
            Tooltip.SetDefault("Shoots out a homing bolt of Souls that inflicts Soul Burn");
        }


        public override void SetDefaults() {
            item.width = 36;
            item.height = 38;
            item.value = Item.sellPrice(0, 3, 0, 0);
            item.rare = 5;
            item.crit += 4;
            item.damage = 44;
            item.knockBack = 5f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 26;
            item.useAnimation = 26;
            item.melee = true;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<SoulSpirit>();
            item.shootSpeed = 12f;
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes() {
            ModRecipe modRecipe = new ModRecipe(mod);
            modRecipe.AddIngredient(ModContent.ItemType<SpiritBar>(), 12);
            modRecipe.AddIngredient(ModContent.ItemType<SoulShred>(), 6);
            modRecipe.AddTile(TileID.MythrilAnvil);
            modRecipe.SetResult(this, 1);
            modRecipe.AddRecipe();
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
            if(Main.rand.Next(2) == 0) {
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 68);
            }
        }
    }
}
