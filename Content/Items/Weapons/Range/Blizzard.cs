using Laugicality.Content.Items.Loot;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Players;
using Laugicality.Content.Tiles;

namespace Laugicality.Content.Items.Weapons.Range
{
    public class Blizzard : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("'Let snow fly'\nWhile in the Etherial after defeating Etheria, shoot an extra snowball\n50% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 72;
            Item.height = 36;
            Item.useTime = 5;
            Item.useAnimation = 5;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 4;
            Item.value = 10000;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item34;
            Item.autoReuse = true;
            Item.shootSpeed = 18f;
            Item.useAmmo = AmmoID.Snowball;
            Item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            if (Main.rand.Next(2) == 0)
                return false;
            return base.CanConsumeAmmo(ammo, player);
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 40f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 1;
            if (Main.rand.Next(8) == 0)
                numberProjectiles++;
            if (((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(player).Etherable > 0) && LaugicalityWorld.downedTrueEtheria))
                numberProjectiles++;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(8));

                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }

            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FrostThrower>(), 1);
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 5);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}