using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;

namespace SpiritMod.Tiles.Ambient
{
	public class SkullStick : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 4;
			TileObjectData.newTile.Width = 2;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
			16,
			16,
			16,
			16
			};
			TileObjectData.addTile(Type);
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Skull Stick");
			AddMapEntry(new Color(200, 200, 200), name);
		}
		public override void SetDrawPositions (int i, int j, ref int width, ref int offsetY, ref int height)
		{
			offsetY = 2;
		}
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			int item = 0;
			switch (frameX / 54)
			{
				case 0:
					item = mod.ItemType("SkullStick");
					break;
				case 1:
					item = mod.ItemType("SkullStick");
					break;
				case 2:
					item = mod.ItemType("SkullStick");
					break;
				case 3:
					item = mod.ItemType("SkullStick");
					break;
			}
			if (item > 0)
			{
				Item.NewItem(i * 16, j * 16, 48, 48, item);
			}
		}

	}
}