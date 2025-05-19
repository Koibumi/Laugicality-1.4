using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Equipables
{
    public class NinjaEmblem : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("+15% throwing damage");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.value = 100;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Throwing) += 0.15f;
        }
    }
}