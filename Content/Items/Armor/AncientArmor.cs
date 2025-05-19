using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Loot;

namespace Laugicality.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class AncientArmor : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Your damage increases based on your Movement Speed.");
        }

        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 22;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            float moveSpeed = 0;
            moveSpeed = (float)Math.Abs(player.velocity.X) / 30f;
            if (moveSpeed > .2f)
                moveSpeed = .2f;
            player.GetDamage(DamageClass.Generic) += moveSpeed;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 4);
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 1);
            recipe.AddIngredient(ItemID.DesertFossil, 16);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}