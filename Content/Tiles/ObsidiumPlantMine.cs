using Laugicality.Content.Dusts;
using Laugicality.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using WebmilioCommonsAddon.Extensions;

namespace Laugicality.Content.Tiles
{
    public class ObsidiumPlantMine : AmelderaTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = false;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            //dustType = ModContent.DustType<Magma>();
            //drop = ModContent.ItemType<LavaGem>();
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Lycoris Radiata");
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x4);
            TileObjectData.newTile.Width = 4;
            //AddMapEntry(new Color(200, 30, 0), name);
            Main.tileFrameImportant[Type] = true;
            HitSound = SoundID.Grass;
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
				ModContent.TileType<Lycoris>(),
                ModContent.TileType<Tiles.Radiata>()
            };
            TileObjectData.addTile(Type);

            if (!Main.dedServ)
            {
                //obsidiumTexture = this.GetType().GetTexture();
                //amelderaTexture = mod.GetTexture(this.GetType().GetRootPath() + "/Eldermine");
            }
        }
        

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }


        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY = 4;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = .2f;
            g = 0.08f;
            b = 0.0f;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            var source = Main.LocalPlayer.GetSource_ItemUse(Main.LocalPlayer.HeldItem);
            Item.NewItem(source, i * 16, j * 16, 64, 64, ModContent.ItemType<ObsidiumPlant>());
        }
    }
}