using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Equipables
{
    public class Bloat : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Bloat");
            // Tooltip.SetDefault("+100% Max Life. You cannot go above 50% of your Max Life.");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 *= 2;
            if (player.statLife > (int)(player.statLifeMax2 * .5))
                player.statLife = (int)(player.statLifeMax2 * .5);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TissueSample, 12);
            recipe.AddIngredient(ItemID.ShadowScale, 8);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }
    }
}