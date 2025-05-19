using Terraria.ModLoader;
using Terraria;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Placeable
{
    public class ObsidiumRock : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Grows Lava Gems over time");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 0;
            Item.createTile = ModContent.TileType<Tiles.ObsidiumRock>();
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(17);
            recipe.AddIngredient(173);
            recipe.AddIngredient(3);
            recipe.Register();
        }
    }
}