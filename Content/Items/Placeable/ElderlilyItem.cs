using Terraria.ID;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Placeable
{
    public class ElderlilyItem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Elderlily");
            // Tooltip.SetDefault("An ancient bloom");
        }
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = Terraria.ModLoader.ModContent.TileType<Content.Tiles.Lycoris>();
        }
    }
}