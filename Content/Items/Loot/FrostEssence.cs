using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;

namespace Laugicality.Content.Items.Loot
{
    public class FrostEssence : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frosted Flake");
            // Tooltip.SetDefault("Attacks inflict 'Frostburn'\n+25% Snowball Damage");
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.Frost = true;
            modPlayer.SnowDamage += .25f;
        }
    }
}