using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Materials
{
	public class GalacticFragment : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("'The secrets of the universe swirl around this fragment'");
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }
        public override void SetDefaults()
		{
			Item.width = 20;
            Item.height = 20;
			Item.maxStack = 99;
			Item.rare = ItemRarityID.Cyan;
			Item.useAnimation = 1;
			Item.useTime = 15;
			Item.useStyle = 1;
		}
        
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(3457, 1); //Nebula Fragment
            recipe.AddIngredient(3459, 1); //Stardust Fragment
            recipe.AddTile(412);
            recipe.Register();
        }
	}
}