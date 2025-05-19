using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class Albus : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Albus");
			// Description.SetDefault("+10% Damage Reduction");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.10f;
        }
        
	}
}
