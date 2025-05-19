using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class AquaStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Mastery of liquids");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 1000;
            Item.rare = ItemRarityID.LightRed;
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
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<WasserCrystal>(), 1);
            recipe.AddIngredient(ModContent.ItemType<MagmaCrystal>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AngelnCrystal>(), 1);
            recipe.AddTile(ModContent.TileType<MineralEnchanterTile>());
            recipe.Register();
        }
    }
}