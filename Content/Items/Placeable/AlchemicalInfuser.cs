using Laugicality.Content.Items.Loot;
using Terraria;
using Laugicality.Utilities.Base;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Equipables;

namespace Laugicality.Content.Items.Placeable
{
    public class AlchemicalInfuser : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Infuses Potions into Gems");
        }

        public override void SetDefaults()
        {
            Item.width = 54;
            Item.height = 27;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 150;
            Item.createTile = ModContent.TileType<Tiles.AlchemicalInfuser>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(ModContent.TileType<Tiles.LaugicalWorkbench>());
            recipe.AddIngredient(9, 20);
            recipe.AddIngredient(170, 8);
            recipe.AddIngredient(31, 8);
            recipe.AddIngredient(8, 4);
            recipe.Register();
        }
    }
}