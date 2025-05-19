using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Projectiles.Mystic.Conjuration;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Content.Projectiles.Special;
using Laugicality.Utilities.Players;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Mystic
{
	public class MarsFury : MysticItem
    {
        int _counter = 0;
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mars' Fury");
            // Tooltip.SetDefault("A Furious War\nIllusion inflicts 'Furious', which deals damage over time and makes enemies explode into Magma Shards upon death\nFires different projectiles based on Mysticism");
        }

		public override void SetMysticDefaults()
		{
            _counter = 0;
            Item.damage = 40;
            Item.width = 66;
			Item.height = 74;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 1;
			Item.noMelee = false;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shootSpeed = 6f;
            Item.scale = 1.5f;
		}
        
        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            var source = player.GetSource_FromThis();
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if(_counter > 0)
                _counter--;
            if (modPlayer.MysticMode == 2 && _counter <= 0)
            {
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 0f, 8f, ModContent.ProjectileType<MarsIllusion>(), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 0f, -8f, ModContent.ProjectileType<MarsIllusion>(), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 8f, 0f, ModContent.ProjectileType<MarsIllusion>(), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, -8f, 0f, ModContent.ProjectileType<MarsIllusion>(), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 6f, 6f, ModContent.ProjectileType<MarsIllusion>(), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, -6f, -6f, ModContent.ProjectileType<MarsIllusion>(), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 6f, -6f, ModContent.ProjectileType<MarsIllusion>(), damage, 3f, player.whoAmI);
                Projectile.NewProjectile(source, player.Center.X, player.Center.Y, -6f, 6f, ModContent.ProjectileType<MarsIllusion>(), damage, 3f, player.whoAmI);
                _counter = 6;
            }
            return true;
        }      

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.scale = 1.5f;
            Item.damage = 44;
            Item.useTime = 30;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 8;
            Item.shootSpeed = 4f;
            Item.shoot = ModContent.ProjectileType<Nothing>();
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.scale = 1f;
            Item.damage = 32;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.knockBack = 4;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<Nothing>();
            VisCost = 4;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.scale = 1f;
            Item.damage = 32;
            Item.useTime = 38;
            Item.useAnimation = 38;
            Item.knockBack = 2;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<MarsConjuration>();
            MundusCost = 20;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            LuxCost = 8;
            if (modPlayer.MysticMode == 1 && modPlayer.Lux >= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate)
            {
                Projectile.NewProjectile(player.GetSource_FromThis(), target.Center.X, target.Center.Y, 0f, 0f, ModContent.ProjectileType<MarsDestruction>(), hit.Damage, hit.Knockback, Main.myPlayer);

                modPlayer.Lux -= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                if (modPlayer.Lux < 0)
                    modPlayer.Lux = 0;
                if (modPlayer.Lux > (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow;
                modPlayer.Vis += LuxCost * modPlayer.GlobalAbsorbRate * modPlayer.VisAbsorbRate * modPlayer.LuxDischargeRate * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                if (modPlayer.Vis > (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow;
                modPlayer.Mundus += LuxCost * modPlayer.GlobalAbsorbRate * modPlayer.MundusAbsorbRate * modPlayer.LuxDischargeRate * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                if (modPlayer.Mundus > (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                    modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow;

            }
            LuxCost = 0;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<HadesJudgement>(), 1);
            recipe.AddIngredient(ModContent.ItemType<MagmaticCluster>());
            recipe.AddIngredient(ModContent.ItemType<MagmaticCrystal>(), 4);
            recipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 8);
            recipe.AddRecipeGroup("TitaniumBars", 6);
            recipe.AddIngredient(ModContent.ItemType<RubrumDust>(), 4);
            recipe.AddIngredient(ModContent.ItemType<AlbusDust>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
            
        }
    }
}