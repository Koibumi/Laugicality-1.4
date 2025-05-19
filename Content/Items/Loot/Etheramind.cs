using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities;
using Laugicality.Utilities.Players;
using Terraria.DataStructures;

namespace Laugicality.Content.Items.Loot
{
    [AutoloadEquip(EquipType.Wings)]
    public class Etheramind : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ascension");
            // Tooltip.SetDefault("'Rule from above'");
            ArmorIDs.Wing.Sets.Stats[Item.wingSlot] = new WingStats(210, 15f, 4f);
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.Green;
            Item.expert = true;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
                player.wingTimeMax = 210;
        }

        public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
    ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
            {
                ascentWhenFalling = 0.85f;
                ascentWhenRising = 0.185f;
                maxCanAscendMultiplier = 2.5f;
                maxAscentMultiplier = 4f;
                constantAscend = 0.15f;
            }
        }

        public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (LaugicalityWorld.downedEtheria || modPlayer.Etherable > 0)
            {
                speed = 15f;
                acceleration *= 4f;
            }
        }
    }
}