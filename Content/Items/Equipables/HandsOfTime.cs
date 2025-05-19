using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class HandsOfTime : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Hands of Time");
            // Tooltip.SetDefault("Increases the duration of Time Stop");
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
            modPlayer.zaWarudoDuration += (int)(1.75 * 60);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DioritusCore>(), 1);
            recipe.AddIngredient(ModContent.ItemType<CogOfKnowledge>(), 1);
            recipe.AddIngredient(3081, 32);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}