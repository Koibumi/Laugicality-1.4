using Laugicality.Content.Buffs;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Consumables.Potions
{
	public class LiquidAquos : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Critical Strike Chance\n5 minute duration");
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
            Item.buffTime = 5 * 60 * 60;
            Item.buffType = ModContent.BuffType<Aquos>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ModContent.ItemType<AquosDust>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 1);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>()); 
            recipe.Register();
        }
    }
}