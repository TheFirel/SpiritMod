using Microsoft.Xna.Framework;
using SpiritMod.Buffs;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Sword
{

    public class BismiteSwordProjectile : ModProjectile
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Bismite Shard");
        }

        public override void SetDefaults() {
            projectile.width = 10;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.tileCollide = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true;
        }

        public override void AI() {
            projectile.rotation = projectile.velocity.ToRotation() + 1.57f;
            int dust = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 167, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            int dust2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 167, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust2].noGravity = true;
            Main.dust[dust2].velocity *= 0f;
            Main.dust[dust2].velocity *= 0f;
            Main.dust[dust2].scale = 0.9f;
            Main.dust[dust].scale = 0.9f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
            Main.PlaySound(new Terraria.Audio.LegacySoundStyle(0, 1));
            return true;
        }
        public override void Kill(int timeLeft) {
            for(int i = 0; i < 10; i++) {
                Dust.NewDust(projectile.position, projectile.width, projectile.height, 167);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if(Main.rand.Next(5) == 0)
                target.AddBuff(ModContent.BuffType<FesteringWounds>(), 180);
        }

    }
}