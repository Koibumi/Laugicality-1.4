using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;
using Laugicality.Utilities;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Loot
{
    public class EtherialDestructionCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Destruction");
            // Tooltip.SetDefault("Your global damage modifier is applied to your defense while in the Etherial");
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
                modPlayer.EtherialDestroyer = true;
            }
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "DestructionCore", 1);
            recipe.AddIngredient(mod, nameof(EtherialEssence), 6);
            recipe.AddTile(null, "AncientEnchanter");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}