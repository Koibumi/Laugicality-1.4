using System;
using Laugicality.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Mystic.Illusion
{
	public class HadesIllusion : IllusionProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 100;
            Projectile.ignoreWater = true;
            Projectile.scale *= 1.5f;
            buffID = BuffID.ShadowFlame;
        }

        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + .785f;
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Hades>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
        }
    }
}