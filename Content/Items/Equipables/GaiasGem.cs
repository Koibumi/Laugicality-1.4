using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class GaiasGem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gaia's Gem");
            // Tooltip.SetDefault("+25% Mystic Duration\nReduces Cooldown between Mystic Bursts");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDuration += .25f;
            modPlayer.MysticSwitchCoolRate += 1;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 6);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}