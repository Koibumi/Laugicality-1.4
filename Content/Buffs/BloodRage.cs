using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ModLoader;

namespace Laugicality.Content.Buffs
{
	public class BloodRage : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Blood Rage");
			// Description.SetDefault("Increased Damage and Crit chance");
			Main.debuff[Type] = false;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.GetDamage(DamageClass.Generic) += .15f;

            player.GetCritChance(DamageClass.Throwing) += 10;
            player.GetCritChance(DamageClass.Ranged) += 10;
            player.GetCritChance(DamageClass.Magic) += 10;
            player.GetCritChance(DamageClass.Melee) += 10;
        }
	}
}
