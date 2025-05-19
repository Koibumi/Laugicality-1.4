using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.ModLoader;

namespace Laugicality.Content.Buffs
{
	public class Aquos : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Aquos");
			// Description.SetDefault("+10% Critical Strike Chance");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Melee) += 10;
            player.GetCritChance(DamageClass.Ranged) += 10;
            player.GetCritChance(DamageClass.Magic) += 10;
            player.GetCritChance(DamageClass.Throwing) += 10;
        }
        
	}
}
