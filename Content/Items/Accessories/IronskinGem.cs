using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class IronskinGem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 28;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.defense = 4;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(292, 4);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}