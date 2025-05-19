using System;
using Terraria.ModLoader;
using Laugicality.Utilities;

namespace Laugicality.Content.NPCs.PreTrio
{
    public class SharkronCrystalShard : ModProjectile
    {
        //int attackDelay = 0;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Crystal Shard");
        }

        public override void SetDefaults()
        {
            LaugicalityVars.eProjectiles.Add(Projectile.type);
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.timeLeft = 240;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + .785f;
            Projectile.velocity.Y += .2f;
        }

    }
}