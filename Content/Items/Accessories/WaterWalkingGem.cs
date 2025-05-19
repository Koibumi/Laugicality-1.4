using Laugicality.Content.Tiles;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Accessories
{
    public class WaterWalkingGem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Allows the ability to walk on water\nUse to toggle this effect in higher tier gems.");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 28;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.UseSound = SoundID.Item9;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.waterWalk = true;
        }
        
        public override bool? UseItem(Player player)
        {
            LaugicalityPlayer.Get(player).ww = !LaugicalityPlayer.Get(player).ww;
            Main.NewText(LaugicalityPlayer.Get(player).ww.ToString(), 250, 250, 0);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(302, 4);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}