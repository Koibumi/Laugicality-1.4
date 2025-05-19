using Laugicality.Content.Dusts;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Placeable;
using Laugicality.Content.Projectiles.NPCProj;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using System;
using Terraria.ModLoader;
using Laugicality.Utilities;
using Terraria.GameContent.ItemDropRules;

namespace Laugicality.Content.NPCs.Obsidium
{
    public class ObsidiumDriller : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 72;
            NPC.height = 48;
            NPC.damage = 22;
            NPC.defense = 14;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath3;
            NPC.value = 60f;
            NPC.knockBackResist = 0.4f;
            NPC.aiStyle = 0;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.buffImmune[24] = true;
        }
        /*
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (LaugicalityWorld.obsidiumTiles > 150 && spawnInfo.spawnTileY > WorldGen.rockLayer)
                return SpawnCondition.Cavern.Chance * 0.15f;
            else return 0f;
        }*/

        public override void AI()
        {
            //Retarget (borrowed from Dan <3)
            Player p = Main.player[NPC.target];
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
            }
            NPC.netUpdate = true;

            if (NPC.Center.Y - Main.player[NPC.target].Center.Y > 24)
            {
                if (NPC.velocity.Y > 0)
                    NPC.velocity.Y *= .9f;
                else if (Main.rand.Next(5) == 0)
                    Dust.NewDust(NPC.Center, NPC.width / 2, 4, ModContent.DustType<Magma>(), 0f, 0f);
                NPC.velocity.Y -= .2f;
            }
            else if (NPC.Center.Y - Main.player[NPC.target].Center.Y < -36)
            {
                if (NPC.velocity.Y < 0)
                    NPC.velocity.Y *= .9f;
                else if (Main.rand.Next(5) == 0)
                    Dust.NewDust(NPC.Center, NPC.width / 2, 4, ModContent.DustType<Magma>(), 0f, 0f);
                NPC.velocity.Y += .2f;
            }
            else
            {
                if ((float)Math.Abs(NPC.velocity.Y) < 2f)
                {
                    NPC.velocity.Y = 0;
                    if (Main.player[NPC.target].Center.X < NPC.Center.X)
                    {
                        if (NPC.velocity.X > 0)
                            NPC.velocity.X *= .9f;
                        else if (Main.rand.Next(5) == 0)
                            Dust.NewDust(NPC.Center, NPC.width / 2, 4, ModContent.DustType<Magma>(), 0f, 0f);
                        NPC.velocity.X -= .5f;
                    }
                    if (Main.player[NPC.target].Center.X > NPC.Center.X)
                    {
                        if (NPC.velocity.X < 0)
                            NPC.velocity.X *= .9f;
                        else if (Main.rand.Next(5) == 0)
                            Dust.NewDust(NPC.Center, NPC.width / 2, 4, ModContent.DustType<Magma>(), 0f, 0f);
                        NPC.velocity.X += .5f;
                    }
                }
                NPC.velocity.Y *= .9f;
            }
            
        }
        

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            int debuff = BuffID.OnFire;
            if (debuff >= 0)
            {
                target.AddBuff(debuff, 90, true);
            }
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
