using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;
using Laugicality.Utilities;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Loot
{
    public class EtherialIllusionCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mechanical Rage");
            // Tooltip.SetDefault("In the Etherial, deal more damage the lower your life is");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
            {
                modPlayer.EtherialPrime = true;
            }
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "IllusionCore", 1);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 6);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}