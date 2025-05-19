using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class ManaGem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+40 Mana");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 28;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statManaMax2 += 40;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(189, 4);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}