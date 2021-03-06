using Microsoft.Xna.Framework;
using SpiritMod.Buffs;
using System;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles
{
    public class ClampOrb : ModProjectile
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Clamper Orb");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 9;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults() {
            projectile.width = 6;
            projectile.height = 6;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.penetrate = -2;
            projectile.tileCollide = false;
            projectile.alpha = 255;
            projectile.timeLeft = 500;
            projectile.light = 0;
            projectile.extraUpdates = 1;
        }

        int timer = 120;
        Vector2 offset = new Vector2(30, 30);
        public override void AI() {
            var list = Main.projectile.Where(x => x.Hitbox.Intersects(projectile.Hitbox));
            foreach(var proj in list) {
                if(projectile != proj && proj.hostile)
                    proj.Kill();

                Player player = Main.player[projectile.owner];
                projectile.ai[0] += .02f;
                projectile.Center = player.Center + offset.RotatedBy(projectile.ai[0] + projectile.ai[1] * (Math.PI * 10 / 1));

                int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 108, 0f, 0f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].scale = 0.9f;
                projectile.rotation = projectile.velocity.ToRotation() + (float)(Math.PI / 2);
            }
        }

        public override void Kill(int timeLeft) {
            for(int i = 0; i < 5; i++) {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 108);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if(Main.rand.Next(5) == 2)
                target.AddBuff(ModContent.BuffType<Brine>(), 180);
        }

        //public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        //{
        //    Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
        //    for (int k = 0; k < projectile.oldPos.Length; k++)
        //    {
        //        Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
        //        Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
        //        spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
        //    }
        //    return true;
        //}

    }
}