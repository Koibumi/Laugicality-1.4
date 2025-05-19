using Laugicality.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Content.Tiles
{
    public class SootTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Soot");
            AddMapEntry(new Color(60, 50, 60), CreateMapEntryName());
            MineResist = .5f;
            MinPick = 0;
            //drop = ModContent.ItemType<Soot>();
            DustType = 1;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}