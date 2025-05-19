using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Mystic.Conjuration;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Content.Projectiles.Special;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Weapons.Mystic
{
	public class DionysusBloom : MysticItem
    {
        public int damage = 0;
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dionysus' Bloom");
            // Tooltip.SetDefault("'Grow his strength' \nIllusion inflicts 'Venom'\nFires different projectiles based on Mysticism");
            Item.staff[Item.type] = true;
        }
        
        public override void SetMysticDefaults()
		{
			Item.damage = 44;
            Item.width = 64;
			Item.height = 64;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 5;
			Item.noMelee = true; 
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 6f;
		}

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 64f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 2)
            {

                int numberProjectiles = Main.rand.Next(1, 4);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); 
                    float scale = 1f - (Main.rand.NextFloat() * .3f);
                    perturbedSpeed = perturbedSpeed * scale;
                    Projectile.NewProjectile(player.GetSource_FromThis(), position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<DionysusIllusion>(), damage, knockBack, player.whoAmI);
                }
                return false;
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.damage = 72;
            Item.useTime = 25;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 0;
            Item.shootSpeed = 14f;
            Item.shoot = ModContent.ProjectileType<DionysusDestruction>();
            Item.UseSound = SoundID.Item1;
            Item.scale = 1.25f;
            LuxCost = 6;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.damage = 42;
            Item.useTime = 10;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 5;
            Item.shootSpeed = 18f;
            Item.shoot = ModContent.ProjectileType<Nothing>();
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.scale = 1f;
            VisCost = 4;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.damage = 44;
            Item.useTime = 30;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 2;
            Item.shootSpeed = 20f;
            Item.shoot = ModContent.ProjectileType<DionysusConjuration>();
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.scale = 1f;
            MundusCost = 20;
        }

       


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(1006, 16); //Chlorophyte
            recipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}