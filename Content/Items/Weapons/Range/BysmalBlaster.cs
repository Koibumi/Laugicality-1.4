using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Projectiles.Special;
using Laugicality.Content.Tiles;
using Laugicality.Utilities;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Range
{
	public class BysmalBlaster : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bysmal Blaster");
            // Tooltip.SetDefault("'Blast them to another dimension'\n50% chance to not consume ammo\nWhile in the Etherial after defeating Etheria, shoots shotgun blasts twice as often");
		}

        private int reload = 0;
        private int reloadMax = 2;
        private float theta = 0f;
        private float rotSp = (float)Math.PI / 4;

		public override void SetDefaults()
        {
            Item.scale *= 1.2f;
            Item.damage = 88;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 44;
			Item.height = 86;
			Item.useTime = 7;
			Item.useAnimation = 28;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 10000;
			Item.rare = ItemRarityID.Cyan;
			Item.UseSound = SoundID.Item41;
			Item.autoReuse = true;
            Item.channel = true;
            Item.shoot = 10;
			Item.shootSpeed = 22f;
			Item.useAmmo = AmmoID.Bullet;
		}
        
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 5);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
			recipe.Register();
		}
            
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .50f;
		}

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speed.X, speed.Y)) * 50f;
            
            float mag = 12f;
            theta += rotSp;

            if (theta >= 3.14158265f * 2)
                theta -= 3.14158265f * 2;

            Projectile.NewProjectile(source, player.Center.X, player.Center.Y, (float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * mag, ModContent.ProjectileType<BysmalBlast>(), (int)(Item.damage), 3, Main.myPlayer);

            //Normal shot
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
                position += muzzleOffset;


            reload -= 1;

            if (reload <= 0)
            {
                reload = reloadMax;
                if ((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(player).Etherable > 0) && LaugicalityWorld.downedTrueEtheria)
                    reload /= 2;

                int numberProjectiles = Main.rand.Next(3, 6);

                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speed.X, speed.Y).RotatedByRandom(MathHelper.ToRadians(7)); 
                                                                                                                
                    float scale = 1f - (Main.rand.NextFloat() * .2f);
                    perturbedSpeed = perturbedSpeed * scale;

                    if(Main.player[Main.myPlayer] == player)
                        Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
                }
            }

            return false; 
        }
    }
}
