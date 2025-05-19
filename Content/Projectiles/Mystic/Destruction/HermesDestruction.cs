using Terraria;
using System;
using Laugicality.Content.Dusts;
using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Mystic.Destruction
{
	public class HermesDestruction : DestructionProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.friendly = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<HermesDust>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f / 2;
        }
    }
}