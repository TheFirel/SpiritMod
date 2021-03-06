﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summon.LaserGate
{
    public class GateLaser : ModProjectile
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Gate Laser");
        }

        public override void SetDefaults() {
            projectile.hostile = false;
            projectile.width = 1;
            projectile.height = 1;
            projectile.aiStyle = -1;
            projectile.friendly = true;
            projectile.damage = 1;
            projectile.penetrate = 8;
            projectile.alpha = 255;
            projectile.timeLeft = 1;
            projectile.tileCollide = true;
            projectile.extraUpdates = 7;
        }


        private void Trail(Vector2 from, Vector2 to) {
            float distance = Vector2.Distance(from, to);
            float step = 1 / distance;
            for(float w = 0; w < distance; w += 4) {
                Dust.NewDustPerfect(Vector2.Lerp(from, to, w * step), 226, Vector2.Zero).noGravity = true;
            }
        }
        public override bool PreAI() {
            Trail(projectile.position, projectile.position + projectile.velocity);
            return true;
        }

    }
}