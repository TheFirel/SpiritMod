﻿using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpiritMod.Projectiles;
using Terraria.Graphics.Shaders;
using Terraria.World.Generation;
using Microsoft.Xna.Framework.Graphics;
using SpiritMod.Projectiles.Boss;
using Terraria.GameContent.Generation;
using SpiritMod.Tiles;
using SpiritMod;
using SpiritMod.Effects;

namespace SpiritMod.NPCs.Boss.SteamRaider
{
	[AutoloadBossHead]
	public class SteamRaiderHead : ModNPC
	{
		public static int _type;

		int timer = 20;
		public bool flies = true;
		public bool directional = false;
		public float speed = 10.5f;
		public float turnSpeed = 0.19f;
		public bool tail = false;
		public int minLength = 46;
        public int midLength = 48;
        public int maxLength = 49;
        public bool spawnedProbes = false;
		bool charging = true;
		int crashY = 1000;
		int musicTimer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Starplate Voyager");
		}

		public override void SetDefaults()
		{
			npc.damage = 25; //150
			npc.npcSlots = 20f;
			bossBag = mod.ItemType("SteamRaiderBag");
			npc.width = 64; //324
			npc.height = 56; //216
			npc.defense = 0;
			npc.lifeMax = 8300; //250000 //new
			Main.npcFrameCount[npc.type] = 1; //new //new
			animationType = 10; //new
			npc.knockBackResist = 0f;
			npc.boss = true;
			npc.value = 40000;
			npc.alpha = 255;
			npc.behindTiles = true;
			npc.noGravity = true;
			npc.noTileCollide = true;
			npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = SoundID.NPCDeath14;
			npc.netAlways = true;
			music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Starplate");
			for (int k = 0; k < npc.buffImmune.Length; k++)
			{
				npc.buffImmune[k] = true;
			}
		}
		int chargetimer;
        int unstableprojtimer;
        bool charge;
		public override void AI()
		{
			Player player = Main.player[npc.target];
			/*if (crashY < npc.position.Y && charging)
			{
				 for (int i = 0; i < 40; i++)
                    {
                        int num = Dust.NewDust(npc.position, npc.width, npc.height, 226, 0f, -2f, 0, default(Color), 1.1f);
                        Main.dust[num].noGravity = true;
                        Dust expr_62_cp_0 = Main.dust[num];
                        expr_62_cp_0.position.X = expr_62_cp_0.position.X + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f);
                        Dust expr_92_cp_0 = Main.dust[num];
                        expr_92_cp_0.position.Y = expr_92_cp_0.position.Y + ((float)(Main.rand.Next(-30, 31) / 20) - 1.5f);
                        if (Main.dust[num].position != npc.Center)
                        {
                            Main.dust[num].velocity = npc.DirectionTo(Main.dust[num].position) * 20f;
                        }
                    }
					Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 89);
					Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 27);
					Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 14);
					charging = false;
			}
			if (charging)
			{
				npc.velocity.X = 0;
				npc.velocity.Y = 0;
				musicTimer++;
				if (musicTimer > 690) //change 720 if the music changes
				{
					npc.velocity.Y = 25;
					for (int i = 0; i < npc.height; i++)
					{
						if (Main.rand.Next(10) == 1)
						{
						int num = Dust.NewDust(new Vector2(npc.position.X + i, npc.Center.Y), 0, 0, 226);
						Main.dust[num].velocity.X = -10;
						Main.dust[num].velocity.Y = Main.rand.Next(-3,3);
						Main.dust[num].noGravity = true;
						
						num = Dust.NewDust(new Vector2(npc.position.X + i, npc.Center.Y), 0, 0, 226);
						Main.dust[num].velocity.X = 10;
						Main.dust[num].velocity.Y = Main.rand.Next(-3,3);
						Main.dust[num].noGravity = true;
						}
					}
				}
			}
            else
            {
                crashY = (int)player.position.Y + 48;
                npc.position.X = player.position.X;
                return;
            }*/
            bool expertMode = Main.expertMode;
			timer++;
			if ((timer == 100|| timer == 400) && npc.life > 1200)
			{
				if (Main.expertMode)
				{
					Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 91);
					Vector2 direction = Main.player[npc.target].Center - npc.Center;
					direction.Normalize();
					direction.X *= 2.5f;
					direction.Y *= 2.5f;

					int amountOfProjectiles = 1;
					for (int i = 0; i < amountOfProjectiles; ++i)
					{
						float A = (float)Main.rand.Next(-200, 200) * 0.05f;
						float B = (float)Main.rand.Next(-200, 200) * 0.05f;
						int damage = expertMode ? 18 : 25;
						Projectile.NewProjectile(npc.Center.X, npc.Center.Y, direction.X, direction.Y, mod.ProjectileType("SteamBeam"), damage, 0, Main.myPlayer, 0, 0);
					}
				}
			}
            if (timer == 600)
            {
                if (npc.life <= 5000 && npc.life > 1200)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        NPC.NewNPC((int)Main.player[npc.target].Center.X + Main.rand.Next(-700, 700), (int)Main.player[npc.target].Center.Y + Main.rand.Next(-700, 700), mod.NPCType("LaserBase"), npc.whoAmI);
                    }
                }
            }
			if (timer == 700)
				timer = 0;
			chargetimer++;
            if (npc.life >=1200)
            {
                npc.aiStyle = 6; //new
                aiType = -1;
                if (chargetimer == 700)
                {
                    Main.PlaySound(15, (int)npc.position.X, (int)npc.position.Y, 0);
                }
                if (chargetimer >= 700 && chargetimer <= 1000)
                {
                    charge = true;
                }
                else if (chargetimer >= 1001)
                {
                    charge = false;
                    chargetimer = 0;
                }
                Lighting.AddLight((int)((npc.position.X + (float)(npc.width / 2)) / 16f), (int)((npc.position.Y + (float)(npc.height / 2)) / 16f), 0f, 0.075f, 0.25f);
                if (npc.ai[3] > 0f)
                    npc.realLife = (int)npc.ai[3];

                if (npc.target < 0 || npc.target == 255 || player.dead)
                    npc.TargetClosest(true);

                npc.velocity.Length();
                if (npc.alpha != 0)
                {
                    for (int num934 = 0; num934 < 2; num934++)
                    {
                        int num935 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 226, 0f, 0f, 100, default(Color), 2f);
                        Main.dust[num935].noGravity = true;
                        Main.dust[num935].noLight = true;
                    }
                }
                npc.alpha -= 12;
                if (npc.alpha < 0)
                    npc.alpha = 0;

                if (Main.netMode != 1)
                {
                    if (!tail && npc.ai[0] == 0f)
                    {

                        int current = npc.whoAmI;
                        for (int num36 = 0; num36 < maxLength; num36++)
                        {
                            int trailing = 0;
                            if (num36 >= 0 && num36 < minLength)
                                trailing = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.height / 2), mod.NPCType("SteamRaiderBody"), npc.whoAmI);
                            else if (num36 >= minLength && num36 < midLength)
                                trailing = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.height / 2), mod.NPCType("SteamRaiderBody2"), npc.whoAmI);
                            else
                                trailing = NPC.NewNPC((int)npc.position.X + (npc.width / 2), (int)npc.position.Y + (npc.height / 2), mod.NPCType("SteamRaiderTail"), npc.whoAmI);

                            Main.npc[trailing].realLife = npc.whoAmI;
                            Main.npc[trailing].ai[2] = (float)npc.whoAmI;
                            Main.npc[trailing].ai[1] = (float)current;
                            Main.npc[current].ai[0] = (float)trailing;
                            npc.netUpdate = true;
                            current = trailing;
                        }
                        tail = true;
                    }
                    if (!npc.active && Main.netMode == 2)
                        NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f, 0f, 0f, 0, 0, 0);
                }

                int num180 = (int)(npc.position.X / 16f) - 1;
                int num181 = (int)((npc.position.X + (float)npc.width) / 16f) + 2;
                int num182 = (int)(npc.position.Y / 16f) - 1;
                int num183 = (int)((npc.position.Y + (float)npc.height) / 16f) + 2;
                if (num180 < 0)
                    num180 = 0;

                if (num181 > Main.maxTilesX)
                    num181 = Main.maxTilesX;

                if (num182 < 0)
                    num182 = 0;

                if (num183 > Main.maxTilesY)
                    num183 = Main.maxTilesY;

                bool flag94 = flies;
                npc.localAI[1] = 0f;
                if (directional)
                {
                    if (npc.velocity.X < 0f)
                        npc.spriteDirection = 1;

                    else if (npc.velocity.X > 0f)
                        npc.spriteDirection = -1;
                }
                if (player.dead)
                {
                    npc.TargetClosest(false);
                    flag94 = false;
                    npc.velocity.Y = npc.velocity.Y + 10f;
                    if ((double)npc.position.Y > Main.worldSurface * 16.0)
                        npc.velocity.Y = npc.velocity.Y + 10f;

                    if ((double)npc.position.Y > Main.rockLayer * 16.0)
                    {
                        for (int num957 = 0; num957 < 200; num957++)
                        {
                            if (Main.npc[num957].aiStyle == npc.aiStyle)
                                Main.npc[num957].active = false;
                        }
                    }
                }
                Vector2 value = npc.Center + (npc.rotation - 1.57079637f).ToRotationVector2() * 8f;
                Vector2 value2 = npc.rotation.ToRotationVector2() * 16f;
                Dust dust = Main.dust[Dust.NewDust(value + value2, 0, 0, 226, npc.velocity.X, npc.velocity.Y, 100, Color.Transparent, 0.5f + Main.rand.NextFloat() * 1.5f)];
                dust.noGravity = true;
                dust.noLight = true;
                dust.position -= new Vector2(2f); //4
                dust.fadeIn = 1f;
                dust.scale *= .6f;
                dust.velocity = Vector2.Zero;
                dust = Main.dust[Dust.NewDust(value - value2, 0, 0, 226, npc.velocity.X, npc.velocity.Y, 100, Color.Transparent, 0.5f + Main.rand.NextFloat() * 1.5f)];
                dust.noGravity = true;
                dust.noLight = true;
                dust.position -= new Vector2(2f); //4
                dust.fadeIn = 1f;
                dust.velocity = Vector2.Zero;
                float num188 = speed;
                float num189 = turnSpeed;
                Vector2 vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                float num191 = player.position.X + (float)(player.width / 2);
                float num192 = player.position.Y + (float)(player.height / 2);
                int num42 = -1;
                int num43 = (int)(player.Center.X / 16f);
                int num44 = (int)(player.Center.Y / 16f);
                for (int num45 = num43 - 2; num45 <= num43 + 2; num45++)
                {
                    for (int num46 = num44; num46 <= num44 + 15; num46++)
                    {
                        if (WorldGen.SolidTile2(num45, num46))
                        {
                            num42 = num46;
                            break;
                        }
                    }
                    if (num42 > 0)
                        break;
                }
                if (num42 > 0)
                {
                    npc.defense = 15;
                    num42 *= 16;
                    float num47 = (float)(num42 - 560); //was 800
                    if (player.position.Y > num47 && !charge)
                    {
                        num192 = num47;
                        if (Math.Abs(npc.Center.X - player.Center.X) < 170f) //was 500
                        {
                            if (npc.velocity.X > 0f)
                                num191 = player.Center.X + 170f; //was 600
                            else
                                num191 = player.Center.X - 170f; //was 600
                        }
                    }
                    else if (charge && player.position.Y < num47)
                    {
                        num192 = num47;
                        if (Math.Abs(npc.Center.X - player.Center.X) < 450f) //was 500
                        {
                            if (npc.velocity.X > 0f)
                                num191 = player.Center.X + 450f; //was 600
                            else
                                num191 = player.Center.X - 450f; //was 600
                        }
                    }
                }
                else
                {
                    npc.defense = 0;
                    num188 = expertMode ? 12.5f : 10f; //added 2.5
                    num189 = expertMode ? 0.25f : 0.2f; //added 0.05
                }
                float num48 = num188 * 1.23f;
                float num49 = num188 * 0.7f;
                float num50 = npc.velocity.Length();
                if (num50 > 0f)
                {
                    if (num50 > num48)
                    {
                        npc.velocity.Normalize();
                        npc.velocity *= num48;
                    }
                    else if (num50 < num49)
                    {
                        npc.velocity.Normalize();
                        npc.velocity *= num49;
                    }
                }
                if (num42 > 0)
                {
                    for (int num51 = 0; num51 < 200; num51++)
                    {
                        if (Main.npc[num51].active && Main.npc[num51].type == npc.type && num51 != npc.whoAmI)
                        {
                            Vector2 vector3 = Main.npc[num51].Center - npc.Center;
                            if (vector3.Length() < 200f)
                            {
                                vector3.Normalize();
                                vector3 *= 1000f;
                                num191 -= vector3.X;
                                num192 -= vector3.Y;
                            }
                        }
                    }
                }
                else
                {
                    for (int num52 = 0; num52 < 200; num52++)
                    {
                        if (Main.npc[num52].active && Main.npc[num52].type == npc.type && num52 != npc.whoAmI)
                        {
                            Vector2 vector4 = Main.npc[num52].Center - npc.Center;
                            if (vector4.Length() < 60f)
                            {
                                vector4.Normalize();
                                vector4 *= 200f;
                                num191 -= vector4.X;
                                num192 -= vector4.Y;
                            }
                        }
                    }
                }
                num191 = (float)((int)(num191 / 16f) * 16);
                num192 = (float)((int)(num192 / 16f) * 16);
                vector18.X = (float)((int)(vector18.X / 16f) * 16);
                vector18.Y = (float)((int)(vector18.Y / 16f) * 16);
                num191 -= vector18.X;
                num192 -= vector18.Y;
                float num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
                if (npc.ai[1] > 0f && npc.ai[1] < (float)Main.npc.Length)
                {
                    try
                    {
                        vector18 = new Vector2(npc.position.X + (float)npc.width * 0.5f, npc.position.Y + (float)npc.height * 0.5f);
                        num191 = Main.npc[(int)npc.ai[1]].position.X + (float)(Main.npc[(int)npc.ai[1]].width / 2) - vector18.X;
                        num192 = Main.npc[(int)npc.ai[1]].position.Y + (float)(Main.npc[(int)npc.ai[1]].height / 2) - vector18.Y;
                    }
                    catch
                    {
                    }
                    npc.rotation = (float)Math.Atan2(num192, num191) + 1.57f;
                    num193 = (float)Math.Sqrt(num191 * num191 + num192 * num192);
                    int num194 = npc.width;
                    num193 = (num193 - num194) / num193;
                    num191 *= num193;
                    num192 *= num193;
                    npc.velocity = Vector2.Zero;
                    npc.position.X = npc.position.X + num191;
                    npc.position.Y = npc.position.Y + num192;
                    if (directional)
                    {
                        if (num191 < 0f)
                            npc.spriteDirection = 1;

                        if (num191 > 0f)
                            npc.spriteDirection = -1;
                    }
                }
                else
                {
                    num193 = (float)System.Math.Sqrt((double)(num191 * num191 + num192 * num192));
                    float num196 = System.Math.Abs(num191);
                    float num197 = System.Math.Abs(num192);
                    float num198 = num188 / num193;
                    num191 *= num198;
                    num192 *= num198;
                    bool flag21 = false;
                    if (!flag21)
                    {
                        if ((npc.velocity.X > 0f && num191 > 0f) || (npc.velocity.X < 0f && num191 < 0f) || (npc.velocity.Y > 0f && num192 > 0f) || (npc.velocity.Y < 0f && num192 < 0f))
                        {
                            if (npc.velocity.X < num191)
                                npc.velocity.X = npc.velocity.X + num189;
                            else
                            {
                                if (npc.velocity.X > num191)
                                    npc.velocity.X = npc.velocity.X - num189;
                            }

                            if (npc.velocity.Y < num192)
                                npc.velocity.Y = npc.velocity.Y + num189;
                            else
                            {
                                if (npc.velocity.Y > num192)
                                {
                                    npc.velocity.Y = npc.velocity.Y - num189;
                                }
                            }

                            if ((double)System.Math.Abs(num192) < (double)num188 * 0.2 && ((npc.velocity.X > 0f && num191 < 0f) || (npc.velocity.X < 0f && num191 > 0f)))
                            {
                                if (npc.velocity.Y > 0f)
                                    npc.velocity.Y = npc.velocity.Y + num189 * 2f;
                                else
                                    npc.velocity.Y = npc.velocity.Y - num189 * 2f;
                            }
                            if ((double)System.Math.Abs(num191) < (double)num188 * 0.2 && ((npc.velocity.Y > 0f && num192 < 0f) || (npc.velocity.Y < 0f && num192 > 0f)))
                            {
                                if (npc.velocity.X > 0f)
                                    npc.velocity.X = npc.velocity.X + num189 * 2f; //changed from 2
                                else
                                    npc.velocity.X = npc.velocity.X - num189 * 2f; //changed from 2
                            }
                        }
                        else
                        {
                            if (num196 > num197)
                            {
                                if (npc.velocity.X < num191)
                                    npc.velocity.X = npc.velocity.X + num189 * 1.1f; //changed from 1.1
                                else if (npc.velocity.X > num191)
                                    npc.velocity.X = npc.velocity.X - num189 * 1.1f; //changed from 1.1

                                if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)num188 * 0.5)
                                {
                                    if (npc.velocity.Y > 0f)
                                        npc.velocity.Y = npc.velocity.Y + num189;
                                    else
                                        npc.velocity.Y = npc.velocity.Y - num189;
                                }
                            }
                            else
                            {
                                if (npc.velocity.Y < num192)
                                    npc.velocity.Y = npc.velocity.Y + num189 * 1.1f;
                                else if (npc.velocity.Y > num192)
                                    npc.velocity.Y = npc.velocity.Y - num189 * 1.1f;
                                if ((double)(System.Math.Abs(npc.velocity.X) + System.Math.Abs(npc.velocity.Y)) < (double)num188 * 0.5)
                                {
                                    if (npc.velocity.X > 0f)
                                        npc.velocity.X = npc.velocity.X + num189;
                                    else
                                        npc.velocity.X = npc.velocity.X - num189;
                                }
                            }
                        }
                    }
                }
            }
            #region Phase2
            else
            {
                npc.defense = 20;
                alphaCounter += 0.08f;
                npc.netUpdate = true;
                Player nearby = Main.LocalPlayer;
                if (Main.expertMode)
                {
                    int distance = (int)Vector2.Distance(npc.Center, nearby.Center);
                    if (distance <= 1000)
                    {
                        nearby.GetSpiritPlayer().starplateGlitchEffect = true;
                        nearby.GetSpiritPlayer().starplateGlitchIntensity = (float)MathHelper.Clamp((1200 / npc.life) * .002f, 0f, .025f);
                    }
                    else
                    {
                        nearby.GetSpiritPlayer().starplateGlitchIntensity = 0f;
                        nearby.GetSpiritPlayer().starplateGlitchEffect = false;
                    }
                }

                npc.aiStyle = -1;
                atkCounter++;
                shootCounter++;
                if (atkCounter % 1500 > 0 && atkCounter % 1500 < 1000) //if it's in the teleport phase
                {
                    {
                        int dust1 = Dust.NewDust(npc.Center, npc.width, npc.height, 226);

                        Main.dust[dust1].velocity *= -1f;
                        Main.dust[dust1].noGravity = true;
                        Main.dust[dust1].scale *= .8f;
                        Vector2 vector2_1 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                        vector2_1.Normalize();
                        Vector2 vector2_2 = vector2_1 * ((float)Main.rand.Next(50, 100) * 0.04f);
                        Main.dust[dust1].velocity = vector2_2;
                        vector2_2.Normalize();
                        Vector2 vector2_3 = vector2_2 * 34f;
                        Main.dust[dust1].position = (npc.Center) - vector2_3;
                    }
                    npc.velocity = Vector2.Zero; //sets his velocity to 0 in the teleport phase
                    if (shootCounter % 201 == 0) //teleport and create laser boys
                    {
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 94);
                        for (int i = 0; i < 6; i++)
                        {
                            NPC.NewNPC((int)Main.player[npc.target].Center.X + Main.rand.Next(-700,700), (int)Main.player[npc.target].Center.Y + Main.rand.Next(-700,700),mod.NPCType("LaserBase"), npc.whoAmI);
                        }
                        bool outOfBlock = false;
                        while (!outOfBlock)
                        {
                             int angle = Main.rand.Next(360);
                            double anglex = Math.Sin(angle * (Math.PI / 180));
                            double angley = Math.Cos(angle * (Math.PI / 180));
                            npc.position.X = player.Center.X + (int)(480 * anglex);
                            npc.position.Y = player.Center.Y + (int)(480 * angley);
                            if(!Main.tile[(int)(npc.position.X / 16), (int)(npc.position.Y / 16)].active())
                            {
                                outOfBlock = true;
                            }
                        }                  
                    }
                    Vector2 direction9 = Main.player[npc.target].Center - npc.Center;
                    direction9.Normalize();
                    npc.rotation = direction9.ToRotation() + 1.57f;
                }
                else
                {
                    charge = true;
                    if (atkCounter % 251 == 0)
                    {
                        distAbove = 425;
                        if (Main.rand.Next(2) == 0)
                        {
                            npc.position.X = Main.player[npc.target].Center.X - 500;
                            npc.position.Y = Main.player[npc.target].Center.Y - distAbove;
                            npc.velocity.X = 4f;
                        }
                        else
                        {
                            npc.position.X = Main.player[npc.target].Center.X + 500;
                            npc.position.Y = Main.player[npc.target].Center.Y - distAbove;
                            npc.velocity.X = -4f;
                        }
                         npc.rotation = 3.14f;
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 94);
                        for (int i = 0; i < 3; i++)
                        {
                            NPC.NewNPC((int)Main.player[npc.target].Center.X + Main.rand.Next(-300,300), (int)Main.player[npc.target].Center.Y + Main.rand.Next(-300,300), ModContent.NPCType<ArcadeProbe>(), npc.whoAmI, 0f, 0f, 0f, 0f, 255);
                        }
                    }
                    //npc.position.Y = Main.player[npc.target].Center.Y -  distAbove;
                    if (atkCounter % 20 == 0)
                    {
                        Main.PlaySound(2, (int)npc.position.X, (int)npc.position.Y, 91);
                        for (int i = 0; i < 16; i++)
                        {
                            int dust = Dust.NewDust(npc.Center, npc.width, npc.height, DustID.GoldCoin);

                            Main.dust[dust].velocity *= -1f;
                            Main.dust[dust].noGravity = true;
                            //        Main.dust[dust].scale *= 2f;
                            Vector2 vector2_1 = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                            vector2_1.Normalize();
                            Vector2 vector2_2 = vector2_1 * ((float)Main.rand.Next(50, 100) * 0.04f);
                            Main.dust[dust].velocity = vector2_2;
                            vector2_2.Normalize();
                            Vector2 vector2_3 = vector2_2 * 34f;
                            Main.dust[dust].position = (npc.Center) - vector2_3;
                        }
                        Projectile.NewProjectile(npc.Center, new Vector2(0, 10), ModContent.ProjectileType<GlitchLaser>(), 25, 1, Main.myPlayer, 0, 0);
                    }
                    shootCounter = 180; //make sure he fires lasers immediately after ending this section
                }
            }
            #endregion
        }
        float alphaCounter;
        int atkCounter = 0;
        int distAbove = 500;
        int shootCounter = 150;
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
		{
            if (npc.life <= 1200)
            {
                Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width * 0.5f, (npc.height / Main.npcFrameCount[npc.type]) * 0.5f);
                {
                    float sineAdd = (float)Math.Sin(alphaCounter * 2) + 3;
                    Vector2 drawPos1 = npc.Center - Main.screenPosition + drawOrigin + new Vector2(0f, npc.gfxOffY);
                    Main.spriteBatch.Draw(SpiritMod.instance.GetTexture("Effects/Masks/Extra_49"), (npc.Center - Main.screenPosition), null, new Color((int)(7.5f * sineAdd), (int)(16.5f * sineAdd), (int)(18f * sineAdd), 0), 0f, new Vector2(50, 50), 0.25f * (sineAdd + .65f), SpriteEffects.None, 0f);
                }
            }
            var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
                             drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
			return false;
		}
        public override void PostDraw(SpriteBatch spriteBatch, Color drawColor)
        {
           
            if (charge)
			{
			Microsoft.Xna.Framework.Color color1 = Lighting.GetColor((int) ((double) npc.position.X + (double) npc.width * 0.5) / 16, (int) (((double) npc.position.Y + (double) npc.height * 0.5) / 16.0));
      		 Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width * 0.5f, npc.height * 0.5f);
			int r1 = (int) color1.R;
			drawOrigin.Y += 30f;
			drawOrigin.Y += 8f;
			--drawOrigin.X;
			Vector2 position1 = npc.Bottom - Main.screenPosition;
	        Texture2D texture2D2 = Main.glowMaskTexture[239];					
			float num11 = (float) ((double) Main.GlobalTime % 1.0 / 1.0);
			float num12 = num11;
			if ((double) num12 > 0.5)
			num12 = 1f - num11;
			if ((double) num12 < 0.0)
			num12 = 0.0f;
			float num13 = (float) (((double) num11 + 0.5) % 1.0);
			float num14 = num13;
			if ((double) num14 > 0.5)
			num14 = 1f - num13;
			if ((double) num14 < 0.0)
			num14 = 0.0f;
			Microsoft.Xna.Framework.Rectangle r2 = texture2D2.Frame(1, 1, 0, 0);
			drawOrigin = r2.Size() / 2f;
			Vector2 position3 = position1 + new Vector2(0.0f, -20f);
			Microsoft.Xna.Framework.Color color3 = new Microsoft.Xna.Framework.Color(255, 138, 36) * 1.6f;
			Main.spriteBatch.Draw(texture2D2, position3, new Microsoft.Xna.Framework.Rectangle?(r2), color3, npc.rotation,drawOrigin, npc.scale * 0.5f,  SpriteEffects.None ^ SpriteEffects.FlipHorizontally, 0.0f);
			float num15 = 1f + num11 * 0.75f;
			Main.spriteBatch.Draw(texture2D2, position3, new Microsoft.Xna.Framework.Rectangle?(r2), color3 * num12, npc.rotation,drawOrigin, npc.scale * 0.5f * num15,  SpriteEffects.None ^ SpriteEffects.FlipHorizontally, 0.0f);
			float num16 = 1f + num13 * 0.75f;
			Main.spriteBatch.Draw(texture2D2, position3, new Microsoft.Xna.Framework.Rectangle?(r2), color3 * num14, npc.rotation,drawOrigin, npc.scale * 0.5f * num16,  SpriteEffects.None ^ SpriteEffects.FlipHorizontally, 0.0f);
			Texture2D texture2D3 = Main.extraTexture[89];
			Microsoft.Xna.Framework.Rectangle r3 = texture2D3.Frame(1, 1, 0, 0);
			drawOrigin = r3.Size() / 2f;
			Vector2 scale = new Vector2(0.75f, 1f + num16) * 1.5f;
			float num17 = 1f + num13 * 0.75f;
			}
        	 GlowmaskUtils.DrawNPCGlowMask(spriteBatch, npc, mod.GetTexture("NPCs/Boss/SteamRaider/SteamRaiderHead_Glow"));		
			
        }
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int k = 0; k < 5; k++)
			{
				Dust.NewDust(npc.position, npc.width, npc.height, 226, hitDirection, -1f, 0, default(Color), 1f);
			}
			if (npc.life <= 0)
			{
                 NPC.NewNPC((int)npc.position.X + npc.width - 20, (int)npc.position.Y + npc.height, mod.NPCType("SteamRaiderHeadDeath"), npc.whoAmI);
                 npc.active = false;
			}
		}
		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			npc.lifeMax = (int)(npc.lifeMax * 0.6f * bossLifeScale);
		}


		public override bool PreNPCLoot()
		{
			MyWorld.downedRaider = true;
			return true;
		}
	}
}