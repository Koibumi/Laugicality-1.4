using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;

namespace Laugicality.Content.Items.Loot
{
    public class MoltenCore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Attacks inflict 'On Fire!'. +4 Defense \n+30% Throwing Velocity and Mystic Duration\nRelease a burst of rocks when hit");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 44;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            modPlayer.Obsidium = true;
            modPlayer.Rocks = true;
            modPlayer.MysticDuration += 0.3f;
            player.statDefense += 4;
            player.ThrownVelocity += 0.3f;
        }
    }
}