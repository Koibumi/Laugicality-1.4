using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;

namespace Laugicality.Content.Items.Loot
{
    public class SteamTank : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Steam powered!\nIncreases Mystic damage by 12%\n+20% Overflow\nIncreases movement speed by 50% and jump height by 2\nReduces the cooldown between Mystic Bursts.");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 48;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            player.jumpSpeedBoost += 2f;
            player.moveSpeed += 0.5f;
            modPlayer.MysticDamage += 0.12f;
            modPlayer.MysticSwitchCoolRate += 1;
            modPlayer.GlobalOverflow += .2f;
        }
    }
}