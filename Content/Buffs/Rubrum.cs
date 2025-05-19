using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ModLoader;

namespace Laugicality.Content.Buffs
{
	public class Rubrum : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Rubrum");
			// Description.SetDefault("+10% Damage");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Generic) += 0.1f;
        }
	}
}
