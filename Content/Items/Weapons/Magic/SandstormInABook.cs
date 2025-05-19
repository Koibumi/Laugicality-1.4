using Laugicality.Content.Projectiles.Magic;
using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Magic
{
	public class SandstormInABook : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sandstorm in a Book");
            // Tooltip.SetDefault("Don't try to read it");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 35;
			Item.DamageType = DamageClass.Magic;
			Item.mana = 20;
			Item.width = 28;
			Item.height = 30;
			Item.useTime = 90;
			Item.useAnimation = 90;
			Item.useStyle = 5;
			Item.noMelee = true;
			Item.knockBack = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item20;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<BookSandstormBottom>();
			Item.shootSpeed = 4f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddIngredient(ItemID.FossilOre, 6);
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 1);
            recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}