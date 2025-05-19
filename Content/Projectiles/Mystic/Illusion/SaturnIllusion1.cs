using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Laugicality.Content.Buffs;
using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Mystic.Illusion
{
    public class SaturnIllusion1 : IllusionProjectile
    {
        int delay = 0;

        public override void SetDefaults()
        {
            delay = 0;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.scale *= .85f;
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            buffID = ModContent.BuffType<OrbitalBuff>();
        }

        public override bool PreDraw(ref Color lightColor)
        {
            SpriteBatch spriteBatch = Main.spriteBatch;
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor * 0.25f) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void AI()
        {
            delay++;
            if(delay >= 12)
            {
                delay = 0;
                if ( Main.myPlayer == Projectile.owner)
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, -Projectile.velocity.X / 2, -Projectile.velocity.Y / 2, ModContent.ProjectileType<SaturnIllusion2>(), Projectile.damage, 3f, Main.myPlayer);
            }
        }
    }
}
