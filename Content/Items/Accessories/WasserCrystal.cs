using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class WasserCrystal : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aqua Crystal");
            // Tooltip.SetDefault("Mastery of water");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 28;
            Item.value = 100;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.gills = true;
            player.ignoreWater = true;
            player.accFlipper = true;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GillsGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<FlipperGem>(), 1);
            recipe.AddTile(ModContent.TileType<CrystalineInfuser>());
            recipe.Register();
        }
    }
}