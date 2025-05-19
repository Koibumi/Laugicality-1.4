using Terraria;
using Laugicality.Utilities.Globals;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs
{
	public class DawnBuff : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dawn");
			// Description.SetDefault("Golden energy");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().dawn = true;
        }
    }
}
