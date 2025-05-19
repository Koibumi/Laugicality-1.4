using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Mystic.Destruction
{
	public class MarsDestruction : DestructionProjectile
    {
        public int vMax = 0;
        public float vAccel = 0;
        public float tVel = 0;
        public float vMag = 0;
        int index = 0;
        float theta = 0;

        public override void SetDefaults()
        {
            theta = 0;
            index = 0;
            vMax = 28;
            vAccel = .1f;
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;

            Player player = Main.player[Projectile.owner];
            if (index == 0)
                index = player.ownedProjectileCounts[ModContent.ProjectileType<MarsDestruction>()];
            Projectile.tileCollide = false;
            theta += (float)(Math.PI / 40);
            float mag = 32 + index * 12;
            Vector2 rot = Projectile.position;
            rot.X = (float)Math.Cos(theta) * mag;
            rot.Y = (float)Math.Sin(theta) * mag;
            Vector2 targetPos = player.Center + rot;
            Vector2 direction = targetPos - Projectile.Center;
            float dist = Vector2.Distance(targetPos, Projectile.Center);
            tVel = dist / 15;
            if (vMag < vMax && vMag < tVel)
            {
                vMag += vAccel;
            }

            if (vMag > tVel)
            {
                vMag = tVel;
            }

            if (dist != 0)
            {
                Projectile.velocity = Projectile.DirectionTo(targetPos) * vMag;
            }
        }
        
    }
}