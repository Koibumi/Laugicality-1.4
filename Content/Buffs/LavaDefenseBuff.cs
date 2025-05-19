using Terraria;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs
{
    public class LavaDefenseBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lava Defense");
            // Description.SetDefault("+10 Defense");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.statDefense += 10;
        }
    }
}
