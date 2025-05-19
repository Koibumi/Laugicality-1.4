using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Ranged;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Ammo
{
    public class Frostball : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frostball");
            // Tooltip.SetDefault("Inflicts 'Frostburn'");
        }

        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 7f;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<FrostballProjectile>();
            Item.shootSpeed = 14f;
            Item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(ItemID.SnowBlock, 5);
            recipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 1);
            recipe.Register();
        }
    }
}
