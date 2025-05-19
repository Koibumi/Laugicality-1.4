using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class PanzerCrystal : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tank Crystal");
            // Tooltip.SetDefault("+10% Damage reduction \n Attackers take damage");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 28;
            Item.value = 100;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.defense = 4;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance += 0.10f;
            if (player.thorns < 1f)
            {
                player.thorns = 0.5f;
            }

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<IronskinGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<EnduranceGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ThornsGem>(), 1);
            recipe.AddTile(ModContent.TileType<CrystalineInfuser>());
            recipe.Register();
        }
    }
}