using System;
using Laugicality.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Mystic.Illusion
{
	public class MarsIllusion : IllusionProjectile
    {
        public int delay = 0;

		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mars' Illusion");
		}

		public override void SetDefaults()
		{
            delay = 0;
			Projectile.width = 16;
			Projectile.height = 16;
            Projectile.timeLeft = 180;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 3;
            buffID = ModContent.BuffType<Furious>();
        }

        public override void AI()
        {
            if (Main.myPlayer == Projectile.owner && Projectile.timeLeft < 170)
            {
                Vector2 vec;
                vec.X = Main.MouseWorld.X;
                vec.Y = Main.MouseWorld.Y;

                float mag = 7.5f;
                
                float diffX = vec.X - Projectile.Center.X;
                float diffY = vec.Y - Projectile.Center.Y;
                float dist = (float)Math.Sqrt((double)(diffX * diffX + diffY * diffY));
                dist = mag / dist;
                diffX *= dist;
                diffY *= dist;

                Projectile.velocity.X = (Projectile.velocity.X * 20f + diffX) / 21f;
                Projectile.velocity.Y = (Projectile.velocity.Y * 20f + diffY) / 21f;
            }
        }
    }
}