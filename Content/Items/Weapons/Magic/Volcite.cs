using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Magic
{
	public class Volcite : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Volcanic Eruption");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 10;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.Magic.VolciteProjectile>();
			Item.shootSpeed = 18f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 16);
			recipe.AddTile(16);
			recipe.Register();
		}
	}
}