using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
	public class JusticeCooldown : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Blind Justice");
			// Description.SetDefault("Justice has gone blind for a while.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
        

		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer.Get(player).JusticeCooldown = true;
		}
	}
}
