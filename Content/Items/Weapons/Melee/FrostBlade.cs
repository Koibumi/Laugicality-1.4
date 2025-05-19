using Laugicality.Content.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Melee
{
	public class FrostBlade : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Frostular Fragments");
		}

		public override void SetDefaults()
		{
			Item.damage = 28;
            Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 54;
			Item.useTime = 60;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 4;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 10f;
            Item.shoot = ModContent.ProjectileType<FrostballProjectile>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = Main.rand.Next(3,6);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(15)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                 float scale = 1f - (Main.rand.NextFloat() * .3f);
                 perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 118, damage, knockback, player.whoAmI);
            }


            return false; // return false because we don't want tmodloader to shoot projectile
        }
        
        

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlade, 1);
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 1);
            recipe.AddTile(16);
			recipe.Register();
		}
	}
}