using Laugicality.Content.Buffs;
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
	public class MagmaticMask : LaugicalityItem
	{
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
		{
            // Tooltip.SetDefault("+15% Mystic and Throwing Damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Eruption & Magmatic Mystic Bursts\n+25% Mystic Burst Damage & Decreased Mystic Burst cooldown\n+15%Throwing Crit Chance\nAttacks inflict 'On Fire!'\nIncreased stats after being submerged in Lava");
        }

        public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 12;
		}
        

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<MagmaticLongcoat>() && legs.type == ModContent.ItemType<MagmaticBoots>();
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Eruption & Magmatic Mystic Bursts\n+25% Mystic Burst Damage & Decreased Mystic Burst cooldown\n+15%Throwing Crit Chance\nAttacks inflict 'On Fire!'\nIncreased stats after being submerged in Lava";
            modPlayer.Obsidium = true;
            modPlayer.Magmatic = true;
            modPlayer.MysticObsidiumBurst = true;
            player.GetCritChance(DamageClass.Throwing) += 15;
            modPlayer.MysticSwitchCoolRate += 2;

            if (player.lavaWet)
                player.AddBuff(ModContent.BuffType<Magmatic>(), 60 * 15);
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += 0.15f;
            player.GetDamage(DamageClass.Throwing) += .15f;
        }
        

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ObsidiumHelmet>(), 1);
            recipe.AddRecipeGroup("TitaniumBars", 12);
            recipe.AddIngredient(ModContent.ItemType<MagmaticCrystal>(), 2);
            recipe.AddIngredient(ModContent.ItemType<MagmaticCluster>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();


            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<ObsidiumBand>(), 1);
            recipe2.AddRecipeGroup("TitaniumBars", 12);
            recipe2.AddIngredient(ModContent.ItemType<MagmaticCrystal>(), 2);
            recipe2.AddIngredient(ModContent.ItemType<MagmaticCluster>(), 1);
            recipe2.AddTile(134);
            recipe2.Register();
        }
    }
}