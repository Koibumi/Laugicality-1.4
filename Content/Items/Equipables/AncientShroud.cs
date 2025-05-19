using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Tiles;

namespace Laugicality.Content.Items.Equipables
{
    public class AncientShroud : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ancient Shroud");
            // Tooltip.SetDefault("Your Potentia is added to your Max Life\nIncreased Life Regen as Potentia drops\nIncreased Mystic Damage as Life drops");
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

            int minPotentia = (int)(modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost);

            if(modPlayer.VisMax + modPlayer.VisMaxPermaBoost < minPotentia)
                minPotentia = (int)(modPlayer.VisMax + modPlayer.VisMaxPermaBoost);

            if (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost < minPotentia)
                minPotentia = (int)(modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost);

            player.statLifeMax2 += minPotentia;
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

            player.lifeRegen += (int)(6 * (1 - (currPotentia / currMaxPotentia)));
            modPlayer.MysticDamage += .2f * (1-((float)player.statLife / (float)player.statLifeMax2));
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TissueSample, 16);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}