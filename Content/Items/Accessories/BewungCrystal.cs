using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class BewungCrystal : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Movement Crystal");
            // Tooltip.SetDefault("Slows falling speed \n+25% Movement speed");
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
            if (modPlayer.SoulStoneMovement)
            {
                if (modPlayer.feather)
                    player.slowFall = true;
            }
            player.moveSpeed += 0.25f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FeatherfallGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SwiftnessGem>(), 1);
            recipe.AddTile(ModContent.TileType<CrystalineInfuser>());
            recipe.Register();
        }
    }
}