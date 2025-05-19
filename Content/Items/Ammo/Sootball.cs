using Laugicality.Content.Items.Placeable;
using Laugicality.Content.Projectiles.Ranged;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Ammo
{
    public class Sootball : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sootball");
            // Tooltip.SetDefault("Inflicts 'On Fire!'");
        }

        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 7f;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<SootballProjectile>();
            Item.shootSpeed = 14f;
            Item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(15);
            recipe.AddIngredient(ModContent.ItemType<Soot>(), 1);
            recipe.Register();
        }
    }
}
