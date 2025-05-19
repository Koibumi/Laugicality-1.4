using System;
using Laugicality.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Projectiles.Mystic.Conjuration
{
	public class AnDioConjuration1 : ConjurationProjectile
    {
        public bool bitherial = true;
        public int delay = 0;
        public int power = 0;
        int homeDelay = 0;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Loki Blast");
        }

        public override void SetDefaults()
        {
            power = 0;
            LaugicalityVars.eProjectiles.Add(Projectile.type);
            delay = 0;
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.penetrate = 2;
            Projectile.friendly = true;
            Projectile.timeLeft = 180;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void OnKill(int timeLeft)
        {
            var source = Projectile.GetSource_FromAI();
            if (Main.myPlayer == Projectile.owner)
            {
				float num102 = 30f;
				int num103 = 0;
				while ((float)num103 < num102)
				{
					Vector2 vector12 = Vector2.UnitX * 0f;
					vector12 += -Vector2.UnitY.RotatedBy((double)((float)num103 * (6.28318548f / num102)), default(Vector2)) * new Vector2(10f, 10f);
					vector12 = vector12.RotatedBy((double)Projectile.velocity.ToRotation(), default(Vector2));
					int num104 = Dust.NewDust(Projectile.Center, 0, 0, ModContent.DustType<White>(), 0f, 0f, 75, default(Color), 1.25f);
					Main.dust[num104].scale = 1.75f;
					Main.dust[num104].noGravity = true;
					Main.dust[num104].position = Projectile.Center + vector12;
					Main.dust[num104].velocity = -1 * (Projectile.velocity * 0f + vector12.SafeNormalize(Vector2.UnitY) * 2.5f);
					int num = num103;
					num103 = num + 1;
				}
				
                Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 7, 0, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -7, 0, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 0, 7, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 0, -7, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 5, 5, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 5, -5, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -5, -5, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -5, 5, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
            }
        }

        public override void AI()
        {
            var source = Projectile.GetSource_FromAI();
            bitherial = true;
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<White>(), 0f, 0f);
            delay++;
            Player player = Main.player[Projectile.owner];
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (delay > 30)
            {
                    delay = 0;
                if (Main.myPlayer == Projectile.owner)
                {
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 7, 0, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -7, 0, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 0, 7, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 0, -7, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 5, 5, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 5, -5, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -5, -5, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -5, 5, ModContent.ProjectileType<AnDioConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                }
            }

            homeDelay -= 1;
            if (homeDelay <= 0)
            {
                homeDelay = 4;
                Vector2 move = Vector2.Zero;
                bool target = false;
                float distance = 1400f;
                for (int i = 0; i < 200; i++)
                {
                    NPC npcT = Main.npc[i];
                    if (!npcT.friendly)
                    {
                        Vector2 newMove = npcT.Center - Projectile.Center;
                        float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                        if (distanceTo < distance)
                        {
                            move = newMove;
                            distance = distanceTo;
                            target = true;

                        }
                    }
                }
                if (target)
                {
                    AdjustMagnitude(ref move);
                    Projectile.velocity = (20 * Projectile.velocity + move) / 11f;
                    AdjustMagnitude(ref Projectile.velocity);
                }
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 6f)
            {
                vector *= 6f / magnitude;
            }
        }
    }
}