using Laugicality.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Utilities;

namespace Laugicality.Content.Items.Equipables
{
    public class FrostburstBoots : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Allows flight, super fast running, and extra mobility on ice\nGrants the ability to double jump\nNegates fall damage\n15% increased movement speed");
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
            player.moveSpeed += .15f;
            player.accRunSpeed += 4.5f;
            player.rocketBoots = 3;
            player.iceSkate = true;
            player.GetJumpState(ExtraJump.BlizzardInABottle).Enable();
            player.noFallDmg = true;
            player.jumpSpeedBoost += 3;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddRecipeGroup(ModRecipe.COLORED_BALLOON_GROUP);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
        }
    }
}