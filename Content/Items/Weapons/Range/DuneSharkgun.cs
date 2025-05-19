using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Base;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Range
{
    public class DuneSharkgun : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("33% chance to not consume ammo\nOccasionally shoots Crystal bullets");
        }

        private float theta = 0f;
        private float rotSp = (float)Math.PI / 4;

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 44;
            Item.height = 86;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item41;
            Item.autoReuse = true;
            Item.channel = true;
            Item.shoot = 10;
            Item.shootSpeed = 12f;
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Minishark, 1);
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 1);
            recipe.AddIngredient(ItemID.FossilOre, 4);
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .33f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speed.X, speed.Y)) * 20f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }

            Vector2 perturbedSpeed = new Vector2(speed.X, speed.Y);

            perturbedSpeed = perturbedSpeed * 1.33f;
            if (Main.rand.Next(3) == 0)
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ProjectileID.CrystalBullet, (int)(damage * 1.25), knockback, player.whoAmI);

            return true;
        }
    }
}
