using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Tools
{
	public class FrostburnPickaxe : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'The best of both worlds'");
		}

		public override void SetDefaults()
		{
			Item.damage = 40;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
			Item.height = 40;
			Item.useTime = 10;
			Item.useAnimation = 20;
			Item.pick = 160;
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
            recipe.AddIngredient(ModContent.ItemType<FrigidPickaxe>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ObsidiumPickaxe>(), 1);
            recipe.AddIngredient(ModContent.ItemType<MagmaticCrystal>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 4);
            recipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}