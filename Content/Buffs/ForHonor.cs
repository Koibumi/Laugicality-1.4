using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ModLoader;

namespace Laugicality.Content.Buffs
{
	public class ForHonor : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("For Honor");
			// Description.SetDefault("+15% Damage \nDefense Halved");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            LaugicalityPlayer.Get(player).HalfDef = true;
            player.GetDamage(DamageClass.Generic) += 0.15f;
        }
        
    }
}
