using Laugicality.Content.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Equipables;

namespace Laugicality.Content.Items.Weapons.Melee
{
    public class HolyBlade : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blade of The Holy Knight");
            // Tooltip.SetDefault("'Call down the sky'");
        }
        public override void SetDefaults()
        {
            Item.damage = 600;           
            Item.DamageType = DamageClass.Melee;             
            Item.noMelee = false;
            Item.width = 90;
            Item.height = 90;
            Item.useTime =10;       
            Item.useAnimation = 10;   
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 100000;
            Item.rare = ItemRarityID.Cyan;
            //item.reuseDelay = 20;    
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;       
            //item.shoot = 461;  
            //item.shootSpeed = 16f;     
            Item.useTurn = true;
            Item.maxStack = 1;      
            Item.consumable = false;
            //item.noUseGraphic = true;
            Item.scale = 1.5f;

        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if(player.ownedProjectileCounts[ModContent.ProjectileType<HolyOrigin>()] == 0)
            {
                if (Main.player[Main.myPlayer] == player)
                {
                    Projectile.NewProjectile(player.GetSource_FromThis(), (int)(target.position.X), (int)(target.position.Y) - 1200, 0, 0, ModContent.ProjectileType<HolyOrigin>(), (int)(Item.damage), 3, Main.myPlayer);
                }
            }
        }/*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3467, 16);
            recipe.AddIngredient(3458, 8);
            recipe.AddTile(412);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}