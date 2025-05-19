using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
	public class Annihilation : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Annihilation");
			// Description.SetDefault("You are infused with the rage of an Annihilator.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
        

		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer.Get(player).AnnihilationBoost = true;
		}
	}
}
