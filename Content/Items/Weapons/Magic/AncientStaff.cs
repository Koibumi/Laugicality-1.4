using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Projectiles.Magic;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Magic
{
    public class AncientStaff : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ancient Staff");
            // Tooltip.SetDefault("'Crystilla Rain'");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 2;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 5;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.shoot = ModContent.ProjectileType<CrystillaShardProjectile>();
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shootSpeed = 4f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float theta = (float)Main.rand.NextDouble() * 3.14f / 6 + 3.14f * 255f / 180f;
            float mag = 600;
            Projectile.NewProjectile(source, (int)(Main.MouseWorld.X + Main.rand.Next(-40, 40)) + (int)(mag * Math.Cos(theta)), (int)(player.position.Y) + (int)(mag * Math.Sin(theta)), -15 * (float)Math.Cos(theta), -15 * (float)Math.Sin(theta), ModContent.ProjectileType<CrystillaShardProjectile>(), damage, 3, Main.myPlayer);
            theta = (float)Main.rand.NextDouble() * 3.14f / 6 + 3.14f * 255f / 180f;
            mag = 700;
            Projectile.NewProjectile(source, (int)(Main.MouseWorld.X + Main.rand.Next(-40, 40)) + (int)(mag * Math.Cos(theta)), (int)(player.position.Y) + (int)(mag * Math.Sin(theta)), -15 * (float)Math.Cos(theta), -15 * (float)Math.Sin(theta), ModContent.ProjectileType<CrystillaShardProjectile>(), damage, 3, Main.myPlayer);
            return false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 1);
            recipe.AddIngredient(ItemID.FossilOre, 6);
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}