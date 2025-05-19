using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Loot
{
    public class SteamTrainTreasureBag : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.maxStack = 20;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.rare = ItemRarityID.Purple;
            Item.expert = true;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void ModifyItemLoot(ItemLoot itemLoot)
        {
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SteamBar>(), 1, 20, 35));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulOfWrought>(), 1, 25, 40));
            itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SteamTank>(), 1));
            itemLoot.Add(ItemDropRule.Common(499, 1, 10, 15));
        }
    }
}