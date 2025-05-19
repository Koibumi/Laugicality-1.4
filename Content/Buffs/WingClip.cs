using Terraria;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs
{
    public class WingClip : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wing Clip");
            // Description.SetDefault("Flight time drastically reduced.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.wingTimeMax = 45;
            player.wingTime = 0;
            player.jumpSpeedBoost = 0;
        }
    }
}
