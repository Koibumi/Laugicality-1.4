using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShroomHelmet : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shroom Cap");
            // Tooltip.SetDefault("+4% Mystic Damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Attacks cast using Overflow can pass through walls\nWhen at Max Potentia, Overflow slowly accrues over time");
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = true;
        }

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.defense = 2;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<ShroomChest>() && legs.type == ModContent.ItemType<ShroomPants>();
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += .04f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Attacks cast using Overflow can pass through walls\nWhen at Max Potentia, Overflow slowly accrues over time";
            modPlayer.ShroomOverflow = 2;

            if (modPlayer.MysticHold > 0)
            {
                if (modPlayer.Lux >= modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost && modPlayer.Lux < (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Lux += 1f / 20f;
                if (modPlayer.Vis >= modPlayer.VisMax + modPlayer.VisMaxPermaBoost && modPlayer.Vis < (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Vis += 1f / 20f;
                if (modPlayer.Mundus >= modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost && modPlayer.Mundus < (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Mundus += 1f / 20f;
            }
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(183, 10);
            recipe.AddIngredient(176, 6);
            recipe.AddTile(16);
			recipe.Register();
		}
	}
}