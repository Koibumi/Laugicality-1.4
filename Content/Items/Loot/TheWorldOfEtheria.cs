using Laugicality.Utilities;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;

namespace Laugicality.Content.Items.Loot
{
    public class TheWorldOfEtheria : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The World of Etheria");
            // Tooltip.SetDefault("Your projectiles are immune to Time Stop when in the Etherial");
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.value = 100000;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
                modPlayer.EtherialAnDio = true;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DioritusCore", 1);
            recipe.AddIngredient(null, "AndesiaCore", 1);
            recipe.AddTile(16);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}