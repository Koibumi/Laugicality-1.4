using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Laugicality.Content.Dusts;
using Laugicality.Content.Items.Placeable;
using Laugicality.Utilities;
using Terraria.ID;

namespace Laugicality.Content.Tiles
{
    public class BysmalOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[56][ModContent.TileType<ObsidiumOreBlock>()] = true;
            Main.tileMerge[ModContent.TileType<ObsidiumOreBlock>()][56] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileLighted[Type] = true;
           // name.SetDefault("Obsidium Ore");
            AddMapEntry(new Color(150, 50, 50), CreateMapEntryName());
            MineResist = 2.5f;
            MinPick = 200;
            HitSound = SoundID.Tink;
            DustType = ModContent.DustType<EtherialDust>();
        }
        
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.2f;
            b = 0.3f;
        }
        
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        
        public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
		{
            if(LaugicalityWorld.downedEtheria == true)
            {
                Main.tileSolid[Type] = true;
            }
            else 
            {
                Main.tileSolid[Type] = false;
            }
            if(LaugicalityWorld.downedEtheria == true)
            {
			    return true;
            }
            else 
            {
                return false;
            }
		}

        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
		{

            if(LaugicalityWorld.downedEtheria == true)
            {
			    return true;
            }
            else 
            {
                return false;
            }
		}

        
    }
}