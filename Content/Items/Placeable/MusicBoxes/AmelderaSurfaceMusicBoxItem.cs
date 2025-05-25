using Laugicality.Content.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Placeable.MusicBoxes
{
    public class AmelderaSurfaceMusicBoxItem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Music Box (Calm Obsidium Surface)");
            // Tooltip.SetDefault("");
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
            Item.createTile = ModContent.TileType<Tiles.MusicBoxes.AmelderaSurfaceMusicBox>();
            Item.accessory = true;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(ModContent.TileType<Tiles.LaugicalWorkbench>());
            recipe.AddIngredient(ItemID.MusicBox, 1);
            recipe.AddIngredient(ModContent.ItemType<ElderlilyItem>(), 5);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumRock>(), 20);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}