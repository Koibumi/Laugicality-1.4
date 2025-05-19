using Laugicality.Content.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Loot;

namespace Laugicality.Content.Items.Weapons.Melee
{
    public class DioritusBlade : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blade of Glory");
            // Tooltip.SetDefault("Right click to throw \n'Into Battle!'");
        }
        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = false;
            Item.width = 60;
            Item.height = 60;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 100000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed = 16f;
            Item.useTurn = true;
            Item.maxStack = 1;
            Item.consumable = false;
        }

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
                Item.shoot = ModContent.ProjectileType<Projectiles.Melee.DioritusBladeProjectile>();
                Item.noUseGraphic = true;
            }
            else
            {
                Item.shoot = 0;
                Item.noUseGraphic = false;
            }
            return player.ownedProjectileCounts[ModContent.ProjectileType<DioritusBladeProjectile>()] < 1;
        }
        

        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DioritusCore>(), 1);
            recipe.AddIngredient(3081, 32);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}