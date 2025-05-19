using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Items.Consumables.Potions;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class FaeryInABottle : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Faery in a Bottle");
            // Tooltip.SetDefault("Automatically switch Mysticism when you run out of the current Potentia");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            switch (modPlayer.MysticMode)
            {
                case 1:
                    if (modPlayer.CurrentLuxCost > modPlayer.Lux)
                        modPlayer.MysticSwitch();
                    break;
                case 2:
                    if (modPlayer.CurrentVisCost > modPlayer.Vis)
                        modPlayer.MysticSwitch();
                    break;
                default:
                    if (modPlayer.CurrentMundusCost > modPlayer.Mundus)
                        modPlayer.MysticSwitch();
                    break;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FireflyinaBottle);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 5);
            recipe.AddIngredient(ModContent.ItemType<MysticaPotion>(), 1);
            recipe.AddTile(ModContent.TileType<Tiles.AlchemicalInfuser>());
            recipe.Register();
        }
    }
}