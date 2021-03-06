using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Armor.MarbleArmor
{
    [AutoloadEquip(EquipType.Legs)]
    public class MarbleLegs : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Gilded Treads");
            Tooltip.SetDefault("Increases movement speed by 6%\nLeave a bright trail of light as you walk");

        }
        public override void SetDefaults() {
            item.width = 28;
            item.height = 24;
            item.value = 15100;
            item.rare = 2;
            item.defense = 4;
        }
        public override void UpdateEquip(Player player) {
            player.maxRunSpeed += 0.06f;
            if(player.velocity.X != 0f) {
                int dust = Dust.NewDust(new Vector2(player.position.X, player.position.Y + player.height - 4f), player.width, 0, DustID.GoldCoin);
                Main.dust[dust].velocity *= 0f;
                Main.dust[dust].noGravity = true;
            }
        }

        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MarbleChunk", 13);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
