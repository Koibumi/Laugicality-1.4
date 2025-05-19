using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class LebenCrystal : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Vitality Crystal");
            // Tooltip.SetDefault("Increases heart pickup range \nIncreases life regeneration \nIncreases max life by 20% \nEquip in last slot for maximum effectiveness");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 28;
            Item.value = 100;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.lifeRegen = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeMagnet = true;
            player.statLifeMax2 += (player.statLifeMax + player.statLifeMax2) / 5 / 20 * 20 - (player.statLifeMax / 5 / 20 * 20);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LifeforceGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<HeartreachGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<RegenerationGem>(), 1);
            recipe.AddTile(ModContent.TileType<CrystalineInfuser>());
            recipe.Register();
        }
    }
}