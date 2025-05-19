using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Loot
{
    public class FrostShard : LaugicalityItem
    {

        public override void SetDefaults()
        {
            Item.width = 14;
            Item.height = 26;
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