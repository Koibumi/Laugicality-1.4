using Laugicality.Content.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Equipables
{
    public class AquaflameWaders : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Dominion over liquids\nLeave a trail of True Fire as you move");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.value = 100;
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaImmune = true;
            player.buffImmune[24] = true;
            player.gills = true;
            player.ignoreWater = true;
            player.accFlipper = true;
            player.GetModPlayer<LaugicalityPlayer>().TrueFireTrail = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FlareburstWaders>(), 1);
            recipe.AddIngredient(ModContent.ItemType<MagmaCrystal>(), 1);
            recipe.AddIngredient(ModContent.ItemType<WasserCrystal>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}