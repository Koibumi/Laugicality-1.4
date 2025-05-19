using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Globals;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
    public class OrbitalBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orbital");
            // Description.SetDefault("Into orbit!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (npc.boss)
                return;
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().Orbital = true;
            npc.takenDamageMultiplier = npc.GetGlobalNPC<LaugicalGlobalNPCs>().damageMult * 1.1f;
        }
    }
}
