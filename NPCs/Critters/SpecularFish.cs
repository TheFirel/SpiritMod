using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpiritMod.Items.Consumable.Fish;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpiritMod.NPCs.Critters
{
    public class SpecularFish : ModNPC
    {
        public override void SetStaticDefaults() {
            DisplayName.SetDefault("Specular Fish");
            Main.npcFrameCount[npc.type] = 6;
        }

        public override void SetDefaults() {
            npc.width = 34;
            npc.height = 30;
            npc.damage = 0;
            npc.defense = 0;
            npc.lifeMax = 5;
            Main.npcCatchable[npc.type] = true;
            npc.catchItem = (short)ItemID.SpecularFish;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = .35f;
            npc.aiStyle = 16;
            npc.dontCountMe = true;
            npc.noGravity = true;
            npc.npcSlots = 0;
            aiType = NPCID.Goldfish;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor) {
            var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(Main.npcTexture[npc.type], npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
                             drawColor, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
            return false;
        }

        public override void FindFrame(int frameHeight) {
            npc.frameCounter += 0.15f;
            npc.frameCounter %= Main.npcFrameCount[npc.type];
            int frame = (int)npc.frameCounter;
            npc.frame.Y = frame * frameHeight;
        }


        public override void HitEffect(int hitDirection, double damage) {
            if(npc.life <= 0) {
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SpecularFish1"), 1f);
                Gore.NewGore(npc.position, npc.velocity, mod.GetGoreSlot("Gores/SpecularFish2"), 1f);
            }
        }
        public override void NPCLoot() {
            if(Main.rand.Next(2) == 1) {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<RawFish>(), 1);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
            return spawnInfo.player.ZoneRockLayerHeight && spawnInfo.water ? 0.11f : 0f;
        }
    }
}
