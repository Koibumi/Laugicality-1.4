using Laugicality.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Items.Materials;

namespace Laugicality.Content.Items.Consumables.Potions
{
	public class LiquidVerdi : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Max Run Speed\n5 minute duration");
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
		}
        

        public override bool? UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<Verdi>(), 5*60*60, true);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ModContent.ItemType<VerdiDust>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 1);
            recipe.AddTile(ModContent.TileType<Tiles.AlchemicalInfuser>());
            recipe.Register();
        }
    }
}