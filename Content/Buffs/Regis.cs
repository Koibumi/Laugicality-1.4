using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class Regis : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Regis");
			// Description.SetDefault("+10% Life Regen");
			Main.buffNoSave[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen = (int)(player.lifeRegen * 1.1f);
        }
        
	}
}
