using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Loot
{
    public class RoyalIce : LaugicalityItem
    {

        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("'A Queen's Tear'");
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.value = 0;
        }

    }
}