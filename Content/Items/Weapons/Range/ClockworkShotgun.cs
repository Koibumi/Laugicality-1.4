using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Range
{
    public class ClockworkShotgun : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("33% chance to not consume ammo\nOccasionally turns normal bullets into more damaging High Velocity bullets");
        }
        
        private float theta = 0f;
        private float rotSp = (float)Math.PI / 4;

        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 44;
            Item.height = 86;
            Item.useTime = 11;
            Item.useAnimation = 33;
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
            recipe.AddIngredient(ItemID.ClockworkAssaultRifle, 1);
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 12);
            recipe.AddIngredient(ItemID.Cog, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .33f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            /*Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }*/
            int numberProjectiles = Main.rand.Next(2, 6);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speed.X, speed.Y).RotatedByRandom(MathHelper.ToRadians(7));

                float scale = 1f - (Main.rand.NextFloat() * .2f);
                perturbedSpeed = perturbedSpeed * scale;
                if (Main.player[Main.myPlayer] == player)
                {
                    if(type == ProjectileID.Bullet)
                    {
                        if(Main.rand.Next(3) == 0)
                            Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.BulletHighVelocity, (int)(damage * 1.25), knockback, player.whoAmI);
                        else
                            Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
                    }
                    else
                        Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
                }

            }
            
            return false;
        }
    }
}
