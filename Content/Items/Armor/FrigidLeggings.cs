using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class FrigidLeggings : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Immunity to Frostburn, Chilled, and Frozen\n+10% Movement Speed");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 6;
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.10f;
            player.buffImmune[44] = true;
            player.buffImmune[46] = true;
            player.buffImmune[47] = true;
        }

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 14);
            recipe.AddTile(16);
            recipe.Register();
        }
	}
}