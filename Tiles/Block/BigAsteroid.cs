using Microsoft.Xna.Framework;
using SpiritMod.Items.Placeable.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace SpiritMod.Tiles.Block
{
    public class BigAsteroid : ModTile
    {
        public override void SetDefaults() {
            Main.tileSolid[Type] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileMergeDirt[Type] = true;
            AddMapEntry(new Color(99, 79, 49));
            Main.tileBlockLight[Type] = true;
            soundType = 21;
            minPick = 100;
            drop = ModContent.ItemType<AsteroidBlock>();
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged) {
            Player player = Main.LocalPlayer;
            if(player.inventory[player.selectedItem].type == ItemID.ReaverShark) {
                return false;
            }
            return true;
        }
        public override void RandomUpdate(int i, int j) {
            if(!Framing.GetTileSafely(i, j - 1).active() && Main.rand.Next(400) == 0) {
                switch(Main.rand.Next(9)) {
                    case 0:
                        ReachGrassTile.PlaceObject(i, j - 1, mod.TileType("GlowShard1"));
                        NetMessage.SendObjectPlacment(-1, i, j - 1, mod.TileType("GlowShard1"), 0, 0, -1, -1);
                        break;
                    case 1:
                        ReachGrassTile.PlaceObject(i, j - 1, mod.TileType("GlowShard2"));
                        NetMessage.SendObjectPlacment(-1, i, j - 1, mod.TileType("GlowShard2"), 0, 0, -1, -1);
                        break;
                    case 2:
                        ReachGrassTile.PlaceObject(i, j - 1, mod.TileType("GlowShard3"));
                        NetMessage.SendObjectPlacment(-1, i, j - 1, mod.TileType("GlowShard3"), 0, 0, -1, -1);
                        break;
                    case 3:
                        ReachGrassTile.PlaceObject(i, j - 1, mod.TileType("GlowShard4"));
                        NetMessage.SendObjectPlacment(-1, i, j - 1, mod.TileType("GlowShard4"), 0, 0, -1, -1);
                        break;
                }
            }
            if(!Framing.GetTileSafely(i, j + 1).active() && Main.rand.Next(400) == 0) {
                switch(Main.rand.Next(3)) {
                    case 0:
                        ReachGrassTile.PlaceObject(i, j + 1, mod.TileType("GlowShard1"));
                        NetMessage.SendObjectPlacment(-1, i, j + 1, mod.TileType("GlowShard1"), 0, 0, -1, -1);
                        break;
                    case 1:
                        ReachGrassTile.PlaceObject(i, j + 1, mod.TileType("GlowShard2"));
                        NetMessage.SendObjectPlacment(-1, i, j + 1, mod.TileType("GlowShard2"), 0, 0, -1, -1);
                        break;
                    case 2:
                        ReachGrassTile.PlaceObject(i, j + 1, mod.TileType("GlowShard3"));
                        NetMessage.SendObjectPlacment(-1, i, j + 1, mod.TileType("GlowShard3"), 0, 0, -1, -1);
                        break;
                    case 3:
                        ReachGrassTile.PlaceObject(i, j + 1, mod.TileType("GlowShard4"));
                        NetMessage.SendObjectPlacment(-1, i, j + 1, mod.TileType("GlowShard4"), 0, 0, -1, -1);
                        break;
                }
            }
            if(!Framing.GetTileSafely(i - 1, j).active() && Main.rand.Next(4) == 0) {
                switch(Main.rand.Next(3)) {
                    case 0:
                        ReachGrassTile.PlaceObject(i - 1, j, mod.TileType("GlowShard1"));
                        NetMessage.SendObjectPlacment(-1, i - 1, j, mod.TileType("GlowShard1"), 0, 0, -1, -1);
                        break;
                    case 1:
                        ReachGrassTile.PlaceObject(i - 1, j, mod.TileType("GlowShard2"));
                        NetMessage.SendObjectPlacment(-1, i - 1, j, mod.TileType("GlowShard2"), 0, 0, -1, -1);
                        break;
                    case 2:
                        ReachGrassTile.PlaceObject(i - 1, j, mod.TileType("GlowShard3"));
                        NetMessage.SendObjectPlacment(-1, i - 1, j, mod.TileType("GlowShard3"), 0, 0, -1, -1);
                        break;
                    case 3:
                        ReachGrassTile.PlaceObject(i - 1, j, mod.TileType("GlowShard4"));
                        NetMessage.SendObjectPlacment(-1, i - 1, j, mod.TileType("GlowShard4"), 0, 0, -1, -1);
                        break;
                }
            }
            if(!Framing.GetTileSafely(i + 1, j).active() && Main.rand.Next(4) == 0) {
                switch(Main.rand.Next(3)) {
                    case 0:
                        ReachGrassTile.PlaceObject(i + 1, j, mod.TileType("GlowShard1"));
                        NetMessage.SendObjectPlacment(-1, i + 1, j, mod.TileType("GlowShard1"), 0, 0, -1, -1);
                        break;
                    case 1:
                        ReachGrassTile.PlaceObject(i + 1, j, mod.TileType("GlowShard2"));
                        NetMessage.SendObjectPlacment(-1, i + 1, j, mod.TileType("GlowShard2"), 0, 0, -1, -1);
                        break;
                    case 2:
                        ReachGrassTile.PlaceObject(i + 1, j, mod.TileType("GlowShard3"));
                        NetMessage.SendObjectPlacment(-1, i + 1, j, mod.TileType("GlowShard3"), 0, 0, -1, -1);
                        break;
                    case 3:
                        ReachGrassTile.PlaceObject(i + 1, j, mod.TileType("GlowShard4"));
                        NetMessage.SendObjectPlacment(-1, i + 1, j, mod.TileType("GlowShard4"), 0, 0, -1, -1);
                        break;
                }
            }
        }
    }
}