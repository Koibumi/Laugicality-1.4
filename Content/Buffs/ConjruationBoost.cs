using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class ConjurationBoost : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Conjuration Power");
			// Description.SetDefault("'Otherworldly energy strengthens you.'\n+50% Overflow");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer.Get(player).GlobalOverflow += .5f;
        }
        
	}
}
