using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class SteampunkJacket : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("8% Increased damage and critical strike chance");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.08f;
            player.GetCritChance(DamageClass.Throwing) += 8;
            player.GetCritChance(DamageClass.Ranged) += 8;
            player.GetCritChance(DamageClass.Magic) += 8;
            player.GetCritChance(DamageClass.Melee) += 8;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}