using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Items.Loot;

namespace Laugicality.Content.Items.Equipables
{
    public class CoreOfAnDio : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sands of Time");
            // Tooltip.SetDefault("You are immune to Time Stop");
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.value = 100;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.zImmune = true;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DioritusCore>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AndesiaCore>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}