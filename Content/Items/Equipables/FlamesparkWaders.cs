using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Equipables
{
    public class FlamesparkWaders : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Provides the ability to walk on water and lava\nGrants immunity to fire blocks and 8 seconds of immunity to lava\nAttacks inflict 'On Fire!'");
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
            player.lavaMax += 8 * 60;
            player.GetModPlayer<LaugicalityPlayer>().Obsidium = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LavaWaders, 1);
            recipe.AddIngredient(ModContent.ItemType<FireDust>(), 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.LavaWaders, 1);
            recipe1.AddIngredient(ItemID.MagmaStone, 1);
            recipe1.AddTile(TileID.TinkerersWorkbench);
            recipe1.Register();
        }
    }
}