using Terraria;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs
{
	public class JumpBoost : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Jump Boost");
			// Description.SetDefault("'Reach for the sky.'");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            player.jumpSpeedBoost += 5.0f;
        }
        
	}
}
