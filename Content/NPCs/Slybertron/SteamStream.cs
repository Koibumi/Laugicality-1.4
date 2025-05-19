using Laugicality.Content.Buffs;
using Laugicality.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities;

namespace Laugicality.Content.NPCs.Slybertron
{
	public class SteamStream : ModProjectile
    {
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Steam Stream");
            //ProjectileID.Sets.Homing[projectile.type] = true;
			//ProjectileID.Sets.MinionShot[projectile.type] = true;
		}

		public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(Projectile.type);
            bitherial = true;
            Projectile.width = 48;
			Projectile.height = 48;
			Projectile.alpha = 55;
            Projectile.timeLeft = 80;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

		public override void AI()
        {
            bitherial = true;
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Steam>(), 0f, 0f);
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            //NPCs.Slybertron.Slybertron.steamStreamHits += 1;
            int debuff = ModContent.BuffType<Steamy>();
            if (debuff >= 0)
            {
                target.AddBuff(debuff, 90, true);
            }      //Add Onfire buff to the NPC for 1 second
        }
    }
}