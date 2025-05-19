using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Projectiles.Melee
{
	public class ObsidiumYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
		{
			ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 9f;
			ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 240f;
			ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 14f;
		}

		public override void SetDefaults()
		{
			Projectile.extraUpdates = 0;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 99;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.scale = 1f;
		}

        public Vector2 GetPosition()
        {
            return Projectile.position;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 80);
        }
    }
}
