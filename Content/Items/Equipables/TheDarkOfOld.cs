using Laugicality.Content.Items.Loot;
using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class TheDarkOfOld : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Dark of Old");
            // Tooltip.SetDefault("+8% Mystic Damage.\nAn Additional +8% Mystic Damage when below 50% of your current Potentia");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += .08f;
            switch(modPlayer.MysticMode)
            {
                case 1:
                    if(modPlayer.Lux < (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) / 2)
                        modPlayer.MysticDamage += .08f;
                    break;
                case 2:
                    if (modPlayer.Vis < (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) / 2)
                        modPlayer.MysticDamage += .08f;
                    break;
                default:
                    if (modPlayer.Mundus < (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) / 2)
                        modPlayer.MysticDamage += .08f;
                    break;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DemoniteBar, 8);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}