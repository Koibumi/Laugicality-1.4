using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Loot
{
    public class FrigidEssence : LaugicalityItem
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
            Item.value = 0;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(77);
            recipe.AddIngredient(null, "ObsidiumOre", 3);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
        
    }
}