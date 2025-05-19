using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Placeable
{
    public class BrassFAN : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Brass F.A.N.");
            // Tooltip.SetDefault("It's a 'Fast Acceleration Node'\nBoosts you horizontally");
        }

        public override void SetDefaults()
        {
            Item.width = 54;
            Item.height = 54;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 150;
            Item.createTile = ModContent.TileType<Tiles.BrassFAN>();
        }

        public override void UpdateInventory(Player player)
        {
            if (player.direction == 1)
                Item.createTile = ModContent.TileType<Tiles.BrassFANRight>();
            else
                Item.createTile = ModContent.TileType<Tiles.BrassFAN>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 4);
            recipe.AddIngredient(ModContent.ItemType<Gear>(), 4);
            recipe.Register();
        }
    }
}