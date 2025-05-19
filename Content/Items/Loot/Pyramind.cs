using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;

namespace Laugicality.Content.Items.Loot
{
    public class Pyramind : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Increases your minion capacity\n+40 Mana\nIncreased Potentia Regen");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.maxMinions += 1;
            player.statManaMax2 += 40;
            modPlayer.LuxRegen += .02f;
            modPlayer.VisRegen += .02f;
            modPlayer.MundusRegen += .02f;
        }
    }
}