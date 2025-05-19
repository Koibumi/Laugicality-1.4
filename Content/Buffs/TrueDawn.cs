using Terraria;
using Laugicality.Utilities.Globals;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs
{
	public class TrueDawn : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("TrueDawn");
			// Description.SetDefault("Star energy");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().trueDawn = true;
        }

    }
}
