using Terraria;
using Laugicality.Utilities.Globals;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs
{
	public class Furious : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Furious");
			// Description.SetDefault("Losing life.\nExplode upon death");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().furious = true;
        }

    }
}
