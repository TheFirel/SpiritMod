using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpiritMod.Items.Consumable;
using SpiritMod.Items.Placeable;
using SpiritMod.NPCs.Boss.SteamRaider;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace SpiritMod.Tiles.Ambient
{
    public class StarBeacon : ModTile
    {
        public override void SetDefaults() {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileLavaDeath[Type] = true;
            animationFrameHeight = 36;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.Table | AnchorType.SolidTile | AnchorType.SolidWithTop, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Astralite Beacon");
            AddMapEntry(new Color(50, 70, 150), name);
            disableSmartCursor = true;
            dustType = 226;
        }

        float alphaCounter = 0;
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b) {
            r = .12f;
            g = .3f;
            b = 0.5f;

        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch) {
            alphaCounter += 0.04f;
            float sineAdd = (float)Math.Sin(alphaCounter) + 3;
            Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
            if(Main.drawToScreen) {
                zero = Vector2.Zero;
            }
            int height = tile.frameY == 36 ? 18 : 16;
            Main.spriteBatch.Draw(mod.GetTexture("Tiles/Ambient/StarBeacon_Glow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y + 2) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(SpiritMod.instance.GetTexture("Effects/Masks/Extra_49"), new Vector2(i * 16 - (int)Main.screenPosition.X + 8, j * 16 - (int)Main.screenPosition.Y + 16) + zero, null, new Color((int)(2.5f * sineAdd), (int)(5f * sineAdd), (int)(6f * sineAdd), 0), 0f, new Vector2(50, 50), 0.2f * (sineAdd + 1), SpriteEffects.None, 0f);
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged) {
            if(!MyWorld.downedRaider) {
                return false;
            }
            return true;
        }
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height) {
            offsetY = 2;
        }
        public override void NumDust(int i, int j, bool fail, ref int num) {
            num = fail ? 1 : 3;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY) {
            Item.NewItem(i * 16, j * 16, 64, 48, ModContent.ItemType<StarBeaconItem>());
            Main.PlaySound(new Terraria.Audio.LegacySoundStyle(3, 4));
        }
        public override void MouseOver(int i, int j) {
            //shows the Cryptic Crystal icon while mousing over this tile
            Main.player[Main.myPlayer].showItemIcon = true;
            Main.player[Main.myPlayer].showItemIcon2 = ModContent.ItemType<StarWormSummon>();
        }

        public override void RightClick(int i, int j) {
            //don't bother if there's already a Crystal King in the world
            for(int x = 0; x < Main.npc.Length; x++) {
                if(Main.npc[x].active && Main.npc[x].type == ModContent.NPCType<SteamRaiderHead>()) return;
            }

            //check if player has a Cryptic Crystal
            Player player = Main.player[Main.myPlayer];
            if(player.HasItem(ModContent.ItemType<StarWormSummon>()) && !Main.dayTime) {
                //now to search for it
                Item[] inventory = player.inventory;
                for(int k = 0; k < inventory.Length; k++) {
                    if(inventory[k].type == ModContent.ItemType<StarWormSummon>()) {
                        //consume it, and summon the Crystal King!
                        inventory[k].stack--;
                        NPC.SpawnOnPlayer(player.whoAmI, ModContent.NPCType<SteamRaiderHead>());
                        //  Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
                        //	Main.NewText("Starplate Voyager has awoken!", 175, 75, 255, false);
                        //and don't spam crystal kings if the player didn't ask for it :P
                        return;
                    }
                }
            }
        }

        private void DoDustEffect(Vector2 position, float distance, float minSpeed = 2f, float maxSpeed = 3f, object follow = null) {
            float angle = Main.rand.NextFloat(-MathHelper.Pi, MathHelper.Pi);
            Vector2 vec = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle));
            Vector2 vel = vec * Main.rand.NextFloat(minSpeed, maxSpeed);

            int dust = Dust.NewDust(position - vec * distance, 0, 0, 226);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].scale *= .6f;
            Main.dust[dust].velocity = vel;
            Main.dust[dust].customData = follow;
        }
    }
}