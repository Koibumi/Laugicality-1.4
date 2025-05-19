using Laugicality.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Projectiles.Mystic.Burst
{
	public class EruptionBurst : ModProjectile
	{
        public bool bitherial = true;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eruption Burst");
		}

		public override void SetDefaults()
        {
            //LaugicalityVars.eProjectiles.Add(Projectile.type);
            bitherial = true;
            Projectile.width = 16;
			Projectile.height = 16;
            Projectile.timeLeft = 180;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }

		public override void AI()
        {
            bitherial = true;
            Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Magma>(), Projectile.velocity.X * 0.05f, Projectile.velocity.Y * 0.5f);
            
            Projectile.rotation += 0.02f;
            LaugicalityPlayer modPlayer = Main.player[Projectile.owner].GetModPlayer<LaugicalityPlayer>();
            if (Main.rand.Next(2) == 0 && Main.myPlayer == Projectile.owner)
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X + -5+Main.rand.Next(0,11), -Main.rand.Next(5,10),  ModContent.ProjectileType<EruptionBurstUp>(), (int)(30 * modPlayer.MysticDamage * modPlayer.MysticBurstDamage), 3, Main.myPlayer);
            
        }
        
    }
}