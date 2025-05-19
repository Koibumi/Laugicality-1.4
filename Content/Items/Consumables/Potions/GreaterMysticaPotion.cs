using Laugicality.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Items.Materials;

namespace Laugicality.Content.Items.Consumables.Potions
{
    public class GreaterMysticaPotion : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Greater Potentia Potion");
            // Tooltip.SetDefault("Restores all Potentias to full capacity\nDoes not remove Overflow\nOverflow is increased by 10% while the Mysticality debuff is active");
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
            if (modPlayer.Lux < modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost)
                modPlayer.Lux = modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost;
            if (modPlayer.Vis < modPlayer.VisMax + modPlayer.VisMaxPermaBoost)
                modPlayer.Vis = modPlayer.VisMax + modPlayer.VisMaxPermaBoost;
            if (modPlayer.Mundus < modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost)
                modPlayer.Mundus = modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost;
            player.AddBuff(ModContent.BuffType<Mysticality2>(), 60 * 60, true);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ModContent.ItemType<MysticaPotion>(), 2);
            recipe.AddIngredient(ModContent.ItemType<LiquidVerdi>(), 1);
            recipe.AddIngredient(ModContent.ItemType<MagmaSnapper>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 1);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}