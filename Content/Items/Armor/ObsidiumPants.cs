using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Placeable;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ObsidiumPants : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Provides waterwalking and free movement in liquids \n+10% Movement Speed");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 7;
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.10f;
            player.waterWalk = true;
            player.ignoreWater = true;
        }
        

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumRock>(), 20);
            recipe.AddTile(16);
			recipe.Register();
		}
	}
}