using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class RuneOfTheAncients : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rune of the Ancients");
            // Tooltip.SetDefault("Release a sandstorm when changing Mysticism.");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 36;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticSandBurst = true;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(169, 24);
            recipe.AddIngredient(607, 16);
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}