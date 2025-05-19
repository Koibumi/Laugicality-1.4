using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
    public class CapacityCurseBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Capacity Curse");
            // Description.SetDefault("You've been weakened!");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense -= 10;
            if (player.statDefense < 0)
                player.statDefense -= 0; // ? - && + && - 1000
        }
    }
}
