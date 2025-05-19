using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Projectiles.Mystic.Conjuration;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Laugicality.Content.Projectiles.Special;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Mystic
{
	public class Yuletide : MysticItem
    {
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Yuletide");
            // Tooltip.SetDefault("'Holiday Cheer'\nIllusion inflicts 'Frostburn'\nFires different projectiles based on Mysticism");
			Item.staff[Item.type] = true;
		}

		public override void SetMysticDefaults()
		{
			Item.damage = 32;
            Item.width = 48;
			Item.height = 48;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Nothing>();
			Item.shootSpeed = 6f;
		}


        public override bool MysticShoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.MysticMode == 3)
            {
                for(int i = 0; i < 3; i++)
                {
                    if(Main.player[Main.myPlayer] == player)
                        Projectile.NewProjectile(player.GetSource_FromAI(), (int)(Main.MouseWorld.X) - 8 + Main.rand.Next(0, 16), (int)(Main.MouseWorld.Y) - 360 - 8 + Main.rand.Next(0, 16), 0, 0, ModContent.ProjectileType<YuleConjuration>(), (int)(Item.damage), 3, Main.myPlayer);
                }
            }
            return true;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.damage = 30;
            Item.useTime = 12;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 2;
            Item.shootSpeed = 10;
            Item.shoot = ModContent.ProjectileType<YuleDestruction>();
            LuxCost = 4;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.damage = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.knockBack = 1;
            Item.shootSpeed = 8f;
            Item.shoot = ModContent.ProjectileType<YuleIllusion>();
            VisCost = 8;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.damage = 36;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.knockBack = 5;
            Item.shootSpeed = 2f;
            Item.shoot = ModContent.ProjectileType<Nothing>();
            MundusCost = 4;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SnowBlock, 25);
            recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 6);
            recipe.AddTile(16);
			recipe.Register();
		}
    }
}