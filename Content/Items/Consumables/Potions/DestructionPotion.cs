using Laugicality.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;

namespace Laugicality.Content.Items.Consumables.Potions
{
	public class DestructionPotion : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+10% Mystic Damage\n5 minute duration");
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
            Item.buffType = ModContent.BuffType<DestructionBoost>();
            Item.buffTime = 5 * 60 * 60;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ModContent.ItemType<AlbusDust>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AuraDust>(), 1);
            recipe.AddIngredient(ModContent.ItemType<MagmaSnapper>(), 1);
            recipe.AddIngredient(ModContent.ItemType<RubrumDust>(), 1);
            recipe.AddTile(13);
            recipe.Register();
        }
    }
}