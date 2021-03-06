using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Summon
{
    public class Cthulhu : ModProjectile
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Cthulhu");
            ProjectileID.Sets.MinionSacrificable[base.projectile.type] = true;
            ProjectileID.Sets.Homing[base.projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
        }

        public override void SetDefaults() {
            projectile.CloneDefaults(ProjectileID.Spazmamini);
            projectile.width = 30;
            projectile.height = 30;
            projectile.minion = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = true;
            projectile.netImportant = true;
            aiType = ProjectileID.Spazmamini;
            projectile.alpha = 0;
            projectile.penetrate = -10;
            projectile.timeLeft = 18000;
            projectile.minionSlots = 1;
        }

        public override bool OnTileCollide(Vector2 oldVelocity) {
            if(projectile.penetrate == 0)
                projectile.Kill();

            return false;
        }

        public override void AI() {
            bool flag64 = projectile.type == ModContent.ProjectileType<Cthulhu>();
            Player player = Main.player[projectile.owner];
            MyPlayer modPlayer = player.GetSpiritPlayer();
            if(flag64) {
                if(player.dead)
                    modPlayer.cthulhuMinion = false;

                if(modPlayer.cthulhuMinion)
                    projectile.timeLeft = 2;

            }
            Dust.NewDust(projectile.position, projectile.width, projectile.height, 173);
        }

        public override bool MinionContactDamage() {
            return true;
        }

    }
}