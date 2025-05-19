using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class RuneOfEruption : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rune of Eruption");
            // Tooltip.SetDefault("Release a storm of lava when changing Mysticism.");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 36;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticEruptionBurst = true;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RuneOfTheAncients>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Eruption>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}