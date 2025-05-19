using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class AnDioChestguard : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("AnDio Chestguard");
            // Tooltip.SetDefault("'Generalist'\nYou are immune to Time Stop");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("50% more Potentia discharges to other Potentias when used\nDioritus Mystic Burst\nDecreases Mystic Burst cooldown" +
            "\nGreatly increased Potentia Regen when time is stopped\n'Out of Time' cooldown is shorter\nAutomatically stops time after taking a hit below 25% life");
        }

        public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 16;
        }

        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.zImmune = true;
        }


        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<DioritusHelmet>() && legs.type == ModContent.ItemType<AndesiaLeggings>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "50% more Potentia discharges to other Potentias when used\nDioritus Mystic Burst\nDecreases Mystic Burst cooldown" +
                "\nGreatly increased Potentia Regen when time is stopped\n'Out of Time' cooldown is shorter\nAutomatically stops time after taking a hit below 25% life";
            modPlayer.GlobalAbsorbRate *= 1.5f;
            if (Laugicality.zaWarudo > 0)
            {
                if (modPlayer.Lux < modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost && modPlayer.MysticMode != 1)
                    modPlayer.Lux += 1f / 4f;
                if (modPlayer.Vis < modPlayer.VisMax + modPlayer.VisMaxPermaBoost && modPlayer.MysticMode != 2)
                    modPlayer.Vis += 1f / 4f;
                if (modPlayer.Mundus < modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost && modPlayer.MysticMode != 3)
                    modPlayer.Mundus += 1f / 4f;
            }
            modPlayer.MysticSwitchCoolRate += 2;
            modPlayer.zCoolDown -= 10 * 60;
            modPlayer.AndioChestguard = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DioritusCore>(), 1);
            recipe.AddIngredient(3081, 32);
            recipe.AddRecipeGroup("TitaniumBars", 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}