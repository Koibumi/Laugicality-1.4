using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Placeable;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ObsidiumBand : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("+15% Throwing Damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("+33% Throwing Velocity \n+4 Defense \nAttacks inflict 'On Fire!' ");
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = true;
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
        }

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ObsidiumLongcoat>() && legs.type == ModContent.ItemType<ObsidiumPants>();
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.GetDamage(DamageClass.Throwing) += 0.15f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "+33% Throwing Velocity \n+4 Defense \nAttacks inflict 'On Fire!' ";
            modPlayer.Obsidium = true;

            player.ThrownVelocity += .33f;
            player.statDefense += 4;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<LavaGem>(), 4);
            recipe.AddTile(16);
			recipe.Register();
		}
	}
}