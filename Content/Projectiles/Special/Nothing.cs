using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Special
{
	public class Nothing : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.width = 6;
			Projectile.height = 6;
			Projectile.aiStyle = 0;
			Projectile.scale = 1f;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 2;
			Projectile.tileCollide = false;
            Projectile.friendly = false;
		}
	}
}