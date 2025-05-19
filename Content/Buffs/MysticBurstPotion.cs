using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class MysticBurstPotion : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Burst Power");
			// Description.SetDefault("'Mystical energy swells within you.'\nDecreases Mystic Burst cooldown");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            LaugicalityPlayer.Get(player).MysticSwitchCoolRate += 1;
        }
        
	}
}
