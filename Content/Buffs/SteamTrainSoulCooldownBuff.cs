using Terraria;
using Laugicality.Utilities.Base;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
    public class SteamTrainSoulCooldownBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Steam Train Soul Cooldown");
            // Description.SetDefault("Your Steam Train effect is on Cooldown.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
    }
}
