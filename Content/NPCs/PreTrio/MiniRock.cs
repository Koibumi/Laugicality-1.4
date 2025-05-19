using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities;

namespace Laugicality.Content.NPCs.PreTrio
{
	public class MiniRock : ModProjectile
	{

        public bool bitherial = true;
        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(Projectile.type);
            bitherial = true;
            Projectile.width = 16;
			Projectile.height = 16;
			//projectile.alpha = 255;
            Projectile.timeLeft = 200;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 127, 0f, 0f);
            Projectile.rotation += 0.02f;
        }
    }
}