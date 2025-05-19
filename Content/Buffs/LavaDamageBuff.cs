using Terraria;
using Laugicality.Utilities.Base;
using Terraria.ModLoader;

namespace Laugicality.Content.Buffs
{
    public class LavaDamageBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lava Damage");
            // Description.SetDefault("+15% Damage");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += .15f;
        }
    }
}
