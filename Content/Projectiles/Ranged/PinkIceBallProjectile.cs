using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Ranged
{
    public class PinkIceBallProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            Projectile.velocity.Y += Projectile.ai[0];
            Projectile.ai[0] += 0.01f;
        }

        public override void OnKill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);
        }
    }
}