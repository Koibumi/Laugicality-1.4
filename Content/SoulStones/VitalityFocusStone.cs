using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Focuses;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.SoulStones
{
    public class VitalityFocusStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Infuses your Soul with Vitality");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.maxStack = 20;
            Item.rare = ItemRarityID.Orange;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item9;
            Item.consumable = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }
        
        public override void RightClick(Player player)
        {
            player.GetModPlayer<LaugicalityPlayer>().Focus = FocusManager.Instance.Vitality;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.AlchemicalInfuser>());
            recipe.Register();
        }
    }
}