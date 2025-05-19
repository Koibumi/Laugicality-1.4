using Laugicality.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Projectiles.Mystic.Conjuration
{
	public class GaiaConjuration : ConjurationProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
        }

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            Projectile.velocity.Y += .15f;

            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Rainbow>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                for (int k = 0; k < 8; k++)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Main.rand.Next((int)-10f, (int)10f), Main.rand.Next((int)-10f, (int)10f), ModContent.ProjectileType<GemShard>(), (int)(Projectile.damage * 0.80f), 2f, Projectile.owner, 0f, Main.rand.Next(6));
				}	
			}
            Projectile.penetrate--;
            if (Projectile.penetrate <= 1)
            {
                Projectile.Kill();
            }
            else
            {
                Projectile.ai[0] += 0.2f;
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                Projectile.velocity *= 0.75f;
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            }
            
            return false;
        }
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                Projectile.ai[0] += 0.2f;
                for (int k = 0; k < 8; k++)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Main.rand.Next((int)-10f, (int)10f), Main.rand.Next((int)-10f, (int)10f), ModContent.ProjectileType<GemShard>(), (int)(Projectile.damage * 0.80f), 2f, Projectile.owner, 0f, Main.rand.Next(6));
				}
			}
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}