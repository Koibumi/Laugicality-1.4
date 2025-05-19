using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Ranged;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Ammo
{
    public class PurpleIceBall : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ebonchunk");
            // Tooltip.SetDefault("The corrupt ice is much thicker, and even able to bounce.");
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
            Item.shoot = ModContent.ProjectileType<PurpleIceBallProjectile>();
            Item.shootSpeed = 10f;
            Item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(12);
            recipe.AddIngredient(ItemID.PurpleIceBlock, 1);
            recipe.Register();
        }
    }
}
