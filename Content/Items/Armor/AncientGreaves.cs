using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Loot;

namespace Laugicality.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class AncientGreaves : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Increased jump height\n+15% Movement Speed and Max Run Speed");
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 22;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 4;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
            player.maxRunSpeed += .15f;
            player.jumpSpeedBoost += 4;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 4);
            recipe.AddIngredient(ItemID.DesertFossil, 8);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}