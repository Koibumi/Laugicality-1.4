using Laugicality.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using WebmilioCommons.Extensions;
using Laugicality.Utilities;
using System.Collections.Generic;

namespace Laugicality.Content.Tiles
{
    public class ObsidiumOreBlock : AmelderaTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[56][ModContent.TileType<ObsidiumOreBlock>()] = true;
            Main.tileMerge[ModContent.TileType<ObsidiumOreBlock>()][56] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(150, 50, 50), name);
            MineResist = 1f;
            MinPick = 60;
            DustType = 1;

            if (!Main.dedServ)
            {
                //obsidiumTexture = this.GetType().GetTexture().Value;
                //amelderaTexture = ModContent.Request<Texture2D>(this.GetType().GetRootPath() + "/AmelderaOreTile").Value;
            }
        }

        public override bool CanDrop(int i, int j)
        {
            return true;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ModContent.ItemType<ObsidiumOre>());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.4f;
            if (LaugicalityWorld.Ameldera)
                r = 0.025f;
            g = 0.2f;
            b = 0f;
            if (LaugicalityWorld.Ameldera)
                b = .4f;
        }
        
        public override bool CanExplode(int i, int j)
        {
            return false;
        }

    }
}