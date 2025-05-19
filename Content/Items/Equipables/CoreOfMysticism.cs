using Laugicality.Content.Items.Loot;
using Laugicality.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Equipables
{
    public class CoreOfMysticism : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Core of Mysticism");
            // Tooltip.SetDefault("+15% Mystic Damage\n25% more Mystica is transfered when used");
        }

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.value = 100;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.GlobalAbsorbRate += .25f;
            modPlayer.MysticDamage += .15f;
        }
        
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DestructionCore>(), 1);
            recipe.AddIngredient(ModContent.ItemType<IllusionCore>(), 1);
            recipe.AddIngredient(ModContent.ItemType<ConjurationCore>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SoulOfWrought>(), 8);
            recipe.AddTile(ModContent.TileType<MineralEnchanterTile>());
            recipe.Register();
        }
    }
}