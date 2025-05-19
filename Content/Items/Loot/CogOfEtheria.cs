using Terraria;
using Terraria.ID;
using Laugicality.Utilities;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Loot
{
    public class CogOfEtheria : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Annihilation");
            // Tooltip.SetDefault("Killing an enemy while in the Etherial boosts your damage by 20% for 10 seconds. Killing another enemy in this time resets the timer and stacks the bonus.");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
                modPlayer.EtherCog = true;
        }
    }
}