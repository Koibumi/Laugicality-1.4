using Laugicality.Content.Items.Equipables;
using Laugicality.Content.NPCs.PreTrio;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Terraria.GameContent.ItemDropRules;

namespace Laugicality.Content.Items.Loot
{
    public class RagnarTreasureBag : LaugicalityItem
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
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DarkShard>(), 1, 2, 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MoltenCore>()));
            npcLoot.Add(ItemDropRule.Common(188, 1, 10, 15));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ObsidiumChunk>(), 1, 3, 5));
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ItemID.MagicMirror,
                ModContent.ItemType<ObsidiumLily>(),
                ModContent.ItemType<FireDust>(),
                ModContent.ItemType<Eruption>(),
                ModContent.ItemType<CrystalizedMagma>(),
                ModContent.ItemType<Ragnashia>(),
                ModContent.ItemType<MagmaHeart>()
            ));
        }
    }
}