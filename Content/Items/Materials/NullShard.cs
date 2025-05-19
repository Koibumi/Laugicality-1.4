using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Materials
{
    public class NullShard : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.value = 0;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(null, "NullShard", 4);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
        
    }
}