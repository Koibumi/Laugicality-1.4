using Laugicality.Content.Dusts;
using Laugicality.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using WebmilioCommonsAddon.Extensions;
using Laugicality.Utilities;
using System.Collections.Generic;

namespace Laugicality.Content.Tiles
{
    public class Radiata : AmelderaTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(160, 15, 0));
            MineResist = .5f;
            MinPick = 10;
            //drop = ModContent.ItemType<Items.Placeable.Radiata>();
            DustType = ModContent.DustType<Magma>();

            if (!Main.dedServ)
            {
                //obsidiumTexture = this.GetType().GetTexture().Value;
                //amelderaTexture = ModContent.Request<Texture2D>(this.GetType().GetRootPath() + "/ElderootTile").Value;
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void RandomUpdate(int i, int j)
        {
            int randm = Main.rand.Next(18);
            if (randm < 9)
            {
                if (CheckTile(i, j + 1))
                {
                    Terraria.WorldGen.PlaceTile(i, j + 1, ModContent.TileType<ObsidiumVine>(), true);
                }
                else if (Main.tile[i, j + 1].TileType == ModContent.TileType<ObsidiumVine>())
                {
                    for(int k = 1; k < 12; k++)
                    {
                        if (Main.tile[i, j + k].TileType != ModContent.TileType<ObsidiumVine>())
                        {
                            if(Main.tile[i, j + k].TileType == 0)
                                Terraria.WorldGen.PlaceTile(i, j + k, ModContent.TileType<ObsidiumVine>(), true);
                            break;
                        }
                    }
                }
            }
        }
        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (j < Main.maxTilesY - 4)
            {
                if (Main.tile[i, j + 1].TileType == ModContent.TileType<ObsidiumVine>())
                    Terraria.WorldGen.KillTile(i, j + 1);
            }
        }
        private bool CheckTile(int i, int j)
        {
            if (Main.tile[i, j].TileType != 0)
                return false;
            return true;
        }

        public override bool CanDrop(int i, int j)
        {
            return true;
        }

        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ModContent.ItemType<ElderootItem>());
        }
    }
}