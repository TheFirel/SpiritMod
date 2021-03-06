using SpiritMod.Buffs.Summon;
using SpiritMod.Projectiles.Summon;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Items.DonatorItems
{
    public class DungeonSoulStaff : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Dungeon Soul Staff");
            Tooltip.SetDefault("Summons a friendly Dungeon Spirit to latch on to your foes");

        }


        public override void SetDefaults() {
            item.width = 26;
            item.height = 28;
            item.value = Item.sellPrice(0, 2, 0, 0);
            item.rare = 8;
            item.mana = 11;
            item.damage = 48;
            item.knockBack = 1;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 30;
            item.useAnimation = 30;
            item.summon = true;
            item.noMelee = true;
            item.shoot = ModContent.ProjectileType<DungeonSummon>();
            item.buffType = ModContent.BuffType<DungeonSummonBuff>();
            item.buffTime = 3600;
            item.UseSound = SoundID.Item44;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "SpiritStaff", 1);
            recipe.AddIngredient(null, "SpiritBar", 4);
            recipe.AddIngredient(ItemID.Ectoplasm, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}