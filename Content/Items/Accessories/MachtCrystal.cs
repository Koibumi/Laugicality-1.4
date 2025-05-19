using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class MachtCrystal : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Attack Crystal");
            // Tooltip.SetDefault("+10% Damage and critical strike chance \nSet your enemies ablaze");
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
            if (modPlayer.SoulStoneVisuals)
            {
                if (modPlayer.inf)
                    player.AddBuff(116, 2);
            }
            player.GetDamage(DamageClass.Generic) += 0.10f;
            player.GetCritChance(DamageClass.Melee) += 10;
            player.GetCritChance(DamageClass.Ranged) += 10;
            player.GetCritChance(DamageClass.Magic) += 10;
            player.GetCritChance(DamageClass.Throwing) += 10;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RageGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<WrathGem>(), 1);
            recipe.AddIngredient(ModContent.ItemType<InfernoGem>(), 1);
            recipe.AddTile(ModContent.TileType<CrystalineInfuser>());
            recipe.Register();
        }
    }
}