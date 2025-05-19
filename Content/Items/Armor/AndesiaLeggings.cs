using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class AndesiaLeggings : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("+100% Mystic Duration\n+15% Movement Speed");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 12;
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDuration += 1f;
        }
        

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AndesiaCore>(), 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddRecipeGroup("TitaniumBars", 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
	}
}