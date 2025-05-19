using Laugicality.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Projectiles.Mystic.Illusion
{
	public class GaiaIllusion : IllusionProjectile
    {
        public int rand = 0;

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
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Rainbow>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                Projectile.ai[0] += 0.1f;
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            }
            return false;
        }
        
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            rand = Main.rand.Next(1, 6);
            if (rand == 1)
                target.AddBuff(24, (int)(4 * 60 * Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration));
            if (rand == 2)
                target.AddBuff(20, (int)(4 * 60 * Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration));
            if (rand == 3)
                target.AddBuff(70, (int)(4 * 60 * Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration));
            if (rand == 4)
                target.AddBuff(39, (int)(4 * 60 * Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration));
            if (rand == 5)
                target.AddBuff(69, (int)(4 * 60 * Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration));
            rand += 1;
            if (rand == 6)
                rand = 1;
            if (rand == 1)
                target.AddBuff(24, (int)(4 * 60 * Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration));
            if (rand == 2)
                target.AddBuff(20, (int)(4 * 60 * Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration));
            if (rand == 3)
                target.AddBuff(70, (int)(4 * 60 * Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration));
            if (rand == 4)
                target.AddBuff(39, (int)(4 * 60 * Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration));
            if (rand == 5)
                target.AddBuff(69, (int)(4 * 60 * Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>().MysticDuration));
        }
    }
}