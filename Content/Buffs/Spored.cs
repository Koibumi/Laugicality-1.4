using Terraria;
using Laugicality.Utilities.Globals;
using Terraria.ID;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs
{
	public class Spored : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Spored");
			// Description.SetDefault("Smokin hot!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().spored = true;
		}
	}
}
