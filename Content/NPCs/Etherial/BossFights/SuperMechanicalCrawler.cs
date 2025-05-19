using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities;

namespace Laugicality.Content.NPCs.Etherial.BossFights
{
    public class SuperMechanicalCrawler : ModNPC
    {
        public override void SetDefaults()
        {
            LaugicalityVars.etherial.Add(NPC.type);
            NPC.width = 18;
            NPC.height = 18;
            NPC.damage = 80;
            NPC.defense = 80;
            NPC.lifeMax = 4000;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.value = 60f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = 0;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
        }
    }
}
