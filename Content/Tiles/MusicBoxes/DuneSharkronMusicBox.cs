using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Terraria.ID;
using System.Collections.Generic;

namespace Laugicality.Content.Tiles.MusicBoxes
{
	class DuneSharkronMusicBox : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);
			TileID.Sets.DisableSmartCursor[Type] = true;
			//ModTranslation name = CreateMapEntryName();
			//name.SetDefault("Dune Sharkron Music Box");
			AddMapEntry(new Color(200, 200, 200), CreateMapEntryName());
		}
        public override bool CanDrop(int i, int j)
		{
			return true;

		}
		public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ModContent.ItemType<Items.Placeable.MusicBoxes.DuneSharkronMusicBox>());
        }

        public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ModContent.ItemType<Items.Placeable.MusicBoxes.DuneSharkronMusicBox>();
		}
	}
}
