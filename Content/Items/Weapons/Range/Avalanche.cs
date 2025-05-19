using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;
using Laugicality.Content.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using Laugicality.Utilities.Base;
using Laugicality.Utilities;

namespace Laugicality.Content.Items.Weapons.Range
{
    public class Avalanche : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("'Unleash frigid hell.'\nWhile in the Etherial after defeating Etheria, shoot an Avalanche twice as often\n50% chance not to consume ammo");
        }
        int counter = 0;
        public override void SetDefaults()
        {
            counter = 0;
            Item.damage = 50;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 106;
            Item.height = 58;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 8;
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

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo s, Vector2 position, Vector2 speed, int type, int damage, float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speed.X, speed.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            int numberProjectiles = 3;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speed.X, speed.Y).RotatedByRandom(MathHelper.ToRadians(8));
                                                                                                              
                float scale = 1f - (Main.rand.NextFloat() * .3f);
                perturbedSpeed = perturbedSpeed * scale;
                if (i == 0)
                    Projectile.NewProjectile(s, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<FrostballProjectile>(), damage, knockBack, player.whoAmI);
                else
                    Projectile.NewProjectile(s, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            counter++;
            if (((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(player).Etherable > 0) && LaugicalityWorld.downedTrueEtheria) || counter >= 2)
            {
                counter = 0;
                Projectile.NewProjectile(s, position.X, position.Y, speed.X * 1.5f, speed.Y * 1.5f, ModContent.ProjectileType<Projectiles.Ranged.AvalancheProjectile>(), damage * 3, knockBack, player.whoAmI);
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
            recipe.AddIngredient(ModContent.ItemType<FrostThrower>(), 1);
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 5);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}