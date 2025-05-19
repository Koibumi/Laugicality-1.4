using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class IllusionCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Illusion Damage\n+25% Illusion Overflow\nAbsorb 25% more Vis when using Mundus and Lux");
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
            modPlayer.IllusionDamage += .1f;
            modPlayer.VisOverflow += .25f;
            modPlayer.VisAbsorbRate += .25f;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<RegisDust>(), 2);
            recipe.AddIngredient(ModContent.ItemType<AlbusDust>(), 2);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}