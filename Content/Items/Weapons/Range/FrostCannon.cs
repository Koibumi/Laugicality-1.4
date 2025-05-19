using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Base;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Range
{
	public class FrostCannon : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Fires a blast of frost");
		}

		public override void SetDefaults()
		{
			Item.damage = 9;
            Item.DamageType = DamageClass.Ranged;
			Item.width = 46;
			Item.height = 26;
			Item.useTime = 38;
			Item.useAnimation = 38;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 8;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item34;
			Item.autoReuse = true;
			Item.shootSpeed = 14f;
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

            int numberProjectiles = Main.rand.Next(3,6);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(15));
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
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
            recipe.AddIngredient(ItemID.SnowballCannon, 1);
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 1);
            recipe.AddTile(16);
			recipe.Register();
		}
	}
}