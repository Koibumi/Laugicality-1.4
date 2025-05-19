using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Globals;
using Laugicality.Utilities.Base; 

namespace Laugicality.Content.Buffs
{
	public class SpookedBuff : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Spooked");
			// Description.SetDefault("Many spoops!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
		}
        

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().spooked = true;
		}
	}
}
