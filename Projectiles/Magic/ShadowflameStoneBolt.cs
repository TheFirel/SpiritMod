﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpiritMod.Items.Weapon.Magic;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.Projectiles.Magic
{
    public class ShadowflameStoneBolt : ModProjectile
    {
        public const float TURNRATE = (float)(0.4 * Math.PI / 30d);
        public const float OFFSET = 50;
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Shadowbreak Wisp");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }

        public override void SetDefaults() {
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
            projectile.height = 12;
            projectile.width = 12;
            projectile.tileCollide = false;
        }

        public float Offset {
            get { return projectile.ai[0]; }
            set { projectile.ai[0] = value; }
        }

        public Vector2 Target =>
            new Vector2(-projectile.ai[0], -projectile.ai[1]);

        public override void AI() {
            Player player = Main.player[projectile.owner];
            if(Main.player[projectile.owner].channel) {
                projectile.timeLeft -= 2;
                if(projectile.timeLeft <= 170) {
                    projectile.tileCollide = true;
                }
                if(projectile.timeLeft <= 0) {
                    projectile.Kill();
                    player.GetSpiritPlayer().shadowCount = 0;
                }
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + 1.57f;
                float num2353 = 10f;
                Vector2 vector329 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                float num2352 = (float)Main.mouseX + Main.screenPosition.X - vector329.X;
                float num2351 = (float)Main.mouseY + Main.screenPosition.Y - vector329.Y;
                if(Main.player[projectile.owner].gravDir == -1f) {
                    num2351 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector329.Y;
                }
                float num2350 = (float)Math.Sqrt((double)(num2352 * num2352 + num2351 * num2351));
                num2350 = (float)Math.Sqrt((double)(num2352 * num2352 + num2351 * num2351));
                if(projectile.ai[0] < 0f) {
                    projectile.ai[0] += 1f;
                }
                if(projectile.type == 491 && num2350 < 100f) {
                    if(projectile.velocity.Length() < num2353) {
                        projectile.velocity *= 1.1f;
                        if(projectile.velocity.Length() > num2353) {
                            projectile.velocity.Normalize();
                            projectile.velocity *= num2353;
                        }
                    }
                    if(projectile.ai[0] == 0f) {
                        projectile.ai[0] = -10f;
                    }
                } else if(num2350 > num2353) {
                    num2350 = num2353 / num2350;
                    num2352 *= num2350;
                    num2351 *= num2350;
                    int num2345 = (int)(num2352 * 1000f);
                    int num2344 = (int)(projectile.velocity.X * 1000f);
                    int num2343 = (int)(num2351 * 1000f);
                    int num2342 = (int)(projectile.velocity.Y * 1000f);
                    if(num2345 != num2344 || num2343 != num2342) {
                        projectile.netUpdate = true;
                    }
                    if(projectile.type == 491) {
                        Vector2 value167 = new Vector2(num2352, num2351);
                        projectile.velocity = (projectile.velocity * 4f + value167) / 5f;
                    } else {
                        projectile.velocity.X = num2352;
                        projectile.velocity.Y = num2351;
                    }
                } else {
                    int num2341 = (int)(num2352 * 1000f);
                    int num2340 = (int)(projectile.velocity.X * 1000f);
                    int num2339 = (int)(num2351 * 1000f);
                    int num2338 = (int)(projectile.velocity.Y * 1000f);
                    if(num2341 != num2340 || num2339 != num2338) {
                        projectile.netUpdate = true;
                    }
                    projectile.velocity.X = num2352;
                    projectile.velocity.Y = num2351;
                }
            } else if(projectile.ai[0] <= 0f) {
                projectile.netUpdate = true;
                if(projectile.type != 491) {
                    float num2337 = 12f;
                    Vector2 vector328 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    float num2336 = (float)Main.mouseX + Main.screenPosition.X - vector328.X;
                    float num2335 = (float)Main.mouseY + Main.screenPosition.Y - vector328.Y;
                    if(Main.player[projectile.owner].gravDir == -1f) {
                        num2335 = Main.screenPosition.Y + (float)Main.screenHeight - (float)Main.mouseY - vector328.Y;
                    }
                    float num2334 = (float)Math.Sqrt((double)(num2336 * num2336 + num2335 * num2335));
                    if(num2334 == 0f || projectile.ai[0] < 0f) {
                        vector328 = new Vector2(Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2), Main.player[projectile.owner].position.Y + (float)(Main.player[projectile.owner].height / 2));
                        num2336 = projectile.position.X + (float)projectile.width * 0.5f - vector328.X;
                        num2335 = projectile.position.Y + (float)projectile.height * 0.5f - vector328.Y;
                        num2334 = (float)Math.Sqrt((double)(num2336 * num2336 + num2335 * num2335));
                    }
                    num2334 = num2337 / num2334;
                    num2336 *= num2334;
                    num2335 *= num2334;
                    projectile.velocity.X = num2336;
                    projectile.velocity.Y = num2335;
                    if(projectile.velocity.X == 0f && projectile.velocity.Y == 0f) {
                        projectile.Kill();
                    }
                }
                projectile.ai[0] = 1f;
            } else if(player.active && Offset >= 0) {
                projectile.tileCollide = false;
                projectile.penetrate = 1;
                MyPlayer modPlayer = player.GetSpiritPlayer();
                if(player.whoAmI == Main.myPlayer && player.inventory[player.selectedItem].type != ModContent.ItemType<ShadowflameStoneStaff>()) {
                    projectile.Kill();
                    player.GetSpiritPlayer().shadowCount = 0;
                    return;
                }

                projectile.timeLeft = 300;
                modPlayer.shadowTally++;
                int count = modPlayer.shadowCount;
                float sector = MathHelper.TwoPi / (count > 0 ? count : 1);
                float rotation = modPlayer.shadowRotation + Offset * sector;
                if(rotation > MathHelper.TwoPi)
                    rotation -= MathHelper.TwoPi;
                float delta = projectile.rotation;
                if(delta > MathHelper.Pi)
                    delta -= MathHelper.TwoPi;
                else if(delta < -MathHelper.Pi)
                    delta += MathHelper.TwoPi;
                delta = rotation - delta;
                if(delta > MathHelper.Pi)
                    delta -= MathHelper.TwoPi;
                else if(delta < -MathHelper.Pi)
                    delta += MathHelper.TwoPi;
                if(delta > 1.5 * TURNRATE)
                    projectile.rotation += 1.5f * TURNRATE;
                else if(delta < .5 * TURNRATE)
                    projectile.rotation += 0.5f * TURNRATE;
                else
                    projectile.rotation = rotation;
                projectile.Center = player.MountedCenter + new Vector2(0, -OFFSET).RotatedBy(projectile.rotation);
                return;
            }
        }

        public override void Kill(int timeLeft) {
            for(int i = 0; i < 10; i++) {
                int num = Dust.NewDust(projectile.position, projectile.width, projectile.height, 173, 0f, -2f, 0, default(Color), .9f);
                Main.dust[num].noGravity = true;
                Dust expr_62_cp_0 = Main.dust[num];
                expr_62_cp_0.position.X = expr_62_cp_0.position.X + ((float)(Main.rand.Next(-10, 11) / 20) - 1.5f);
                Dust expr_92_cp_0 = Main.dust[num];
                expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + ((float)(Main.rand.Next(-10, 11) / 20) - 1.5f);
                if(Main.dust[num].position != projectile.Center) {
                    Main.dust[num].velocity = projectile.DirectionTo(Main.dust[num].position) * 6f;
                }
            }
            Player player = Main.player[projectile.owner];
            if(player.active && Offset >= 0)
                player.GetModPlayer<MyPlayer>().shadowCount--;
        }
        public override bool OnTileCollide(Vector2 oldVelocity) {
            if(projectile.tileCollide = true) {
                Main.PlaySound(4, (int)projectile.position.X, (int)projectile.position.Y, 6);
            }
            return true;
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
            Player player = Main.player[projectile.owner];
            if(player.active && Offset >= 0)
                hitDirection = target.position.X + (target.width >> 1) - player.position.X - (player.width >> 1) > 0 ? 1 : -1;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) {
            if(Main.rand.Next(6) == 0)
                target.AddBuff(BuffID.ShadowFlame, 85);
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for(int k = 0; k < projectile.oldPos.Length; k++) {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
        public override Color? GetAlpha(Color lightColor) {
            return new Color(190, 79, 252, 100);
        }
    }
}
