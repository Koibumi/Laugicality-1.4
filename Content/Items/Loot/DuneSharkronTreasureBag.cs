using Laugicality.Content.Items.Materials;
using Laugicality.Content.NPCs.PreTrio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Terraria.GameContent.ItemDropRules;

namespace Laugicality.Content.Items.Loot
{
    public class DuneSharkronTreasureBag : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("");
        }
        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 34;
            Item.maxStack = 20;
            Item.rare = ItemRarityID.Orange;
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
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientShard>(), 1, 2, 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Crystilla>(), 1, 8, 15));
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ItemID.SandstorminaBottle,
                ItemID.FlyingCarpet,
                ItemID.BandofRegeneration,
                ItemID.MagicMirror,
                ItemID.CloudinaBottle,
                ItemID.HermesBoots,
                ItemID.EnchantedBoomerang
            ));
            npcLoot.Add(ItemDropRule.Common(188, 1, 10, 15));
        }
    }
}