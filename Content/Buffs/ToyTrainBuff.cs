using Laugicality.Content.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class ToyTrainBuff : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Toy Train");
			// Description.SetDefault("Choo Choo!");
			Main.buffNoTimeDisplay[Type] = true;
            Main.vanityPet[Type] = true;
        }

		public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            LaugicalityPlayer.Get(player).ToyTrain = true;

            bool petProjectileNotSpawned = player.ownedProjectileCounts[ModContent.ProjectileType<ToyTrainProjectile>()] <= 0;

            if (petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.GetSource_FromThis(), player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, ModContent.ProjectileType<ToyTrainProjectile>(), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
	}
}
