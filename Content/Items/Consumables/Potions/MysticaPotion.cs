using Laugicality.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Placeable;

namespace Laugicality.Content.Items.Consumables.Potions
{
    public class MysticaPotion : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Potentia Potion");
            // Tooltip.SetDefault("Restores all Potentias to full capacity, but removes Overflow");
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

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<LaugicalityPlayer>().Mysticality == 0;
        }

        public override bool? UseItem(Player player)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>();
            modPlayer.Lux = modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost;
            modPlayer.Vis = modPlayer.VisMax + modPlayer.VisMaxPermaBoost;
            modPlayer.Mundus = modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost;
            player.AddBuff(ModContent.BuffType<Mysticality>(), 60 * 60, true);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.BottledWater, 1);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<VerdiDust>(), 1);
            recipe.AddIngredient(ModContent.ItemType<LavaGem>(), 1);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}