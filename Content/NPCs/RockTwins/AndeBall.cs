using Laugicality.Content.Buffs;
using Laugicality.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities;

namespace Laugicality.Content.NPCs.RockTwins
{
	public class AndeBall : ModProjectile
    {
        public bool bitherial = true;
        public bool stopped = false;
        public int power = 0;
        public int damage = 0;
        public int delay = 0;
        public bool spawned = false;
        public bool zImmune = true;

        public override void SetDefaults()
        {
            zImmune = true;
            LaugicalityVars.eProjectiles.Add(Projectile.type);
            power = 0;
            stopped = false;
            damage = 20;
            spawned = false;
            //mystDmg = (float)projectile.damage;
            //mystDur = 1f + projectile.knockBack;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.penetrate = -1;
            Projectile.hostile = true;
            Projectile.timeLeft = 100;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }


        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Blue>(), 0f, 0f);
            Projectile.velocity *= 1.05f;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(ModContent.BuffType<ForHonor>(), 300, true);
        }

    }
}