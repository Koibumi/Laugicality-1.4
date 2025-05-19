using System;
using Laugicality.Content.Buffs;
using Laugicality.Content.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities;

namespace Laugicality.Content.Projectiles.Mystic.Illusion
{
	public class PlutoIllusion : IllusionProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.timeLeft = 100;
            Projectile.ignoreWater = true;
            buffID = ModContent.BuffType<Frigid>();
            baseDuration = 2 * 60;
        }

        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X);
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Frost>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if(target.boss == false && !LaugicalityVars.frigImmune.Contains(target.type))
                target.AddBuff(buffID, (int)(baseDuration * duration) + Main.rand.Next(1 * 60));
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
           SoundEngine.PlaySound(SoundID.Item30, Projectile.position);
           return true;
        }
    }
}