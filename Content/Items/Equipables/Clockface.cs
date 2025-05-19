using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Items.Loot;

namespace Laugicality.Content.Items.Equipables
{
    public class Clockface : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Clockface");
            // Tooltip.SetDefault("Reduces the cooldown between Time Stops");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 100;
            Item.rare = ItemRarityID.LightPurple;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.zCoolDown -= 10 * 60;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AndesiaCore>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DioritusCore>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Pipeworks>(), 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddIngredient(3081, 32);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}