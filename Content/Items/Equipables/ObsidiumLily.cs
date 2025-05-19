using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Equipables
{
    public class ObsidiumLily : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Obsidium Lily");
            // Tooltip.SetDefault("Immunity to Lava, Burning, and 'On Fire!'\n+10% Damage and +5 Defense in the Obsidium and Underworld");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = player.GetModPlayer<LaugicalityPlayer>();
            if(player.ZoneUnderworldHeight || modPlayer.zoneObsidium)
            {
                modPlayer.DamageBoost(.1f);
                player.statDefense += 5;
            }
            player.lavaImmune = true;
            player.fireWalk = true;
            player.buffImmune[BuffID.OnFire] = true;
        }
    }
}