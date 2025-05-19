using System;
using Laugicality.Content.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities;        

namespace Laugicality.Content.NPCs.PreTrio
{
	public class IceShard : ModProjectile
    {
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ice Shard");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(Projectile.type);
            bitherial = true;
            Projectile.width = 54;
			Projectile.height = 54;
			//projectile.alpha = 255;
            Projectile.timeLeft = 240;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

		public override void AI()
        {
            bitherial = true;
            Projectile.rotation += .2f;
            
            if (Projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref Projectile.velocity);
                Projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 1400f;
            bool target = false;
            for (int k = 0; k < 8; k++)
            {
                if (Main.player[k].active)
                {
                    Vector2 newMove = Main.player[k].Center - Projectile.Center;
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
                Projectile.velocity = (10 * Projectile.velocity + move) / 11f;
                AdjustMagnitude(ref Projectile.velocity);
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
        
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            if(LaugicalityWorld.downedEtheria)
            {
                target.AddBuff(ModContent.BuffType<Frostbite>(), 4 * 60, true);
            }
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.Frostburn, 90, true);
            }
        }
    }
}