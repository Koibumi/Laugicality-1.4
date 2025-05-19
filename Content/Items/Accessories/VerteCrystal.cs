using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class VerteCrystal : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Harmony Crystal");
            // Tooltip.SetDefault("Decreased enemy spawn rate\nTake less damage from cold sources\n+1 Max Minion");
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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.maxMinions++;
            if (modPlayer.calm)
                player.calmed = true;
            player.resistCold = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<CalmingGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<WarmthGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SummoningGem>(), 1);
            recipe.AddTile(ModContent.TileType<CrystalineInfuser>());
            recipe.Register();
        }
    }
}