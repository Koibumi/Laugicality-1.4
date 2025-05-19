using Laugicality.Content.Buffs;
using Laugicality.Content.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Consumables.Potions
{
    public class SupremeMysticaPotion : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Supreme Potentia Potion");
            // Tooltip.SetDefault("Restores all Potentias to full capacity\nRestores Overflow to half capacity\nOverflow is increased by 20% while the Mysticality debuff is active");
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
            if (modPlayer.Lux < (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * (1 + (modPlayer.LuxOverflow * modPlayer.GlobalOverflow - 1) / 2))
                modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * (1 + (modPlayer.LuxOverflow * modPlayer.GlobalOverflow - 1) / 2);
            if (modPlayer.Vis < (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * (1 + (modPlayer.VisOverflow * modPlayer.GlobalOverflow - 1) / 2))
                modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * (1 + (modPlayer.VisOverflow * modPlayer.GlobalOverflow - 1) / 2);
            if (modPlayer.Mundus < (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * (1 + (modPlayer.MundusOverflow * modPlayer.GlobalOverflow - 1) / 2))
                modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * (1 + (modPlayer.MundusOverflow * modPlayer.GlobalOverflow - 1) / 2);
            player.AddBuff(ModContent.BuffType<Mysticality3>(), 60 * 60, true);
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ModContent.ItemType<GreaterMysticaPotion>(), 2);
            recipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 2);
            //recipe.AddIngredient(ModContent.ItemType<MagmaticCrystal>(), 1);
            recipe.AddTile(TileID.Bottles);
            recipe.Register();
        }
    }
}