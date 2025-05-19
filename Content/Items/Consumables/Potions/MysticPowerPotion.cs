using Laugicality.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Placeable;

namespace Laugicality.Content.Items.Consumables.Potions
{
	public class MysticPowerPotion : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Mystic Damage");
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
            Item.buffType = ModContent.BuffType<MysticPower>();
            Item.buffTime = 3 * 60 * 60;
        }
        /*
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(null, "AlbusDust", 1);
            recipe.AddIngredient(null, "AuraDust", 1);
            recipe.AddIngredient(null, "RubrumDust", 1);
            recipe.AddIngredient(null, "VerdiDust", 1);
            recipe.AddIngredient(null, "RegisDust", 1);
            recipe.AddIngredient(null, "AquosDust", 1);
            recipe.AddTile(13);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/
    }
}