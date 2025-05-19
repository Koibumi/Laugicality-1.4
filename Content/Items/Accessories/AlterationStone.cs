using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class AlterationStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Mastery of land and air");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 1000;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.tileSpeed += 0.25f;
            player.wallSpeed += 0.25f;
            player.blockRange++;
            player.pickSpeed -= 0.25f;
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
            recipe.AddIngredient(ModContent.ItemType<DeinstCrystal>(), 1);
            recipe.AddIngredient(ModContent.ItemType<BewungCrystal>(), 1);
            recipe.AddTile(ModContent.TileType<MineralEnchanterTile>());
            recipe.Register();
        }
    }
}