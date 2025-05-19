using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;
using Laugicality.Content.Items.Loot;

namespace Laugicality.Content.Items.Equipables
{
    public class ConjurationCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Conjuration Damage\n+25% Conjuration Overflow\nAbsorb 25% more Mundus when using Vis and Lux");
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
            modPlayer.ConjurationDamage += .1f;
            modPlayer.MundusOverflow += .25f;
            modPlayer.MundusAbsorbRate += .25f;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<VerdiDust>(), 2);
            recipe.AddIngredient(ModContent.ItemType<AlbusDust>(), 2);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}