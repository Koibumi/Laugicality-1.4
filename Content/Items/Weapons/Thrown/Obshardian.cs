using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Thrown;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Thrown
{
    public class Obshardian : LaugicalityItem
    {
        public override void SetDefaults()
        {
            Item.damage = 34;           
            Item.DamageType = DamageClass.Throwing;             
            Item.noMelee = true;
            Item.width = 14;
            Item.height = 26;
            Item.useTime = 10;       
            Item.useAnimation = 10;   
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10;
            Item.rare = ItemRarityID.Orange;
            //item.reuseDelay = 17;   
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;       
            Item.shoot = ModContent.ProjectileType<ObshardianP>();  
            Item.shootSpeed = 16f;     
            Item.useTurn = true;
            Item.maxStack = 999;       
            Item.consumable = true;  
            Item.noUseGraphic = true;

        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe(333);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 8);
            recipe.AddIngredient(ModContent.ItemType<DarkShard>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}