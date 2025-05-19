using Laugicality.Content.Dusts;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities;

namespace Laugicality.Content.Projectiles.Mystic.Conjuration
{
	public class CupidBurst : ConjurationProjectile
    {
        public bool bitherial = true;
        public int delay = 0;
        public int power = 0;

        public override void SetDefaults()
        {
            power = 0;
            LaugicalityVars.eProjectiles.Add(Projectile.type);
            delay = 0;
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.timeLeft = 320;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }
        
        public override void AI()
        {
            Projectile.rotation = (float)(3.14*3/2);
            bitherial = true;
            if(Main.rand.Next(4) == 0)
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Pink>(), 0f, 0f);
            delay++;
            if (delay > 30)
            {
                    delay = 0;
                    power++;
                if (Main.myPlayer == Projectile.owner)
                {
                    var source = Projectile.GetSource_FromThis();
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 7, 0, ModContent.ProjectileType<CupidConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -7, 0, ModContent.ProjectileType<CupidConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 0, 7, ModContent.ProjectileType<CupidConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 0, -7, ModContent.ProjectileType<CupidConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 5, 5, ModContent.ProjectileType<CupidConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, 5, -5, ModContent.ProjectileType<CupidConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -5, -5, ModContent.ProjectileType<CupidConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                    Projectile.NewProjectile(source, Projectile.Center.X, Projectile.Center.Y, -5, 5, ModContent.ProjectileType<CupidConjuration2>(), (int)(Projectile.damage / 1.2f), 3, Main.myPlayer);
                }
                Projectile.Kill();
            }
        }
    }
}