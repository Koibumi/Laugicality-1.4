using Terraria;
using Laugicality.Utilities.Globals;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs
{
	public class Bubbly : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bubbly");
			// Description.SetDefault("Bubbles!");
			Main.debuff[Type] = true;
			Main.buffNoSave[Type] = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
           npc.GetGlobalNPC<LaugicalGlobalNPCs>().bubbly = true;
        }

    }
}
