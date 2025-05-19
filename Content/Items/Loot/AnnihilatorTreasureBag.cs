using Laugicality.Content.NPCs.Bosses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Terraria.GameContent.ItemDropRules;

namespace Laugicality.Content.Items.Loot
{
    public class AnnihilatorTreasureBag : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Treasure Bag");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 30;
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
        public override void ModifyItemLoot(ItemLoot itmeLoot)
        {
            itmeLoot.Add(ItemDropRule.Common(ModContent.ItemType<SteamBar>(), 1, 20, 35));
            itmeLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulOfThought>(), 1, 25, 40));
            itmeLoot.Add(ItemDropRule.Common(ModContent.ItemType<CogOfKnowledge>(), 1));
            itmeLoot.Add(ItemDropRule.Common(499, 1, 10, 15));
        }
    }
}