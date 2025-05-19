using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Placeable
{
    public class CrystalineInfuser : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Crystalline Infuser");
            // Tooltip.SetDefault("Combines Gems into Crystals");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 1;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 150;
            Item.createTile = ModContent.TileType<Tiles.CrystalineInfuser>();
        }

        public override void AddRecipes()
        {
            Recipe arecipe = CreateRecipe();
            arecipe.AddTile(ModContent.TileType<Tiles.LaugicalWorkbench>());
            arecipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 8);
            arecipe.AddIngredient(ModContent.ItemType<DarkShard>(), 1);
            arecipe.AddIngredient(ModContent.ItemType<Content.Items.Placeable.LavaGem>(), 4);
            arecipe.Register();
        }
    }
}