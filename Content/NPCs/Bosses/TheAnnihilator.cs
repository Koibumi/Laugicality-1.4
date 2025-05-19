using System;
using Laugicality.Content.Buffs;
using Laugicality.Content.Dusts;
using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities;
using Terraria.GameContent.ItemDropRules;

namespace Laugicality.Content.NPCs.Bosses
{
    [AutoloadBossHead]
    public class TheAnnihilator : ModNPC
    {
        public static Random rnd = new Random();
        public int spawn = 0;
        public bool stage2 = false;
        public float vel = 1f;
        public int velMult = 1;
        public static bool on = false;
        public bool poof = false;
        public bool bitherial = true;
        public int plays = 0;
        public int frame = 0;
        public int delay = 0;
        public int fHeight = 10;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(NPC.type);
            // DisplayName.SetDefault("The Annihilator");
            Main.npcFrameCount[NPC.type] = 8;
        }

        public override void SetDefaults()
        {
            fHeight = 0;
            delay = 0;
            frame = 0;
            plays = 1;
            bitherial = true;
            poof = false;
            on = true;
            spawn = 0;
            NPC.width = 200;
            NPC.height = 240;
            NPC.damage = 100;
            NPC.defense = 32;
            NPC.aiStyle = 5;
            NPC.lifeMax = 60000;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.npcSlots = 15f;
            NPC.value = 12f;
            NPC.knockBackResist = 0f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            Music = MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/Annihilator");
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            plays = numPlayers;
            bitherial = true;
            NPC.lifeMax = 80000 + numPlayers * 8000;
            NPC.damage = 140;
        }
        

        public override void AI()
        {
            NPC.rotation = 0;

            if (NPC.active)
                on = true;
            else
                on = false;
            if (NPC.velocity.X > 12) NPC.velocity.X = 12;
            if (NPC.velocity.Y > 12) NPC.velocity.Y = 12;
            if (NPC.life < NPC.lifeMax && spawn < 1 && Main.netMode != 1)
            {
                poof = true;
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                spawn = 1;
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (NPC.life < NPC.lifeMax * .9 && spawn < 2 && Main.netMode != 1)
            {
                poof = true;
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                spawn = 2;
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (NPC.life < NPC.lifeMax * .8 && spawn < 3 && Main.netMode != 1)
            {
                poof = true;
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                spawn = 3;
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (NPC.life < NPC.lifeMax * .7 && spawn < 4 && Main.netMode != 1)
            {
                poof = true;
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                spawn = 4;
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (NPC.life < NPC.lifeMax * .6 && spawn < 5 && Main.netMode != 1)
            {
                poof = true;
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                spawn = 5;
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (NPC.life < NPC.lifeMax * .5 && spawn < 6 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    NPC.velocity *= 3;
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                }

                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                spawn = 6;
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (NPC.life < NPC.lifeMax * .4 && spawn < 7 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    NPC.velocity *= 3;
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                }
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                spawn = 7;
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (NPC.life < NPC.lifeMax * .3 && spawn < 8 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    NPC.velocity *= 3;
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                }
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                spawn = 8;
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (NPC.life < NPC.lifeMax * .2 && spawn < 9 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    NPC.velocity *= 2;
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                }
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                spawn = 9;
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (NPC.life < NPC.lifeMax * .12 && spawn < 10 && Main.netMode != 1)
            {
                poof = true;
                if (Main.expertMode)
                {
                    spawn = 10;
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalShelly>());
                }
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                spawn = 10;
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
            }
            if (NPC.life < NPC.lifeMax * .02 && spawn < 11 && Main.expertMode && Main.netMode != 1)
            {
                if (Main.expertMode)
                {
                    poof = true;
                    spawn = 11;
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalSlimer>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCreeper>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalCrawler>());
                    NPC.NewNPC(NPC.GetSource_FromThis(),(int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MechanicalMimic>());
                }
            }

            if (poof)
            {
                poof = false;

                Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, ModContent.DustType<Steam>(), 0f, 0f);
                Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, ModContent.DustType<Steam>(), 0f, 0f);
            }

            delay++;
            int phase = 0;
            if (NPC.life < NPC.lifeMax * .5)
                phase = 1;
            if (delay >= 4)
            {
                delay = 0;
                frame++;
                if (frame > phase * 4 + 3)
                    frame = phase * 4;
            }
            NPC.frame.Y = fHeight * frame;
        }


        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.expertMode)
            {
                int debuff = ModContent.BuffType<Steamy>();
                if (debuff >= 0)
                {
                    target.AddBuff(debuff, 90, true);
                }
            }
        }

        public override void OnKill()
        {
            MechanicalCreeper.despawn = true;
            MechanicalSlimer.despawn = true;
            MechanicalShelly.despawn = true;
            MechanicalMimic.despawn = true;
            MechanicalCrawler.despawn = true;

            if (plays < 1)
                plays = 1;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get();
            /*if (LaugicalityWorld.downedEtheria)
            {
                Item.NewItem((int)NPC.position.X, (int)NPC.position.Y, NPC.width, NPC.height, ModContent.ItemType<CogOfEtheria>(), 1);
            }*/
            LaugicalityWorld.downedAnnihilator = true;

        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var _Etheria = new LeadingConditionRule(new IDRNC(IDRNC.BossType.Etheria, true));

            _Etheria.OnSuccess(ItemDropRule.Common(ModContent.ItemType<CogOfEtheria>()));
            npcLoot.Add(_Etheria);

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SteamBar>(), 1, 15, 30));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulOfThought>(), 1, 20, 40));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<AnnihilatorTreasureBag>(), 1));
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 499;
        }
        public override void FindFrame(int frameHeight)
        {

            fHeight= frameHeight;
        }


        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Microsoft.Xna.Framework.Color color9 = Lighting.GetColor((int)((double)NPC.position.X + (double)NPC.width * 0.5) / 16, (int)(((double)NPC.position.Y + (double)NPC.height * 0.5) / 16.0));
            float num66 = 0f;
            Vector2 vector11 = new Vector2((float)(TextureAssets.Npc[NPC.type].Value.Width / 2), (float)(TextureAssets.Npc[NPC.type].Value.Height / Main.npcFrameCount[NPC.type] / 2));
            SpriteEffects spriteEffects = SpriteEffects.None;
            if (NPC.spriteDirection == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            Microsoft.Xna.Framework.Rectangle frame6 = NPC.frame;
            Microsoft.Xna.Framework.Color alpha15 = NPC.GetAlpha(color9);
            float num212 = 1f - (float)NPC.life / (float)NPC.lifeMax;
            num212 *= num212;
            alpha15.R = (byte)((float)alpha15.R * num212);
            alpha15.G = (byte)((float)alpha15.G * num212);
            alpha15.B = (byte)((float)alpha15.B * num212);
            alpha15.A = (byte)((float)alpha15.A * num212);
            for (int num213 = 0; num213 < 4; num213++)
            {
                Vector2 position9 = NPC.position;
                float num214 = Math.Abs(NPC.Center.X - Main.player[Main.myPlayer].Center.X);
                float num215 = Math.Abs(NPC.Center.Y - Main.player[Main.myPlayer].Center.Y);
                if (num213 == 0 || num213 == 2)
                {
                    position9.X = Main.player[Main.myPlayer].Center.X + num214;
                }
                else
                {
                    position9.X = Main.player[Main.myPlayer].Center.X - num214;
                }
                position9.X -= (float)(NPC.width / 2);
                if (num213 == 0 || num213 == 1)
                {
                    position9.Y = Main.player[Main.myPlayer].Center.Y + num215;
                }
                else
                {
                    position9.Y = Main.player[Main.myPlayer].Center.Y - num215;
                }
                position9.Y -= (float)(NPC.height / 2);
                Main.spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, new Vector2(position9.X - Main.screenPosition.X + (float)(NPC.width / 2) - (float)TextureAssets.Npc[NPC.type].Value.Width * NPC.scale / 2f + vector11.X * NPC.scale, position9.Y - Main.screenPosition.Y + (float)NPC.height - (float)TextureAssets.Npc[NPC.type].Value.Height * NPC.scale / (float)Main.npcFrameCount[NPC.type] + 4f + vector11.Y * NPC.scale + num66 + NPC.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(frame6), alpha15, NPC.rotation, vector11, NPC.scale, spriteEffects, 0f);
            }
            Main.spriteBatch.Draw(TextureAssets.Npc[NPC.type].Value, new Vector2(NPC.position.X - Main.screenPosition.X + (float)(NPC.width / 2) - (float)TextureAssets.Npc[NPC.type].Value.Width * NPC.scale / 2f + vector11.X * NPC.scale, NPC.position.Y - Main.screenPosition.Y + (float)NPC.height - (float)TextureAssets.Npc[NPC.type].Value.Height * NPC.scale / (float)Main.npcFrameCount[NPC.type] + 4f + vector11.Y * NPC.scale + num66 + NPC.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(frame6), NPC.GetAlpha(color9), NPC.rotation, vector11, NPC.scale, spriteEffects, 0f);
            return false;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 0f;
            return null;
        }
        /*
		public override void HitEffect(int hitDirection, double damage)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustType = Main.rand.Next(139, 143);
				int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
				Dust dust = Main.dust[dustIndex];
				dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
				dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
				dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
			}
		}*/
    }
}
