using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class AncientRelic : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Mastery of the world");
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.value = 10000;
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
            if (modPlayer.ww)
                player.waterWalk = true;
            player.gills = true;
            player.ignoreWater = true;
            player.accFlipper = true;
            player.cratePotion = true;
            player.sonarPotion = true;
            player.fishingSkill += 15;
            player.tileSpeed += 0.25f;
            player.wallSpeed += 0.25f;
            player.blockRange++;
            player.pickSpeed -= 0.25f;
            if (modPlayer.SoulStoneMovement)
            {
                if (modPlayer.feather)
                    player.slowFall = true;
            }
            player.moveSpeed += 0.25f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AlterationStone>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AquaStone>(), 1);
            recipe.AddTile(ModContent.TileType<AncientEnchanter>());
            recipe.Register();
        }
    }
}