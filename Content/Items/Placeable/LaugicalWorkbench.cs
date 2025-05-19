using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Placeable
{
    public class LaugicalWorkbench : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("For crafting things to craft things. \n'It's completely logical!'");
        }

        public override void SetDefaults()
        {
            Item.width = 27;
            Item.height = 15;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 150;
            Item.createTile = ModContent.TileType<Tiles.LaugicalWorkbench>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(16);
            recipe.AddIngredient(9, 20);
            recipe.AddIngredient(2340, 40);
            recipe.AddIngredient(363);
            recipe.AddIngredient(2343);
            recipe.AddIngredient(997);
            recipe.Register();
        }
    }
}