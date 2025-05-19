using Laugicality.Content.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class ObsidiumHeartBuff : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Obsidium Heart");
			// Description.SetDefault("'A special kind of love.'");
			Main.buffNoTimeDisplay[Type] = true;
			Main.lightPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.statLifeMax2 += 25;
            LaugicalityPlayer.Get(player).obsHeart = true;
			player.buffTime[buffIndex] = 18000;
			bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.Pets.ObsidiumHeartProjectile>()] <= 0;
			if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
			{
				Projectile.NewProjectile(player.GetSource_FromThis(), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 
                    0f, 0f, ModContent.ProjectileType<ObsidiumHeartProjectile>(), 0, 0f, player.whoAmI, 0f, 0f);
			}
		}
	}
}