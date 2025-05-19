using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Equipables
{
    public class Eruption : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eruption");
            // Tooltip.SetDefault("Release an Eruption when changing Mysticism.\n+5% Mystic Burst Damage");
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 36;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.MysticEruption = true;
            modPlayer.MysticBurstDamage += .05f;
        }
        
    }
}