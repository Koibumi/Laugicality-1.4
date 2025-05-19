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
	public class AnDioChestplate : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("AnDio Chestplate");
            // Tooltip.SetDefault("'Specialist'\nYou are immune to Time Stop");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("+50 to all Potentias\n25% Reduced Potentia useage\nThe lower your Potentia, the higher your Mystic damage\nPotentia does not decrease when time is stopped\nTime stop lasts longer\nAutomatically stops time after taking a hit below 25% life");
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
            player.setBonus = "+50 to all Potentias\n25% Reduced Potentia useage\nThe lower your Potentia, the higher your Mystic damage\nPotentia does not decrease when time is stopped\nTime stop lasts longer\nAutomatically stops time after taking a hit below 25% life";
            modPlayer.zaWarudoDuration += 2 * 60;
            modPlayer.AndioChestplate = true;
            modPlayer.LuxMax += 50;
            modPlayer.VisMax += 50;
            modPlayer.MundusMax += 50;
            if (modPlayer.MysticMode == 1 && modPlayer.Lux < (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost))
                modPlayer.MysticDamage += (1 - (modPlayer.Lux / (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost))) / 5;
            if (modPlayer.MysticMode == 2 && modPlayer.Vis < (modPlayer.VisMax + modPlayer.VisMaxPermaBoost))
                modPlayer.MysticDamage += (1 - (modPlayer.Vis / (modPlayer.VisMax + modPlayer.VisMaxPermaBoost))) / 5;
            if (modPlayer.MysticMode == 3 && modPlayer.Mundus < (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost))
                modPlayer.MysticDamage += (1 - (modPlayer.Mundus / (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost))) / 5;
            modPlayer.GlobalPotentiaUseRate *= .75f;
            if (Laugicality.zaWarudo > 0)
                modPlayer.GlobalPotentiaUseRate = 0;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AndesiaCore>(), 1);
            recipe.AddIngredient(3086, 32);
            recipe.AddRecipeGroup("TitaniumBars", 24);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}