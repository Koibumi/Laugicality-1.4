using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Tiles;

namespace Laugicality.Content.Items.Materials
{
	public class ArcaneShard : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Used as a catalyst in many transmutations\n'A sliver of Magic'");
        }
        public override void SetDefaults()
		{
			Item.width = 14;
			Item.height = 22;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 1;
			Item.useTime = 15;
			Item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(5);
            recipe.AddIngredient(ItemID.ManaCrystal, 1);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
	}
}