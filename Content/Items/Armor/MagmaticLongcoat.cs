using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class MagmaticLongcoat : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Immunity to lava, 'On Fire!', and 'Burning'\n+10% Throwing critical strike chance");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
            player.GetCritChance(DamageClass.Throwing) += 10;
        }
        

		public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ObsidiumLongcoat>(), 1);
            recipe.AddRecipeGroup("TitaniumBars", 18);
            recipe.AddIngredient(ModContent.ItemType<MagmaticCrystal>(), 3);
            recipe.AddIngredient(ModContent.ItemType<MagmaticCluster>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
	}
}