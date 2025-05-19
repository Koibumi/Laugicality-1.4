using Laugicality.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;

namespace Laugicality.Content.Items.Consumables.Potions
{
	public class LiquidRubrum : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Damage\n5 minute duration");
        }
        public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = 30;
			Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.DrinkLiquid;
            Item.UseSound = SoundID.Item3;
			Item.consumable = true;
            Item.buffType = ModContent.BuffType<Rubrum>();
            Item.buffTime = 5 * 60 * 60;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ModContent.ItemType<RubrumDust>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 1);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}