using Laugicality.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Placeable;
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
	[AutoloadEquip(EquipType.Head)]
	public class ObsidiumHelmet : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("+15% Mystic Damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Magmatic Mystic Burst\nDecreased Mystic Burst cooldown\n+20% Mystic Burst damage\nAttacks inflict 'On Fire!'");
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
            modPlayer.MysticDamage += 0.15f;
        }

        

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Magmatic Mystic Burst\nDecreased Mystic Burst cooldown\n+20% Mystic Burst damage\nAttacks inflict 'On Fire!'";
            modPlayer.Obsidium = true;
            modPlayer.MysticObsidiumBurst = true;
            modPlayer.MysticSwitchCoolRate += 2;
            modPlayer.MysticBurstDamage += .2f;
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