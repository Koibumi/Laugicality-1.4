using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Players;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Consumables
{
	public class EtherialEnergy : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Imbues your body with Etherial energy");
        }

        public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = 1;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item4;
			Item.consumable = true;
		}
        
        public override bool CanUseItem(Player player) => !LaugicalityPlayer.Get(player).etherialSlot;

        public override bool? UseItem(Player player)
        {
            LaugicalityPlayer.Get(player).etherialSlot = true;

            return true;
        }
    }
}