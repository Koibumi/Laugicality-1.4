using Terraria.ModLoader;
using Laugicality.Utilities;

namespace Laugicality.Content.NPCs.RockTwins
{
	public class DioShard : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(Projectile.type);
            Projectile.width = 18;
            Projectile.height = 60;
            Projectile.penetrate = -1;
            Projectile.hostile = true;
            Projectile.timeLeft = 200;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            bitherial = true;
            Projectile.velocity.Y += .1f;
        }
    }
}