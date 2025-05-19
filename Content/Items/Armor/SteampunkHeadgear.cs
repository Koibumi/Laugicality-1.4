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
	public class SteampunkHeadgear : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+20% Throwing Damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("+33% Throwing Velocity \nAttacks inflict 'Steamy!' ");
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
            player.GetDamage(DamageClass.Throwing) += .2f;
        }

        public override void UpdateArmorSet(Player player)
        {  player.setBonus = SetBonusText.Value;
            player.setBonus = "+33% Throwing Velocity, \nAttacks inflict 'Steamy!' ";
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.Steamified = true;
            player.ThrownVelocity += .33f;
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