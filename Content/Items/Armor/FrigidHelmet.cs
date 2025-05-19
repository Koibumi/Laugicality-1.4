using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class FrigidHelmet : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("+10% Melee and Ranged Damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("+4 Defense\n+25% Snowball Damage\nUnleash Ice Shards when struck.");
        }

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<FrigidChestplate>() && legs.type == ModContent.ItemType<FrigidLeggings>();
        }


        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.GetDamage(DamageClass.Ranged) += 0.1f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "+4 Defense\n+25% Snowball Damage\nUnleash Ice Shards when struck.";
            modPlayer.Frigid = true;
            modPlayer.SnowDamage += .25f;
            player.statDefense += 4;

        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 12);
            recipe.AddTile(16);
			recipe.Register();
		}
	}
}