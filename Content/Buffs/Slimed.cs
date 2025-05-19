using Terraria;
using Laugicality.Content.NPCs;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Utilities.Globals;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
	public class Slimed : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Slimed");
			// Description.SetDefault("Slowly losing life");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().slimed = true;
        }
    }
}
