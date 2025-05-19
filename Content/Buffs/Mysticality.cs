using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
    public class Mysticality : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mysticality");
            // Description.SetDefault("You can't drink Potentia Potions for a while");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }


        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).Mysticality = 2;
        }
    }
}
