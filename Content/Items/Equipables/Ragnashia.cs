using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Equipables
{
    public class Ragnashia : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ragnashia");
            // Tooltip.SetDefault("+5% Crit Chance\nSet nearby enemies ablaze");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 0 + 0 * 100 + 5 * 10000;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.defense = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LaugicalityPlayer>().CritBoost(5);
            player.GetModPlayer<LaugicalityPlayer>().Blaze = true;
        }
    }
}