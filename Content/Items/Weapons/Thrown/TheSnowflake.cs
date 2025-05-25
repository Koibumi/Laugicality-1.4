using Laugicality.Content.Projectiles.Thrown;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Thrown
{
    public class TheSnowflake : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Snowflake");
            // Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.damage = 30;           
            Item.DamageType = DamageClass.Throwing;             
            Item.noMelee = true;
            Item.width = 38;
            Item.height = 38;
            Item.useTime = 45;      
            Item.useAnimation = 45;   
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 100000;
            Item.rare = ItemRarityID.Blue;   
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;       
            Item.shoot = ModContent.ProjectileType<TheSnowflakeProjectile>(); 
            Item.shootSpeed = 6f;     
            Item.useTurn = true;
            Item.maxStack = 999;       
            Item.consumable = true;  
            Item.noUseGraphic = true;

        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe(200);
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 4);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}