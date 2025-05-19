using Terraria;
using Laugicality.Utilities.Globals;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
	public class Lovestruck : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Lovestruck");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }
        

		public override void Update(NPC npc, ref int buffIndex)
		{
            if(npc.boss == false)
			    npc.GetGlobalNPC<LaugicalGlobalNPCs>().lovestruck = true;
		}
	}
}
