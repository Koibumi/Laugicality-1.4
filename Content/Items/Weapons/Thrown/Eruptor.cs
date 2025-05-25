using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Projectiles.Thrown;
using Laugicality.Utilities.Base;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Thrown
{
	public class Eruptor : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("'For Fury'");
		}
        public int numShots = 1;
		public override void SetDefaults()
		{
            numShots = 3;
			Item.damage = 32;
            Item.DamageType = DamageClass.Throwing;
			Item.width = 80;
			Item.height = 44;
			Item.useTime = 15;
			Item.useAnimation = 15;
            Item.useStyle = 1;
            Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item19;
			Item.autoReuse = true;
			Item.shootSpeed = 20f;
            Item.shoot = ModContent.ProjectileType<EruptorProjectile>();
            Item.noUseGraphic = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            numShots++;
            if (numShots > 6)
                numShots = 3;
            int numberProjectiles = numShots;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(5+2*numShots));
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false; 
        }
        
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-26, 4);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 12);
            recipe.AddRecipeGroup("TitaniumBars", 6);
            recipe.AddIngredient(ModContent.ItemType<MagmaticCluster>());
            recipe.AddIngredient(ModContent.ItemType<MagmaticCrystal>(), 4);
            recipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 8);
            recipe.AddIngredient(ModContent.ItemType<VerdiDust>(), 4);
            recipe.AddIngredient(ModContent.ItemType<AlbusDust>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
	}
}