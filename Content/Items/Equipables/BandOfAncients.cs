using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Loot;

namespace Laugicality.Content.Items.Equipables
{
    public class BandOfAncients : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Band of Ancients");
            // Tooltip.SetDefault("+40 Mana");
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
            player.statManaMax2 += 40;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(111, 1);
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}