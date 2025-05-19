using Terraria;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs
{
	public class UltraJumpBoostBuff : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Ultra Jump Boost");
			// Description.SetDefault("'Reach for the stars.'");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.jumpSpeedBoost += 15.0f;
        }
        
	}
}
