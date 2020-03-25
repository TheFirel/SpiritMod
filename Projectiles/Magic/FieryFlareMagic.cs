using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
	public class FieryFlareMagic : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slag Flare");
		}

		public override void SetDefaults()
		{
			projectile.width = 2;
			projectile.height = 2;
			aiType = ProjectileID.Flames;
			projectile.alpha = 255;
			projectile.timeLeft = 120;
			projectile.penetrate = 2;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.extraUpdates = 12;
		}

		public override void AI()
		{
			projectile.rotation += 0.1f;
            for (int i = 0; i < 2; i++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * 1.5f, projectile.velocity.Y * 1.5f);
				Main.dust[dust].scale = .9f;
                Main.dust[dust].noGravity = true;
                Main.dust[dust].fadeIn += .25f;
                int dust1 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * 1.5f, projectile.velocity.Y * 1.5f);
                Main.dust[dust1].scale = 1.6f;
                Main.dust[dust1].noGravity = true;
                Main.dust[dust].fadeIn += .25f;
            }
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			for (int j = 0; j < 8; j++)
			{
				int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 127, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
				Main.dust[dust].scale = .85f;
			}
            if (Main.rand.Next(6) == 2)
                target.AddBuff(BuffID.OnFire, 180);
            if (Main.rand.Next(4) == 0)
            {
                int n = 4;
                int deviation = Main.rand.Next(0, 300);
                for (int i = 0; i < n; i++)
                {
                    float rotation = MathHelper.ToRadians(270 / n * i + deviation);
                    Vector2 perturbedSpeed = new Vector2(projectile.velocity.X, projectile.velocity.Y).RotatedBy(rotation);
                    perturbedSpeed.Normalize();
                    perturbedSpeed.X *= 2.5f;
                    perturbedSpeed.Y *= 2.5f;
                    Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, 504, projectile.damage / 2, 2, projectile.owner);
                }
            }
        }
    }
}
