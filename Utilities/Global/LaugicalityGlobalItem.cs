using Laugicality.Content.Items.Equipables;
using Laugicality.Content.Prefixes;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace Laugicality.Utilities.Globals
{
	public class LaugicalityGlobalItem : GlobalItem
	{
        public LaugicalityGlobalItem()
		{
            Mystic = false;
            MeleeDmg = -1;
        }

		public override bool InstancePerEntity => true;

        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.EaterOfWorldsBossBag)
            {
                int rand = Main.rand.Next(6);
                switch (rand)
                {
                    case 1:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<DarkfootBoots>(), 1));
                        break;
                    case 2:
                        itemLoot.Add(ItemDropRule.Common(ItemID.ShadowOrb, 1));
                        break;
                    case 3:
                        itemLoot.Add(ItemDropRule.Common(ItemID.Vilethorn, 1));
                        break;
                    case 4:
                        itemLoot.Add(ItemDropRule.Common(ItemID.BandofStarpower, 1));
                        break;
                    case 5:
                        itemLoot.Add(ItemDropRule.Common(ItemID.BallOHurt, 1));
                        break;
                    default:
                        itemLoot.Add(ItemDropRule.Common(ItemID.Musket, 1));
                        itemLoot.Add(ItemDropRule.Common(ItemID.MusketBall, 1, 100, 100));
                        break;
                }
            }
            if (item.type == ItemID.BrainOfCthulhuBossBag)
            {
                int rand = Main.rand.Next(6);
                switch (rand)
                {
                    case 1:
                        itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodfootBoots>(), 1));
                        break;
                    case 2:
                        itemLoot.Add(ItemDropRule.Common(ItemID.CrimsonHeart, 1));
                        break;
                    case 3:
                        itemLoot.Add(ItemDropRule.Common(ItemID.CrimsonRod, 1));
                        break;
                    case 4:
                        itemLoot.Add(ItemDropRule.Common(ItemID.PanicNecklace, 1));
                        break;
                    case 5:
                        itemLoot.Add(ItemDropRule.Common(ItemID.TheRottedFork, 1));
                        break;
                    default:
                        itemLoot.Add(ItemDropRule.Common(ItemID.TheUndertaker, 1));
                        itemLoot.Add(ItemDropRule.Common(ItemID.MusketBall, 1, 100, 100));
                        break;
                }
            }
        }

        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if(item.CountsAsClass(DamageClass.Ranged) && Main.rand.Next(30) == 0)
            {
                return ModContent.PrefixType<CarefulPrefix>();
            }
            if (item.CountsAsClass(DamageClass.Melee) && Main.rand.Next(30) == 0)
            {
                if(Main.rand.Next(2) == 0)
                    return ModContent.PrefixType<ColossalPrefix>();
                return ModContent.PrefixType<HallowedPrefix>();
            }
            if (item.CountsAsClass(DamageClass.Magic) && Main.rand.Next(30) == 0)
            {
                return ModContent.PrefixType<KnowledgeablePrefix>();
            }

            return -1;
        }

	    public override void HoldItem(Item item, Player player)
        {
            if(MeleeDmg == -1)
            {
                if (item.noMelee)
                    MeleeDmg = 0;
                else
                    MeleeDmg = 1;
            }
            
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
        }
        public bool Mystic { get; }

        public int MeleeDmg { get; set; } = -1;

    }
}
