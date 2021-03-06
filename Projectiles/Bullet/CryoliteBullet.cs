using Microsoft.Xna.Framework;
using SpiritMod.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Bullet
{
    public class CryoliteBullet : ModProjectile
    {
        public static int _type;

        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cryolite Bullet");
        }

        public override void SetDefaults() {
            projectile.width = 2;
            projectile.height = 2;
            aiType = ProjectileID.Bullet;
            projectile.alpha = 255;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.ranged = true;
        }

        public override void AI() {
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
            {
                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 68, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 180, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity *= 0.6f;
                Main.dust[dust2].velocity *= 0.1f;
                Main.dust[dust2].scale = 1.2f;
                Main.dust[dust].scale = .8f;
            }
            for(int i = 0; i < 4; i++) {
                float x = projectile.Center.X - projectile.velocity.X / 10f * (float)i;
                float y = projectile.Center.Y - projectile.velocity.Y / 10f * (float)i;
                int num = Dust.NewDust(new Vector2(x, y), 2, 2, 180);
                Main.dust[num].velocity = Vector2.Zero;
                Main.dust[num].noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if(Main.rand.Next(2) == 0)
                target.AddBuff(ModContent.BuffType<CryoCrush>(), 300, true);
        }

        public override void Kill(int timeLeft) {
            Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 14);
            Projectile.NewProjectile(projectile.Center, Vector2.Zero,
                CryoFire._type, projectile.damage, projectile.knockBack, projectile.owner);

            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
            projectile.width = 30;
            projectile.height = 30;
            projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
            projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);

            for(int num621 = 0; num621 < 20; num621++) {
                int num622 = Dust.NewDust(projectile.position, projectile.width, projectile.height,
                    68, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num622].velocity *= 3f;
                if(Main.rand.Next(2) == 0) {
                    Main.dust[num622].scale = 0.5f;
                    Main.dust[num622].fadeIn = 1f + (float)Main.rand.Next(10) * 0.1f;
                }
            }
            for(int num623 = 0; num623 < 40; num623++) {
                int num624 = Dust.NewDust(projectile.position, projectile.width, projectile.height,
                    68, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num624].noGravity = true;
                Main.dust[num624].velocity *= 5f;
                num624 = Dust.NewDust(projectile.position, projectile.width, projectile.height,
                    68, 0f, 0f, 100, default(Color), 1f);
                Main.dust[num624].velocity *= 2f;
            }
        }

    }
}
