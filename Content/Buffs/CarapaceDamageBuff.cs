using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
    public class CarapaceDamageBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fractured Carapace");
            // Description.SetDefault("Increased Damage!");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).DamageBoost(.15f);
        }
    }
}
