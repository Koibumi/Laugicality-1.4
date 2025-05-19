using Terraria;
using Terraria.ID;
using System;
using Laugicality.Content.Projectiles.Mystic.Conjuration;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Microsoft.Xna.Framework;
using Laugicality.Content.Projectiles.Special;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Mystic
{
    public class OrionsGate : MysticItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orion's Gate");
            // Tooltip.SetDefault("'Open the path to the stars'\nIllusion inflicts 'Cosmic Disarray', which drains life and makes enemies take more damage.\nFires different projectiles based on Mysticism\nConsuming enemies increases the Gate's power.");
        }
        
        public override void SetMysticDefaults()
        {
            Item.damage = 40;
            Item.width = 56;
            Item.height = 56;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.value = 10000;
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item105;
            Item.autoReuse = true;
            Item.shootSpeed = 6f;
        }

        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 50f;
            var source = player.GetSource_FromThis();
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 1)
            {
                modPlayer.OrionCharge++;
                modPlayer.UsingMysticItem = 60;
                if (modPlayer.OrionCharge > 24)
                    modPlayer.OrionCharge = 24;
                for (int i = 0; i < modPlayer.OrionCharge / 2 + 1; i++)
                {
                    float theta = (float)Main.rand.NextDouble() * 3.14f / 6 + 3.14f * 255f / 180f;
                    theta += -modPlayer.OrionCharge / 24 * 3.14f / 6 + 2 * modPlayer.OrionCharge / 24 * (float)Main.rand.NextDouble() * 3.14f / 6;
                    float mag = 600 + Main.rand.Next(200 + 4 * modPlayer.OrionCharge);
                    Projectile.NewProjectile(source, (int)(Main.MouseWorld.X) + (int)(mag * Math.Cos(theta)) - 32 - modPlayer.OrionCharge + Main.rand.Next(64 + 2 * modPlayer.OrionCharge), (int)(Main.MouseWorld.Y) + (int)(mag * Math.Sin(theta)) - 32 - modPlayer.OrionCharge + Main.rand.Next(64 + 2 * modPlayer.OrionCharge), -25 * (float)Math.Cos(theta), -25 * (float)Math.Sin(theta), ModContent.ProjectileType<OrionDestruction>(), damage, 3, Main.myPlayer);
                }
            }
            if(modPlayer.MysticMode == 2)
            {
                Projectile.NewProjectile(source, player.position.X, player.position.Y - 600, -4, 0, ModContent.ProjectileType<OrionIllusionSpawn>(), damage, 3, Main.myPlayer);
                Projectile.NewProjectile(source, player.position.X, player.position.Y - 600, 4, 0, ModContent.ProjectileType<OrionIllusionSpawn>(), damage, 3, Main.myPlayer);
            }
            if (modPlayer.MysticMode == 3)
            {
                bool projExists = false;
                foreach( Projectile projectile in Main.projectile)
                {
                    if(projectile.type == ModContent.ProjectileType<OrionConjuration>())
                    {
                        projectile.timeLeft = 90;
                        modPlayer.UsingMysticItem = 90;
                        projExists = true;
                    }
                }
                if(!projExists)
                {
                    Projectile.NewProjectile(source, (int)(Main.MouseWorld.X), (int)(Main.MouseWorld.Y), 0, 0, ModContent.ProjectileType<OrionConjuration>(), damage, 3, Main.myPlayer);
                }
            }
            return true;
        }
        
        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.damage = 48;
            Item.useTime = 20;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 4;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<Nothing>();
            Item.noUseGraphic = false;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.damage = 42;
            Item.useTime = 90;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 1;
            Item.shootSpeed = 22f;
            Item.shoot = ModContent.ProjectileType<Nothing>();
            Item.noUseGraphic = false;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.damage = 35;
            Item.useTime = 40;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 2;
            Item.shootSpeed = 0f;
            Item.shoot = ModContent.ProjectileType<Nothing>();
            Item.noUseGraphic = false;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Pearlwood, 24);
            recipe.AddRecipeGroup("SilverBars", 8);
            recipe.AddIngredient(ItemID.SoulofLight, 6);
            recipe.AddIngredient(mod, nameof(SoulOfSought), 4);
            recipe.AddIngredient(ItemID.CrystalShard, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}