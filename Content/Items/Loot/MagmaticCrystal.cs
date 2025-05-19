using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Loot
{
    public class MagmaticCrystal : LaugicalityItem
    {

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.value = 0;
        }
        
    }
}