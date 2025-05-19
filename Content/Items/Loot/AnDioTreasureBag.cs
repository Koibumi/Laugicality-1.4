using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Useables;
using Laugicality.Content.NPCs.RockTwins;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Loot
{
    public class AnDioTreasureBag : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Treasure Bag");
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 46;
            Item.maxStack = 20;
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
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DioritusCore>(), 1, 2, 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AndesiaCore>(), 1, 2, 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ZaWarudoWatch>()));
            npcLoot.Add(ItemDropRule.Common(3081, 1, 10, 31));
            npcLoot.Add(ItemDropRule.Common(3086, 1, 10, 31));
            npcLoot.Add(ItemDropRule.Common(188, 1, 10, 15));
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ItemID.DarkLance,
                ItemID.Flamelash,
                ItemID.FlowerofFire,
                ItemID.Sunfury,
                ItemID.HellwingBow,
                ItemID.ImpStaff
            ));
            npcLoot.Add(ItemDropRule.Common(188, 1, 10, 15));
        }
    }
}