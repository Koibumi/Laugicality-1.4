using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class MysticPower : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mystic Power");
			// Description.SetDefault("'The energy of the cosmos strengthens you.'\n+10% Mystic Damage");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).MysticDamage += 0.1f;
        }
        
	}
}
