using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;
using Laugicality.Utilities;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Loot
{
    public class EtherialFrost : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Byfrost");
            // Tooltip.SetDefault("Attacks inflict 'Frostbite'");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
            {
                modPlayer.EtherialFrost = true;
            }
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(2328, 4);
            recipe.AddTile(null, "AlchemicalInfuser");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}