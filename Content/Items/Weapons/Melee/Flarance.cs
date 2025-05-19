using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Melee
{
    class Flarance : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("'Eruptions fly forth'");
        }

        public override void SetDefaults()
        {
            Item.damage = 24;           
            Item.DamageType = DamageClass.Melee;          
            Item.width = 42;            
            Item.height = 48;           
            Item.useTime = 25;          
            Item.useAnimation = 25;         
            Item.useStyle = 1;          
            Item.knockBack = 5;         
            Item.value = 10000;         
            Item.rare = ItemRarityID.Green;              
            Item.UseSound = SoundID.Item1;    
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.FlaranceProjectile>();
            Item.shootSpeed = 14f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 12);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}
