using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpiritMod.Projectiles.Arrow;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Items.Weapon.Bow
{
    public class GraniteBow : ModItem
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Unstable Boltcaster");
            Tooltip.SetDefault("Converts arrows into Unstable Bolts which stick to hit enemies\nKilling stuck enemies causes them to explode into damaging energy wisps");
            SpiritGlowmask.AddGlowMask(item.type, "SpiritMod/Items/Weapon/Bow/GraniteBow_Glow");
        }
        public override void SetDefaults() {
            item.damage = 23;
            item.noMelee = true;
            item.ranged = true;
            item.width = 54;
            item.height = 20;
            item.useTime = 35;
            item.useAnimation = 35;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = 3;
            item.useAmmo = AmmoID.Arrow;
            item.knockBack = 3;
            item.value = Terraria.Item.sellPrice(0, 1, 0, 0);
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.autoReuse = false;
            item.shootSpeed = 14f;

        }
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI) {
            Lighting.AddLight(item.position, 0.08f, .12f, .52f);
            Texture2D texture;
            texture = Main.itemTexture[item.type];
            spriteBatch.Draw
            (
                mod.GetTexture("Items/Weapon/Bow/GraniteBow_Glow"),
                new Vector2
                (
                    item.position.X - Main.screenPosition.X + item.width * 0.5f,
                    item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );
        }
        public override Vector2? HoldoutOffset() {
            return new Vector2(-4, 0);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
            type = ModContent.ProjectileType<GraniteRepeaterArrow>();
            return true;
        }
        public override void AddRecipes() {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "GraniteChunk", 16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}