using Terraria;
using Terraria.ID;
using Laugicality.Utilities.Base;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Materials
{
    public class BottledPinkGel : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("The Pink Gel has consumed the normal gel.\nRight Click to open.");
        }
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.maxStack = 1;
            Item.rare = ItemRarityID.Orange;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            //item.UseSound = SoundID.Item9;
            Item.consumable = true;
        }

        public override bool CanRightClick()
        {
           return true;
        }
       
        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ItemID.PinkGel, 1, 2, 5));
            itemLoot.Add(ItemDropRule.Common(ItemID.Bottle, 1));
        }
    }
}