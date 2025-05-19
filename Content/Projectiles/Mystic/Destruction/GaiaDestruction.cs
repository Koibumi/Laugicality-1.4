using Laugicality.Content.Dusts;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Mystic.Destruction
{
	public class GaiaDestruction : DestructionProjectile
    {
        float distanceTo = 800;

        public override void SetDefaults()
        {
            distanceTo = 800;
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Rainbow>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (!target.friendly && target.damage > 0)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - Projectile.Center.X;
                    float shootToY = target.position.Y - Projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 480f && distance < distanceTo && !target.friendly && target.active && target.damage > 0)
                    {
                        distanceTo = distance;
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 1f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        int mag = 5;
                        if (Projectile.velocity.X < shootToX)
                        {
                            Projectile.velocity.X += (shootToX - Projectile.velocity.X) / mag;
                        }
                        if (Projectile.velocity.Y < shootToY)
                        {
                            Projectile.velocity.Y += (shootToY - Projectile.velocity.Y) / mag;
                        }
                        if (Projectile.velocity.X > shootToX)
                        {
                            Projectile.velocity.X -= (Projectile.velocity.X - shootToX) / mag;
                        }
                        if (Projectile.velocity.Y > shootToY)
                        {
                            Projectile.velocity.Y -= (Projectile.velocity.Y - shootToY) / mag;
                        }
                    }
                }
            }
        }
    }
}