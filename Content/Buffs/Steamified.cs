using Terraria;
using Laugicality.Utilities.Globals;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
	public class Steamified : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Steamified");
			// Description.SetDefault("Steamin hot!");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;

        }
        
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().steamified = true;
            npc.takenDamageMultiplier = npc.GetGlobalNPC<LaugicalGlobalNPCs>().damageMult * 1.15f;
        }
	}
}
