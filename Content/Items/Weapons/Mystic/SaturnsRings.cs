using Laugicality.Content.Projectiles.Mystic.Conjuration;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Mystic
{
    public class SaturnsRings : MysticItem
    {
        int charge = 0;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Saturn's Rings");
            // Tooltip.SetDefault("'The majesty of Space'\nIllusion inflicts 'Orbital'. Orbital enemies take more damage and knockback.\nFires different projectiles based on Mysticism");
        }
        
        public override void SetMysticDefaults()
        {
            charge = 0;
            Item.damage = 50;
            Item.width = 68;
            Item.height = 40;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.value = 10000;
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed = 6f;
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;

            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                charge++;
                SoundEngine.PlaySound(SoundID.Item60, position);
                if(charge > 2)
                {
                    int numberProjectiles = 24;
                    for (int i = 0; i < numberProjectiles; i++)
                    {
                        Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
                        float scale = 1f - (Main.rand.NextFloat() * .4f);
                        perturbedSpeed = perturbedSpeed * scale;
                        Projectile.NewProjectile(player.GetSource_FromThis(), position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
                    }

                    charge = 0;
                    SoundEngine.PlaySound(SoundID.Item84, position);
                }
                return false;
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.useStyle = 5;
            Item.damage = 85;
            Item.useTime = 45;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 4;
            Item.shootSpeed = 18f;
            Item.shoot = ModContent.ProjectileType<SaturnDestruction>();
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.useStyle = 5;
            Item.damage = 50;
            Item.useTime = 24;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 1;
            Item.shootSpeed = 18f;
            Item.shoot = ModContent.ProjectileType<SaturnIllusion1>();
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.useStyle = 5;
            Item.damage = 60;
            Item.useTime = 24;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 2;
            Item.shootSpeed = 8f;
            Item.shoot = ModContent.ProjectileType<SaturnConjuration1>();
        }
    }
}