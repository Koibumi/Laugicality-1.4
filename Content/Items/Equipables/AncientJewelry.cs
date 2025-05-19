using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Equipables
{
    public class AncientJewelry : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ancient Jewelry");
            // Tooltip.SetDefault("Increases life and mana regeneration \n+40 Mana");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.lifeRegen = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaRegenBonus += 10;
            player.statManaMax2 += 40;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BandOfAncients>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AncientNecklace>(), 1);
            recipe.AddTile(114);
            recipe.Register();
        }
    }
}