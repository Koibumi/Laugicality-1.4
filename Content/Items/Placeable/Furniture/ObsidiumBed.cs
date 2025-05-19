using Laugicality.Content.Tiles.Furniture;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Placeable.Furniture
{
    public class ObsidiumBed : LaugicalityItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 150;
            Item.createTile = ModContent.TileType<ObsidiumBedTile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.WorkBenches);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumRock>(), 8);
            //recipe.AddIngredient(ModContent.ItemType<Lycoris>(), 4);
            recipe.Register();
        }
    }
}