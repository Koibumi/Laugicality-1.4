using Laugicality.Content.Dusts;
using Microsoft.Xna.Framework;
using Mono.Cecil;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Laugicality.Content.Tiles
{
    public class LargeLavaGem : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(220, 150, 40), CreateMapEntryName());
            DustType = ModContent.DustType<Magma>();
            Main.tileLighted[Type] = true;
            //adjTiles = new int[] { TileID.WorkBenches };
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY = 4;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            var source = Main.LocalPlayer.GetSource_ItemUse(Main.LocalPlayer.HeldItem);
            Item.NewItem(source, i * 16, j * 16, 32, 32, ModContent.ItemType<Items.Placeable.LavaGem>(), Main.rand.Next(3, 6));
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = .4f;
            g = 0.16f;
            b = 0.0f;
        }
    }
}