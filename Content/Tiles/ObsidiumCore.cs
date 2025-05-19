using Laugicality.Content.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using WebmilioCommonsAddon.Extensions;
using Laugicality.Utilities;
using System.Collections.Generic;

namespace Laugicality.Content.Tiles
{
    public class ObsidiumCore : AmelderaTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = true;
            AddMapEntry(new Color(200, 150, 50), CreateMapEntryName());
            MineResist = .5f;
            MinPick = 50;
            DustType = ModContent.DustType<Magma>();

            if (!Main.dedServ)
            {
                //obsidiumTexture = this.GetType().GetTexture().Value;
                //amelderaTexture = ModContent.Request<Texture2D>(this.GetType().GetRootPath() + "/AmelderaCoreTile").Value;
            }
        }
        public override bool CanDrop(int i, int j) 
        {
            return true;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ModContent.ItemType<Items.Placeable.ObsidiumCore>());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.9f;
            if (LaugicalityWorld.Ameldera)
                r = 0;
            g = 0.6f;
            b = 0f;
            if (LaugicalityWorld.Ameldera)
                b = .9f;
        }

        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j - 1].TileType == 0 && Main.tile[i + 1, j - 1].TileType == 0 && Main.tile[i, j - 2].TileType == 0 && Main.tile[i + 1, j - 2].TileType == 0 && Main.tile[i, j].HasTile)
            {
                if (Main.rand.Next(20) == 0)
                {
                    if(CountCrystals(i, j) < 9)
                        WorldGen.AddLifeCrystal(i, j - 1);
                }
            }
        }

        private static int CountCrystals(int i, int j)
        {
            int crystalCount = 0;
            for(int x = -20; x < 20; x++)
            {
                for(int y = -20; y < 20; y++)
                {
                    if(TileCheckSafe(x + i, y + j))
                    {
                        if (Main.tile[x + i, y + j].TileType == TileID.Heart)
                            crystalCount++;
                    }
                }
            }
            return crystalCount;
        }

        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        private static bool TileCheckSafe(int i, int j)
        {
            if (i > 0 && i < Main.maxTilesX - 1 && j > 0 && j < Main.maxTilesY - 1)
                return true;
            return false;
        }
    }
}