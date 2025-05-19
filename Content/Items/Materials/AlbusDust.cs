using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Tiles;

namespace Laugicality.Content.Items.Materials
{
	public class AlbusDust : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("'A whiff of the mystical'");
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
            recipe.AddIngredient(ItemID.Diamond, 1);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 1);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();       
        }
	}
}