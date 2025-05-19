using Terraria.ID;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Materials
{
	public class ChilledBar : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Very Cold");
        }
        public override void SetDefaults()
		{
			Item.width = 30;
			Item.height = 30;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 1;
			Item.useTime = 15;
			Item.useStyle = 1;
		}
	}
}