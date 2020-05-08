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
    }
}