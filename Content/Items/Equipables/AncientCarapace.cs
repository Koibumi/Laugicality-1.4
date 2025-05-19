using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Tiles;

namespace Laugicality.Content.Items.Equipables
{
    public class AncientCarapace : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ancient Carapace");
            // Tooltip.SetDefault("Your Defense is added to your Potentia\nIncreased endurance as Potentia drops\nIncreased Mystic Damage for a time after taking damage");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            modPlayer.LuxMax += player.statDefense;
            modPlayer.VisMax += player.statDefense;
            modPlayer.MundusMax += player.statDefense;

            float currPotentia = 1;
            float currMaxPotentia = 1;

            switch (modPlayer.MysticMode)
            {
                case 1:
                    currPotentia = modPlayer.Lux;
                    currMaxPotentia = modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost;
                    break;
                case 2:
                    currPotentia = modPlayer.Vis;
                    currMaxPotentia = modPlayer.VisMax + modPlayer.VisMaxPermaBoost;
                    break;
                default:
                    currPotentia = modPlayer.Mundus;
                    currMaxPotentia = modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost;
                    break;
            }
            if (currMaxPotentia == 0)
                currMaxPotentia = 1;

            player.endurance += (1 - (currPotentia / currMaxPotentia)) * .15f;

            modPlayer.Carapace = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ShadowScale, 16);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}