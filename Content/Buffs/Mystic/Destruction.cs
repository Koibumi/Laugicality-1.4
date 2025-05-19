using Terraria;
using Laugicality.Utilities.Base;
using Terraria.ID;

namespace Laugicality.Content.Buffs.Mystic
{
	public class Destruction : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Destruction");
            // Description.SetDefault("Hell is your catalyst");
            Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
    }
}
