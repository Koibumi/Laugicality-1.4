using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Materials
{
    public class MagmaSnapper : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("'Don't get your hand too close.'");
        }

        public override void SetDefaults()
        {
            Item.width = 66;
            Item.height = 58;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.value = 0;
            Item.rare = ItemRarityID.Blue;
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