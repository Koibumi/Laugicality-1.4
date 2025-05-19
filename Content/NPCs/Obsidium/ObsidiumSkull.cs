using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Placeable;
using Laugicality.Utilities;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using static Laugicality.Utilities.IDRNC;

namespace Laugicality.Content.NPCs.Obsidium
{
    public class ObsidiumSkull : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 32;
            NPC.height = 32;
            NPC.damage = 35;
            NPC.defense = 4;
            NPC.lifeMax = 50;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath3;
            NPC.value = 60f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 10;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.buffImmune[24] = true;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            target.AddBuff(BuffID.OnFire, 90, true);
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var Ragna = new LeadingConditionRule(new IDRNC(IDRNC.BossType.Ragnar, true)); 
            var boss2 = new LeadingConditionRule(new IDRNC(IDRNC.BossType.BothEvilBosses, true));

            Ragna.OnSuccess(ItemDropRule.Common(ModContent.ItemType<ObsidiumChunk>(), 2));
            npcLoot.Add(Ragna);

            boss2.OnSuccess(ItemDropRule.Common(ModContent.ItemType<ObsidiumOre>(), 1, 1, 4));
            npcLoot.Add(boss2);

            npcLoot.Add(ItemDropRule.Common(173, 4));
        }
    }
}
