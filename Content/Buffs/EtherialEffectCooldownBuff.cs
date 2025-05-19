using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ModLoader;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
    public class EtherialEffectCooldownBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Etherial Rage");
            // Description.SetDefault("+20 Defense & +20% Damage");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += 0.2f;

            player.statDefense += 20;
        }
    }
}
