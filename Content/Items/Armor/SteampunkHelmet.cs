using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class SteampunkHelmet : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Steampunk Hat");
            // Tooltip.SetDefault("+20% Mystic Damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("+200% Mystic Duration\nSwitching Mysticisms unleashes a burst of Steam\nDecreased Mystic Burst cooldown\nAttacks inflict 'Steamy!', which makes enemies take more damage");
        }

        public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 14;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<SteampunkJacket>() && legs.type == ModContent.ItemType<SteampunkBoots>();
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += .17f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            player.setBonus = "+200% Mystic Duration\nSwitching Mysticisms unleashes a burst of Steam\nDecreased Mystic Burst cooldown\nAttacks inflict 'Steamy!', which makes enemies take more damage";
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.Steamified = true;
            modPlayer.MysticSteamBurst = true;
            modPlayer.MysticDuration += 2f;
            modPlayer.MysticSwitchCoolRate += 3;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}