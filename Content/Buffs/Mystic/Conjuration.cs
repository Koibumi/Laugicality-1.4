using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Buffs.Mystic
{
	public class Conjuration : LaugicalityBuff
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Conjuration");
            // Description.SetDefault("Draw energy from other worlds");
            Main.debuff[Type] = false;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
    }
}
