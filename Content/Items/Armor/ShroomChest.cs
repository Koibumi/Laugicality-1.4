using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ShroomChest : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shroom Amalgam");
            // Tooltip.SetDefault("+2% Mystic Damage\n+20% Overflow");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 3;
        }

        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += .02f;
            modPlayer.GlobalOverflow += .2f;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(183, 16);
            recipe.AddIngredient(176, 12);
            recipe.AddIngredient(109, 1);
            recipe.AddTile(16);
            recipe.Register();
        }
	}
}