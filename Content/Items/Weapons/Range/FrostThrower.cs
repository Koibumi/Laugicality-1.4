using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Ranged;
using Laugicality.Utilities.Base;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Range
{
	public class FrostThrower : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Fires a stream of frost\nConverts Snowballs into Frostballs");
		}

		public override void SetDefaults()
		{
			Item.damage = 20;
            Item.DamageType = DamageClass.Ranged;
			Item.width = 60;
			Item.height = 38;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shootSpeed = 18f;
            Item.useAmmo = AmmoID.Snowball;
            Item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 2;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(2));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                if(type == ProjectileID.SnowBallFriendly) 
                    Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<FrostballProjectile>(), damage, knockback, player.whoAmI);
                else
                    Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(10, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SMG>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 8);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<FrostCannon>(), 1);
            recipe1.AddIngredient(ModContent.ItemType<SoulOfSought>(), 8);
            recipe1.AddIngredient(ItemID.FrostCore, 1);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();
        }
    }
}