using Terraria;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
	public class IllusionBoost : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Illusion Power");
			// Description.SetDefault("'The mind's energy strengthens you.'\n+100% Mystic Duration");
			Main.buffNoSave[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex)
		{
            LaugicalityPlayer.Get(player).MysticDuration += 1f;
        }
        
	}
}
