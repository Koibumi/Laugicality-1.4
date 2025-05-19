using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Materials
{
	public class RegisDust : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("'The wealth of knowledge'");
        }
        public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 1;
			Item.useTime = 15;
			Item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ItemID.Amethyst, 1);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 1);
            recipe.AddTile(ModContent.TileType<Tiles.AlchemicalInfuser>());
            recipe.Register();
        }
	}
}