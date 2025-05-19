using Laugicality.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Equipables
{
    public class MagmaHeart : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Magma Heart");
            // Tooltip.SetDefault("+15% Damage, +10 Defense, and Increased Mobility for a time after being submerged in Lava");
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
            if(player.lavaWet)
                player.AddBuff(ModContent.BuffType<MagmaticVeins>(), 60 * 15);
        }
    }
}