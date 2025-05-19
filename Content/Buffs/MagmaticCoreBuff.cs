using Laugicality.Content.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class MagmaticCoreBuff : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
            // DisplayName.SetDefault("Magmatic Core");
            // Description.SetDefault("This ball of hardened magma will fight for you");
			Main.buffNoTimeDisplay[Type] = true;
			Main.buffNoSave[Type] = true;
		}
		
		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
			if (player.ownedProjectileCounts[ModContent.ProjectileType<MagmaticCoreProjectile>()] > 0)
			{
				modPlayer.MoltenCoreSummon = true;
			}
			if (!modPlayer.MoltenCoreSummon)
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else
			{
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}