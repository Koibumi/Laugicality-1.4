using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;

namespace Laugicality.Content.Items.Weapons.Melee
{
	public class FrigidYoyo : LaugicalityItem
	{
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frigid Yoyo");
            // Tooltip.SetDefault("");
            
			ItemID.Sets.Yoyo[Item.type] = true;
			ItemID.Sets.GamepadExtraRange[Item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.useStyle = 5;
			Item.width = 34;
			Item.height = 34;
			Item.useAnimation = 25;
			Item.useTime = 25;
			Item.shootSpeed = 16f;
			Item.knockBack = 2.5f;
			Item.damage = 38;
			Item.rare = ItemRarityID.Blue;

			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.noMelee = true;
			Item.noUseGraphic = true;

			Item.UseSound = SoundID.Item1;
			Item.value = Item.sellPrice(silver: 1);
			Item.shoot = ModContent.ProjectileType<Projectiles.Melee.FrigidYoyoProjectile>();
		}

		public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
	}
}
