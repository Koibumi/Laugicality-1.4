using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Laugicality.Content.Projectiles.Mystic.Conjuration;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Microsoft.Xna.Framework;
using Laugicality.Content.Projectiles.Special;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Weapons.Mystic
{
	public class FriggsPhalanx : MysticItem
    {
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frigg's Phalanx");
            // Tooltip.SetDefault("'The swarm cometh'\nIllusion inflicts 'Poison'\nFires different projectiles based on Mysticism");
			Item.staff[Item.type] = true;
		}

        public override void SetMysticDefaults()
		{
			Item.damage = 25;
            Item.width = 48;
			Item.height = 48;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Nothing>();
			Item.shootSpeed = 6f;
		}

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            var source = player.GetSource_FromThis();
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                int numberProjectiles = Main.rand.Next(1, 3);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10));
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    if(Main.rand.Next(2) == 0)
                    {
                        if(!player.strongBees)
                            Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 181, damage, knockBack, player.whoAmI);
                        else
                            Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, 566, (int)(damage * 1.5), knockBack, player.whoAmI);
                    }
                    else
                        Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<FriggDestruction>(), damage, knockBack, player.whoAmI);
                }
            }
            if(modPlayer.MysticMode == 2)
            {
                float theta = (float)Main.rand.NextDouble() * 3.14f * 2;
                float mag = 360;
                Projectile.NewProjectile(source, (int)(Main.MouseWorld.X) + (int)(mag * Math.Cos(theta)), (int)(Main.MouseWorld.Y) + (int)(mag * Math.Sin(theta)), -4 * (float)Math.Cos(theta), -4 * (float)Math.Sin(theta), ModContent.ProjectileType<FriggIllusion>(), damage, 3, Main.myPlayer);
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.damage = 28;
            Item.useTime = 13;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 1f;
            Item.shootSpeed = 10;
            Item.shoot = ModContent.ProjectileType<Nothing>();
            LuxCost = 6;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.damage = 25;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.knockBack = 1;
            Item.shootSpeed = 8f;
            Item.shoot = ModContent.ProjectileType<Nothing>();
            VisCost = 5;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.damage = 25;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.knockBack = 5;
            Item.shootSpeed = 2f;
            Item.shoot = ModContent.ProjectileType<FriggConjuration>();
            MundusCost = 16;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(331, 10);
            recipe.AddIngredient(2431, 8);
            recipe.AddTile(16);
			recipe.Register();
		}
    }
}