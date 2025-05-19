using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Placeable
{
    public class ObsidiumPlant : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Brimlin");
            // Tooltip.SetDefault("'Plants of hell'\nGrows on Lycoris");
        }

        public override void SetDefaults()
        {
            Item.width = 62;
            Item.height = 62;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 150;
            Item.createTile = ModContent.TileType<ObsidiumPlantBulbs>();
            Item.rare = ItemRarityID.Blue;
        }

        public override void UpdateInventory(Player player)
        {
            if (Item.stack % 4 == 0)
                Item.createTile = ModContent.TileType<ObsidiumPlantBulbs>();
            if (Item.stack % 4 == 1)
                Item.createTile = ModContent.TileType<ObsidiumPlantHeart>();
            if (Item.stack % 4 == 2)
                Item.createTile = ModContent.TileType<ObsidiumPlantLeaves>();
            if (Item.stack % 4 == 3)
                Item.createTile = ModContent.TileType<ObsidiumPlantMine>();
        }       
    }
}