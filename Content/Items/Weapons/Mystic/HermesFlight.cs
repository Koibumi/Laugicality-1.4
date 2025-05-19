using Laugicality.Content.Projectiles.Mystic.Conjuration;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Utilities.Players;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Mystic
{
	public class HermesFlight : MysticItem
    {
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hermes' Flight");
            // Tooltip.SetDefault("Weild the power of Hermes\nIllusion inflicts 'Hermes' Smite', which drains enemy life\nFires different projectiles based on Mysticism");
			Item.staff[Item.type] = true;
		}

		public override void SetMysticDefaults()
		{
			Item.damage = 20;
            Item.width = 28;
			Item.height = 28;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<HermesDestruction>();
			Item.shootSpeed = 6f;
		}

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                int numberProjectiles = Main.rand.Next(2, 4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(player.GetSource_FromThis(), position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<HermesDestruction>(), damage, knockBack, player.whoAmI);
                }

            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.damage = 15;
            Item.useTime = 20;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 4;
            Item.shootSpeed = 12;
            Item.shoot = ModContent.ProjectileType<HermesDestruction>();
            LuxCost = 8;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.damage = 22;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.knockBack = 2;
            Item.shootSpeed = 8f;
            Item.shoot = ModContent.ProjectileType<HermesIllusion>();
            VisCost = 4;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.damage = 15;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.knockBack = 5;
            Item.shootSpeed = 8f;
            Item.shoot = ModContent.ProjectileType<HermesConjuration1>();
            MundusCost = 8;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.AddRecipeGroup(16);
            recipe.AddIngredient(ItemID.Feather, 4);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddTile(16);
			recipe.Register();
		}
    }
}