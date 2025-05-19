using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Ranged;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Ammo
{
	public class BrassArrow : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Redirects itself on collision.");
		}

		public override void SetDefaults()
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.knockBack = 4f;
			Item.value = 10;
			Item.rare = ItemRarityID.LightPurple;
			Item.shoot = ModContent.ProjectileType<BrassArrowProjectile>();
			Item.shootSpeed = 14f;
			Item.ammo = AmmoID.Arrow;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(33);
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}
