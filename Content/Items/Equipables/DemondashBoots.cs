using Laugicality.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Utilities;

namespace Laugicality.Content.Items.Equipables
{
    public class DemondashBoots : LaugicalityItem
    {
        int dashDelay = 0;
        int dashCooldown = 0;
        int trail = 0;
        int dashDir = 0;

        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Allows the wearer to dash\nReduced cooldown between dashes\nIncreased movement speed");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.defense = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += .15f;
            int dashCooldownMax = 60;
            int trailLength = 45;

            float dashSpeed = 12;

            if (!player.mount.Active && player.grappling[0] == -1 && dashCooldown <= 0)
            {
                if (player.controlRight && player.releaseRight)
                {
                    if (dashDelay > 0 && dashDir == 1)
                    {
                        dashCooldown = dashCooldownMax;
                        trail = trailLength;
                        player.velocity.X = dashSpeed;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(ModContent.DustType<Black>(), 20);
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 1;
                    }
                }
                if (player.controlLeft && player.releaseLeft)
                {
                    if (dashDelay > 0 && dashDir == 2)
                    {
                        dashCooldown = dashCooldownMax;
                        trail = trailLength;
                        player.velocity.X = -dashSpeed;
                        player.GetModPlayer<LaugicalityPlayer>().DustBurst(ModContent.DustType<Black>(), 20);
                    }
                    else
                    {
                        dashDelay = 15;
                        dashDir = 2;
                    }
                }
            }
            if (dashDelay > 0)
                dashDelay--;
            if (dashCooldown > 0)
                dashCooldown--;
            if(trail > 0)
            {
                trail--;
                player.GetModPlayer<LaugicalityPlayer>().DustTrail(ModContent.DustType<Black>(), 2);
            }
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkfootBoots>(), 1);
            recipe.AddIngredient(ItemID.BandofStarpower, 1);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<BloodfootBoots>(), 1);
            recipe1.AddIngredient(ItemID.PanicNecklace, 1);
            recipe1.AddTile(TileID.TinkerersWorkbench);
            recipe1.Register();
        }
    }
}