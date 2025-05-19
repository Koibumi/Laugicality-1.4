using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Players;
using Terraria.Localization;

namespace Laugicality.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class AncientHelmet : LaugicalityItem
    {
        public static LocalizedText SetBonusText { get; private set; }
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Mystic, Magic, and Summon damage");
            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs("Innate Sandstorm in a Bottle\n+15% Increased Potentia Conversion\n+60 Mana\nIncreased Max Minions");
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 22;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.defense = 3;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<AncientArmor>() && legs.type == ModContent.ItemType<AncientGreaves>();
        }


        public override void UpdateEquip(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticDamage += 0.10f;
            player.GetDamage(DamageClass.Summon) += .1f;
            player.GetDamage(DamageClass.Magic) += .1f;
        }
        
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.setBonus = "Innate Sandstorm in a Bottle\n+15% Increased Potentia Conversion\n+60 Mana\nIncreased Max Minions";
            modPlayer.GlobalAbsorbRate += .15f;
            player.statManaMax2 += 60;
            player.maxMinions += 2;
            player.GetJumpState(ExtraJump.SandstormInABottle).Enable();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 6);
            recipe.AddIngredient(ItemID.DesertFossil, 12);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}