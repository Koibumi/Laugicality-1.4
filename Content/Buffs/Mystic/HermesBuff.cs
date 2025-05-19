using Terraria;
using Laugicality.Utilities.Globals;
using Laugicality.Utilities.Base;
using Terraria.ID;

namespace Laugicality.Content.Buffs.Mystic
{
	public class HermesBuff : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hermes");
			// Description.SetDefault("Be smitten");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
        }
        

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().hermes = true;
		}
	}
}
