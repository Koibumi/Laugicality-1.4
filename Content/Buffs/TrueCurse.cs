using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class TrueCurse : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("True Curse");
			// Description.SetDefault("You truly can do nothing");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = false; 
        }
        

		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer.Get(player).TrueCurse = true;
		}
	}
}
