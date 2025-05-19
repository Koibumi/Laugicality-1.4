using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class MoltenTank : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+33% Mystic Duration\n+10% Overflow Damage");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDuration += .25f;
            modPlayer.OverflowDamage += .1f;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 10);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}