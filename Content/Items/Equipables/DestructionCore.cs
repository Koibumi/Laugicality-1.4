using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;

namespace Laugicality.Content.Items.Equipables
{
    public class DestructionCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Destruction Damage\n+25% Destruction Overflow\nAbsorb 25% more Lux when using Vis and Mundus");
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
            modPlayer.DestructionDamage += .1f;
            modPlayer.LuxOverflow += .25f;
            modPlayer.LuxAbsorbRate += .25f;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<DarkShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AuraDust>(), 2);
            recipe.AddIngredient(ModContent.ItemType<AlbusDust>(), 2);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}