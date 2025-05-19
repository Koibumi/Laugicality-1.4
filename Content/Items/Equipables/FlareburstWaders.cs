using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Equipables
{
    public class FlareburstWaders : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Provides the ability to walk on water and lava\nGrants immunity to fire blocks and 10 seconds of immunity to lava\nLeave a trail of True Fire as you move");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.value = 100;
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.waterWalk = true;
            player.fireWalk = true;
            player.lavaMax += 10 * 60;
            player.GetModPlayer<LaugicalityPlayer>().TrueFireTrail = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FlamesparkWaders>(), 1);
            recipe.AddIngredient(ModContent.ItemType<CrystalizedMagma>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}