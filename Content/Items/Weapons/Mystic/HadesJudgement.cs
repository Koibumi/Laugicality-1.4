using Laugicality.Content.Items.Materials;
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
    public class HadesJudgement : MysticItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hades' Judgement");
            // Tooltip.SetDefault("Cleanse your sins\nIllusion inflicts 'Shadowflame'\nFires different projectiles based on Mysticism");
        }

        public override void SetMysticDefaults()
        {
            Item.damage = 34;
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
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode != 1)
                return true;
            else return false;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.damage = 44;
            Item.useTime = 40;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 8;
            Item.shootSpeed = 4f;
            Item.shoot = ModContent.ProjectileType<Nothing>();
            LuxCost = 0;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.damage = 32;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 4;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<HadesIllusion>();
            VisCost = 8;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.damage = 22;
            Item.useTime = 65;
            Item.useAnimation = 65;
            Item.knockBack = 2;
            Item.shootSpeed = 8f;
            Item.shoot = ModContent.ProjectileType<HadesConjuration>();
            MundusCost = 20;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            LuxCost = 16;
            if (modPlayer.MysticMode == 1 && modPlayer.Lux >= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate)
            {
                Projectile.NewProjectile(player.GetSource_FromThis(), target.Center.X + 32, target.Center.Y + 32, 0f, 0f, ModContent.ProjectileType<HadesExplosion>(), hit.Damage, hit.Knockback, Main.myPlayer);
                
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
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<Placeable.LavaGem>(), 8);
            recipe.AddIngredient(ModContent.ItemType<DarkShard>());
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}