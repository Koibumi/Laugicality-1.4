using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Players;
using Laugicality.Utilities;
using Laugicality.Content.NPCs.Bosses;
using Laugicality.Content.NPCs.PreTrio;
using Laugicality.Content.NPCs.RockTwins;
using Laugicality.Content.NPCs.Slybertron;
using Terraria.Localization;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class FrigidChestplate : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("+10% Melee Speed and Range Crit Chance");
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
            player.GetAttackSpeed(DamageClass.Melee) += .1f;
            player.GetCritChance(DamageClass.Ranged) += 10;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
	}
}