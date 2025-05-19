using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs
{
    public class EvilBossCooldownBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Evil Boss Soul Cooldown");
            // Description.SetDefault("Your World Evil Boss effect is on Cooldown.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
    }
}
