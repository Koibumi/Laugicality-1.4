using Terraria;
using Laugicality.Utilities.Base;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
    
    public class WallOfFleshEffectCooldownBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wall of Flesh Effect Cooldown");
            // Description.SetDefault("Your Wall of Flesh effect is on Cooldown.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
    }
}
