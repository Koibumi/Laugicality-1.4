using Laugicality.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using WebmilioCommonsAddon.Extensions;

namespace Laugicality.Content.Tiles
{
    public class ObsidiumPlantGrass2 : AmelderaTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.addTile(Type);
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Lycoris Radiata");
            //AddMapEntry(new Color(200, 30, 0), name);
            TileID.Sets.DisableSmartCursor[Type] = true;
            Main.tileCut[Type] = true;
            DustType = ModContent.DustType<Magma>();
            HitSound = SoundID.Grass;
            //adjTiles = new int[] { TileID.WorkBenches };

            if (!Main.dedServ)
            {
                //obsidiumTexture = this.GetType().GetTexture();
                //amelderaTexture = mod.GetTexture(this.GetType().GetRootPath() + "/EldergrassPlant2");
            }
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
        {
            offsetY = 2;
        }
    }
}