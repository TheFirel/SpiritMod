using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
namespace SpiritMod.Tiles.Block
{
    public class Asteroid : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            AddMapEntry(new Color(99, 79, 49));
            soundType = 21;
            Main.tileBlockLight[Type] = true;
            minPick = 100;
            drop = mod.ItemType("AsteroidBlock");
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            Player player = Main.LocalPlayer;
            if (player.inventory[player.selectedItem].type == ItemID.ReaverShark)
            {
                return false;
            }
            return true;
        }
        public override void RandomUpdate(int i, int j)
        {
            if (!Framing.GetTileSafely(i, j - 1).active() && Main.rand.Next(50) == 0)
            {
                switch (Main.rand.Next(3))
                {
                    case 0:
                        ReachGrassTile.PlaceObject(i, j - 1, mod.TileType("GlowShard1"));
                        NetMessage.SendObjectPlacment(-1, i, j - 1, mod.TileType("GlowShard1"), 0, 0, -1, -1);
                        break;
                    case 1:
                        ReachGrassTile.PlaceObject(i, j - 1, mod.TileType("GreenShard"));
                        NetMessage.SendObjectPlacment(-1, i, j - 1, mod.TileType("GreenShard"), 0, 0, -1, -1);
                        break;
                    case 2:
                        ReachGrassTile.PlaceObject(i, j - 1, mod.TileType("PurpleShard"));
                        NetMessage.SendObjectPlacment(-1, i, j - 1, mod.TileType("PurpleShard"), 0, 0, -1, -1);
                        break;
                }
            }
        }
    }
}