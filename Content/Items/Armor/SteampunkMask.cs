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
	public class SteampunkMask : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("+4 Minion capacity");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("+18% Minion damage \nAttacks inflict 'Steamy!'");
            ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = true;
        }

        public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Pink;
			Item.defense = 14;
		}

	    public override bool IsArmorSet(Item head, Item body, Item legs) => base.IsArmorSet(head, body, legs) && body.type == ModContent.ItemType<SteampunkJacket>() && legs.type == ModContent.ItemType<SteampunkBoots>();

        public virtual void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;
            drawAltHair = true;
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += 4;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.Steamified = true;
            player.setBonus = "+18% Minion damage \nAttacks inflict 'Steamy!' ";
            player.GetDamage(DamageClass.Summon) += 0.18f;
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