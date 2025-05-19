using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Tools
{
	public class FrigidPickaxe : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'Slow and steady'");
		}

		public override void SetDefaults()
		{
			Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
			Item.height = 40;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.pick = 90;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
		}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 14);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}