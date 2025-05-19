using Laugicality.Content.Items.Materials;
using Laugicality.Content.NPCs.PreTrio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Terraria.GameContent.ItemDropRules;

namespace Laugicality.Content.Items.Loot
{
    public class HypothemaTreasureBag : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.maxStack = 20;
            Item.rare = ItemRarityID.Green;
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

        public override void ModifyItemLoot(ItemLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostShard>(), 1, 2, 4));
            npcLoot.Add(ItemDropRule.Common(ItemID.SnowBlock, 1, 40, 75));
            npcLoot.Add(ItemDropRule.Common(ItemID.IceBlock, 1, 40, 75));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChilledBar>(), 1, 22, 36));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostEssence>(), 1));
            npcLoot.Add(ItemDropRule.Common(188, 1, 10, 15));
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ItemID.IceBoomerang,
                ItemID.IceBlade,
                ItemID.IceSkates,
                ItemID.SnowballCannon,
                987,
                ItemID.FlurryBoots
            ));
        }
    }
}