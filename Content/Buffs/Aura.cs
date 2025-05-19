using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class Aura : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Aura");
			// Description.SetDefault("+10% Max Life");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.statLifeMax2 = (int)(player.statLifeMax2 * 1.1f);
        }
        
	}
}
