using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ID;

namespace Laugicality.Content.SoulStones
{
    public sealed class SoulStoneAbilityCooldownBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Soul Stone Ability Cooldown");
            // Description.SetDefault("You used your Soul Stone's ability recently!");

            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }
    }
}