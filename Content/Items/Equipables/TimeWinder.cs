using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class TimeWinder : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Time Winder");
            // Tooltip.SetDefault("+15% Increased Damage while time is stopped");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 100;
            Item.rare = ItemRarityID.LightPurple;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if(Laugicality.zaWarudo > 0)
            {
                player.GetDamage(DamageClass.Generic) += 0.15f;
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AndesiaCore>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SteamTank>(), 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}