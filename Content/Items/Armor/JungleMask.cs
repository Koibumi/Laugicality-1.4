using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class JungleMask : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Jungle Hood");
            // Tooltip.SetDefault("Increases maximum mana by 20\n+100% Mystic Duration");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Mystic damage increased by 12%\nYour Max Mana is added to your Potentias\nIncreased regen for Potentia you aren't using.");
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
        }

        public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == 229 && legs.type == 230;
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.statManaMax2 += 20;
            modPlayer.MysticDuration += 1f;
        }
        
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Mystic damage increased by 12%\nYour Max Mana is added to your Potentias\nIncreased regen for Potentia you aren't using.";
            modPlayer.MysticDamage += .12f;
            modPlayer.LuxMax += player.statManaMax2 / 3;
            modPlayer.VisMax += player.statManaMax2 / 3;
            modPlayer.MundusMax += player.statManaMax2 / 3;

            modPlayer.LuxUnuseRegen += .03f;
            modPlayer.VisUnuseRegen += .03f;
            modPlayer.MundusUnuseRegen += .03f;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(331, 8);
            recipe.AddIngredient(1124, 4);
            recipe.AddTile(16);
			recipe.Register();
		}
	}
}