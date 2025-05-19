using Laugicality.Content.Items.Placeable;
using Laugicality.Content.Projectiles.Ranged;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Ammo
{
    public class YellowIceBall : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Yellow Iceball");
            // Tooltip.SetDefault("The yellow ice just wants to be eaten.\n'Looks tasty'");
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 7f;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<Projectiles.Ranged.YellowIceBall>();
            Item.shootSpeed = 10f;
            Item.ammo = AmmoID.Snowball;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(8);
            recipe.AddIngredient(ItemID.IceBlock, 1);
            recipe.AddIngredient(ItemID.ChlorophyteOre, 1);
            recipe.Register();
        }
    }
}
