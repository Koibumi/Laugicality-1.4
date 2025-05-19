using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class ReichCrystal : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rogue Crystal");
            // Tooltip.SetDefault("+10% Ranged damage\n20% Chance to not use ammo\nIncreased Enemy Spawns");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 28;
            Item.value = 100;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.ammoCost80 = true;
            player.GetDamage(DamageClass.Ranged) += 0.10f;
            if (!modPlayer.battle)
                player.enemySpawns = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ArcheryGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AmmoReservationGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<BattleGem>(), 1);
            recipe.AddTile(ModContent.TileType<CrystalineInfuser>());
            recipe.Register();
        }
    }
}