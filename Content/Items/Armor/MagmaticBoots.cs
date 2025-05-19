using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class MagmaticBoots : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("+100% Mystic Duration\n+50%Throwing Velocity\n+15% Movement Speed\nProvides waterwalking and free movement in liquids");
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
            player.ThrownVelocity += .5f;
            player.waterWalk = true;
            player.ignoreWater = true;
        }
        

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ObsidiumPants>(), 1);
            recipe.AddRecipeGroup("TitaniumBars", 10);
            recipe.AddIngredient(ModContent.ItemType<MagmaticCrystal>(), 2);
            recipe.AddIngredient(ModContent.ItemType<MagmaticCluster>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
	}
}