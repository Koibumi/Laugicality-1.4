using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Placeable;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ObsidiumLongcoat : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Immunity to lava, 'On Fire!', and 'Burning'");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[24] = true;
        }
        

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 20);
            recipe.AddIngredient(ModContent.ItemType<LavaGem>(), 8);
            recipe.AddIngredient(ModContent.ItemType<DarkShard>(), 1);
            recipe.AddTile(16);
			recipe.Register();
		}
	}
}