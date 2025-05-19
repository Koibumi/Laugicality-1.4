using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class SightStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Vision Stone");
            // Tooltip.SetDefault("Mastery of light");
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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.spelunker)
                player.findTreasure = true;
            Lighting.AddLight((int)(player.position.X + (float)(player.width / 2)) / 16, (int)(player.position.Y + (float)(player.height / 2)) / 16, 0.8f, 0.95f, 1f);
            if (modPlayer.owl)
                player.nightVision = true;
            if (modPlayer.hunter)
                player.detectCreature = true;
            if (modPlayer.danger)
                player.dangerSense = true;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<LichtCrystal>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SichtCrystal>(), 1);
            recipe.AddTile(ModContent.TileType<MineralEnchanterTile>());
            recipe.Register();
        }
    }
}