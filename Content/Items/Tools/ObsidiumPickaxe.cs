using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Tools
{
	public class ObsidiumPickaxe : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'It's molten inside'");
		}

		public override void SetDefaults()
		{
			Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
			Item.height = 40;
			Item.useTime = 15;
			Item.useAnimation = 30;
			Item.pick = 100;
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
            recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 14);
            recipe.AddIngredient(ItemID.Obsidian, 10);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}