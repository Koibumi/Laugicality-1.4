using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ID;

namespace Laugicality.Content.Buffs
{
    public class DestroyerSoulCooldownBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Destroyer Soul Cooldown");
            // Description.SetDefault("Your Destroyer effect is on Cooldown.");
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<LaugicalityPlayer>().DestroyerCooldown = true;
        }
    }
}
