using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using WebmilioCommonsAddon.Extensions;
using Laugicality.Utilities;
using ReLogic.Content;

namespace Laugicality.Content.Tiles
{
    public abstract class AmelderaTile : ModTile
    {
        public Texture2D obsidiumTexture, amelderaTexture;

        public override void SetStaticDefaults()
        {
            if(!Main.dedServ)
                obsidiumTexture = this.GetType().GetTexture().Value;
        }

        /*public override bool PreDraw(int i, int j, SpriteBatch spriteBatch)
        {
            if (LaugicalityWorld.Ameldera)
                TextureAssets.Tile[Type] = new Asset<Texture2D>(amelderaTexture);
            else
                TextureAssets.Tile[Type] = new Asset<Texture2D>(obsidiumTexture);
            return base.PreDraw(i, j, spriteBatch);
        }*/
    }
}
