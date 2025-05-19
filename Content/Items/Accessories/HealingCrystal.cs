using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class HealingCrystal : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+150 Max Life \nGives 1 minute of Potion Sickness");
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
            player.statLifeMax2 += 150;
            player.AddBuff(21, 3600);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LesserHealingGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<HealingGem>(), 1);
            recipe.AddTile(ModContent.TileType<CrystalineInfuser>());
            recipe.Register();
        }
    }
}