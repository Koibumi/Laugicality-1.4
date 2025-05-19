using Laugicality.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Ranged
{
    public class SootballProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
        }

        public override void AI()
        {
            Projectile.velocity.Y += Projectile.ai[0];
            Projectile.ai[0] += 0.01f;
            if(Main.rand.NextBool(8)) Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Magma>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.Kill();
            return true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 120 + Main.rand.Next(60));
        }
    }
}