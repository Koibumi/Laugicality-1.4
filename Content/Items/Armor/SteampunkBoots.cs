using Laugicality.Content.Buffs;
using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class SteampunkBoots : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Insulated- Immune to 'Steamy'\n+10% Movement Speed");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 14;
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.10f;
            player.buffImmune[ModContent.BuffType<Steamy>()] = true;
            player.buffImmune[144] = true;
        }
        

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 18);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}