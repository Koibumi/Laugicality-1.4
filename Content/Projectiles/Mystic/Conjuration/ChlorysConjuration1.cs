using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Mystic.Conjuration
{
    public class ChlorysConjuration1 : ConjurationProjectile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 360;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            Projectile.rotation += Projectile.velocity.X / 60;
            Projectile.velocity.Y += .5f;
            delay++;
            if (delay > 45)
            {
                delay = 0;
                if (Main.myPlayer == Projectile.owner)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, -8, ModContent.ProjectileType<ChlorysConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity.Y = 0;
            return false;
        }
    }
}