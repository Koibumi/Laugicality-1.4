using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class LichtCrystal : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Light Crystal");
            // Tooltip.SetDefault("Increases Light Vision");
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
            Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
            if (modPlayer.owl)
                player.nightVision = true;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NightOwlGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ShineGem>(), 1);
            recipe.AddTile(ModContent.TileType<CrystalineInfuser>());
            recipe.Register();
        }
    }
}