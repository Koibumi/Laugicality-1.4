using Terraria;
using Laugicality.Utilities.Globals;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
	public class Frigid : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Frigid");
			// Description.SetDefault("'Freeze!'");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;

        }


        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).Frosty = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<LaugicalGlobalNPCs>().frigid = true;
		}
	}
}
