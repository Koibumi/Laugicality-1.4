using Laugicality.Content.Items.Equipables;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Utilities
{
    public class CR : ModSystem // CR - Collaborate Recipe
    {

        public override void AddRecipes()
        {
            if (ModLoader.TryGetMod("CalamityMod", out Mod CalamityMod))
            {
                var angelTreads = CalamityMod.Find<ModItem>("AngelTreads").Type;
                var coreOfCalamity = CalamityMod.Find<ModItem>("CoreofCalamity").Type;
                var lifeAlloy = CalamityMod.Find<ModItem>("LifeAlloy").Type;
                var tracersCelestial = CalamityMod.Find<ModItem>("TracersCelestial").Type;

                Recipe recipe = Recipe.Create(ModContent.ItemType<SteamsparkJetboots>());
                recipe.AddIngredient(angelTreads, 1);
                recipe.AddIngredient(ItemID.Jetpack, 1);
                recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 16);
                recipe.AddIngredient(ModContent.ItemType<Gear>(), 25);
                recipe.AddTile(TileID.MythrilAnvil);
                recipe.Register();

                Recipe srecipe = Recipe.Create(tracersCelestial);
                srecipe.AddIngredient(ModContent.ItemType<SteamsparkJetboots>(), 1);
                srecipe.AddRecipeGroup("AnyWings");
                srecipe.AddIngredient(ItemID.LunarBar, 5);
                srecipe.AddIngredient(coreOfCalamity, 3);
                srecipe.AddIngredient(lifeAlloy, 5);
                srecipe.AddTile(TileID.LunarCraftingStation);
                srecipe.Register();
            }
            else
            {
                ModRecipe._steamsparkJetboots = true;
            }
        }
    }
}