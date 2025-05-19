using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Globals;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;	

namespace Laugicality.Content.Buffs
{
	public class FragmentedMind : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Fragmented Mind");
			// Description.SetDefault("Your Etherial Brain has to regenerate before it can save you again.");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
			BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
        
		public override void Update(Player player, ref int buffIndex)
		{
			LaugicalityPlayer.Get(player).EtherialBrainCooldown = true;
		}

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.takenDamageMultiplier = npc.GetGlobalNPC<LaugicalGlobalNPCs>().damageMult * 1.5f;
        }
    }
}
