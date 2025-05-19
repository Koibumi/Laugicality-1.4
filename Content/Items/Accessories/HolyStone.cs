using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class HolyStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Decreased enemy spawn rate \nTake less damage from cold sources \nIncreases heart pickup range \nIncreases life regeneration \n+1 Max Minion \nIncreases max life by 20% \nEquip in last slot for maximum effectiveness");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 1000;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.lifeRegen = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.maxMinions++;
            if (modPlayer.calm)
                player.calmed = true;
            player.resistCold = true;
            player.lifeMagnet = true;
            player.statLifeMax2 += (player.statLifeMax + player.statLifeMax2) / 5 / 20 * 20 - (player.statLifeMax / 5 / 20 * 20);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LebenCrystal>(), 1);
            recipe.AddIngredient(ModContent.ItemType<VerteCrystal>(), 1);
            recipe.AddTile(ModContent.TileType<MineralEnchanterTile>());
            recipe.Register();
        }
    }
}