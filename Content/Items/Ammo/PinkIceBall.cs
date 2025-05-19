using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Ranged;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Ammo
{
    public class PinkIceBall : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Pearlfrost Ball");
            // Tooltip.SetDefault("The hallowed ice is much lighter, and able to fly much farther.");
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
            Item.shoot = ModContent.ProjectileType<PinkIceBallProjectile>();
            Item.shootSpeed = 16f;
            Item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(12);
            recipe.AddIngredient(ItemID.PinkIceBlock, 1);
            recipe.Register();
        }
    }
}
