using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Projectiles.Ranged;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Range
{
	public class Steamstring : LaugicalityItem
	{
        //public bool steam = true;
        //public int steamTier = 1;
        //public int steamCost = 60;
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'Steaming Frenzy' \nTurns wooden arrows into Brass Arrows & fires an additional Brass Arrow\n33% chance to not consume ammo");
		}

		public override void SetDefaults()
        {
            //steam = true;
            //steamTier = 1;
            //steamCost = 60;
            Item.scale *= 1.2f;
            Item.damage = 48;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 62;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item10;
			Item.autoReuse = true;
			Item.shoot = 10; 
			Item.shootSpeed = 16f;
			Item.useAmmo = 40;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 8);
            recipe.AddIngredient(ModContent.ItemType<SoulOfThought>(), 8);
            recipe.AddIngredient(ModContent.ItemType<Gear>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
        /*
        //Steam item
        //VV
        public override bool CanUseItem(Player player)
        {

            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (steam)
            {
                if (modPlayer.connected >= steamTier && LaugicalityWorld.power >= steamCost)
                    return true;
                else
                    return false;
            }
            return true;
        }

        public override bool UseItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            LaugicalityWorld.power -= steamCost;
            if (LaugicalityWorld.power < 0)
                LaugicalityWorld.power = 0;
            return true;
        }
        //^^
        //Steam Item end
        */
            
        public override bool CanConsumeAmmo(Item ammo, Player player)
		{
			return Main.rand.NextFloat() >= .33f;
		}

        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            //Main.NewText("Steam Tier: " + steamTier.ToString(), 0, 250, 0);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speed.X, speed.Y)) * 50f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            Vector2 perturbedSpeed = new Vector2(speed.X, speed.Y).RotatedByRandom(MathHelper.ToRadians(5));

            float scale = 1f - (Main.rand.NextFloat() * .2f);
            perturbedSpeed = perturbedSpeed * scale;
            Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<BrassArrowProjectile>(), damage, knockBack, player.whoAmI);
            
            if(type == ProjectileID.WoodenArrowFriendly)
            {
                Projectile.NewProjectile(source, position.X, position.Y, speed.X, speed.Y, ModContent.ProjectileType<BrassArrowProjectile>(), damage, knockBack, player.whoAmI);
                return false;
            }
            return true;
        }
    }
}
