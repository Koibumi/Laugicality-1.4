using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Globals;

namespace Laugicality.Content.Buffs
{
    public class Incineration : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Incineration");
            //Description.SetDefault("Smokin hot!");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            //longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<LaugicalGlobalNPCs>().incineration = true;
        }
    }
}
