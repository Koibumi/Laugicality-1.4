using Laugicality.Content.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Thrown
{
    public class Andeshiard : LaugicalityItem
    {
        public override void SetDefaults()
        {
            Item.damage = 32;           
            Item.DamageType = DamageClass.Throwing;            
            Item.noMelee = true;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 10;      
            Item.useAnimation = 10;   
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;       
            Item.shoot = ModContent.ProjectileType<Projectiles.Thrown.AndeshiardThrownProjectile>();  
            Item.shootSpeed = 16f;     
            Item.useTurn = true;
            Item.maxStack = 1;       
            Item.consumable = false;  
            Item.noUseGraphic = true;

        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AndesiaCore>(), 1);
            recipe.AddIngredient(3081, 25);
            recipe.AddIngredient(3086, 25);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}