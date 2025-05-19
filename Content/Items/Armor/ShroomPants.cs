using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ShroomPants : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shroom Stalk");
            // Tooltip.SetDefault("+2% Mystic Damage\n+8% Movement Speed");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}

        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += .02f;
            player.moveSpeed += 0.08f;
        }
        

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(183, 10);
            recipe.AddIngredient(176, 8);
            recipe.AddTile(16);
            recipe.Register();
        }
	}
}