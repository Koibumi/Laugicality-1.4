using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Loot;

namespace Laugicality.Content.Items.Equipables
{
    public class AncientNecklace : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ancient Necklace");
            // Tooltip.SetDefault("Increases life and mana regeneration");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.lifeRegen = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaRegenBonus += 10;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(1290, 1);
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}