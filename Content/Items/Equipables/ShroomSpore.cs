using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;

namespace Laugicality.Content.Items.Equipables
{
    public class ShroomSpore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Spore Cloud");
            // Tooltip.SetDefault("Unleash Spores when changing Mysticism.");
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.value = 100;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticShroomBurst = true;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(183, 16);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}