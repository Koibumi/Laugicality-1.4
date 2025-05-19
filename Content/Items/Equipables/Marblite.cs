using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class Marblite : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Marblite");
            // Tooltip.SetDefault("+10% Mystic Damage\nGet 'For Honor' and 'For Glory' when switching Mysticism.");
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticMarblite = true;
            modPlayer.MysticDamage += .1f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DioritusCore>(), 1);
            recipe.AddIngredient(3081, 25);
            recipe.AddIngredient(3086, 25);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}