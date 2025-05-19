using System;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.NPCs.Obsidium;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities;
using Laugicality.Utilities.Players;
using Terraria.GameContent.ItemDropRules;

namespace Laugicality.Content.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class Ragnar : ModNPC, ILocalizedModType
    {
        public override void Load()
        {
            string RagnarD = this.GetLocalization("Chat.RagnarD").Value; // Fury runs through the Obsidium Caverns.
        }

        public static Random rnd = new Random();
        public int phase = 0;
        public int delay = 0;
        public int maxDelay = 60;
        public int damage = 0;
        public int shoot = 0;
        public int moveType = 1;
        public bool attacking = false;
        public bool bitherial = true;
        public float vel = 0f;
        public float tVel = 0f;
        public float vMax = 14f;
        public float vAccel = .2f;
        public float vMag = 0f;
        public double theta = 0;
        public double theta2 = 0;
        public int cycle = 0;
        public int cycle2 = 0;
        public int rotRate = 60;
        public int reload = 0;
        public int reloadMax = 120;
        public static float sizeMult = Main.maxTilesX / 2600f;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(NPC.type);
            // DisplayName.SetDefault("Ragnar");
            //Main.npcFrameCount[npc.type] = 2;
        }

        public override void SetDefaults()
        {
            reload = 0;
            rotRate = 60;
            cycle2 = 0;
            cycle = 0;
            moveType = 1;
            theta = 0;
            theta2 = 0;
            shoot = 0;
            vMag = 0f;
            vMax = 14f;
            tVel = 0f;
            phase = 0;
            bitherial = true;
            NPC.width = 88;
            NPC.height = 96;
            NPC.damage = 28;
            NPC.defense = 16;
            NPC.aiStyle = 0;
            NPC.lifeMax = 3200;
            NPC.HitSound = SoundID.NPCHit7;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.npcSlots = 15f;
            NPC.value = 12f;
            NPC.knockBackResist = 99f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.buffImmune[24] = true;
            Music = MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/Ragnar");
            damage = 32;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = 4400 + numPlayers * 800;
            NPC.damage = 36;
            damage = 34;
        }

        public override bool PreAI()
        {
            NPC.TargetClosest(true);
            return true;
        }

        public override void AI()
        {
            bitherial = true;
            Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, 127, 0f, 0f);
            Player player = Main.player[NPC.target];
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (Main.player[NPC.target].statLife <= 0) NPC.position.Y += 60;
            if (modPlayer.zoneObsidium == false)
            {
                NPC.dontTakeDamage = true;
            }
            else
            {
                NPC.dontTakeDamage = false;
            }

            Vector2 delta = Main.player[NPC.target].Center - NPC.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);

            float mag = 360;
            theta -= Math.PI / rotRate;
            if (theta < -Math.PI * 2)
            {
                cycle++;
                theta += Math.PI * 2;
            }


            Vector2 rot;
            rot.X = (float)Math.Cos(theta) * mag;
            rot.Y = (float)Math.Sin(theta) * mag;
            Vector2 targetPos = player.Center;
            reload++;
            if (moveType == 1)
            {
                vMax = 10f;
                rotRate = 120;
                theta2 -= Math.PI / 140;

                if (theta2 < -Math.PI * 2)
                {
                    theta2 += Math.PI * 2;
                    cycle2++;
                }
                reloadMax = 120;
                if (reload > reloadMax)
                {
                    reload = 0;
                    shoot = 1;
                }
                Vector2 rot1;
                rot1.X = (float)Math.Cos(theta2) * 320;
                rot1.Y = (float)Math.Sin(theta) * 120;
                targetPos = player.Center + rot1;
                targetPos.Y -= 180;
                if (cycle2 >= 2)
                {
                    if (Math.Abs(NPC.position.X - player.position.X) < 4 && NPC.Center.Y < player.Center.Y)
                    {
                        cycle2 = 0;
                        cycle = 0;
                        moveType = 2;
                    }
                }
            }
            if (moveType == 3)
            {
                moveType = 4;
                vMax = 8f;
                rotRate = 90;
                Vector2 rot3;
                rot3.X = 0;
                rot3.Y = (float)Math.Sin(theta) * mag;
                targetPos = player.Center + rot3;
                if (cycle >= 8)
                {
                    moveType++;
                    cycle = 0;
                }
                reloadMax = 90;
                if (reload > reloadMax)
                {
                    reload = 0;
                    shoot = 1;
                }
            }
            if (moveType == 4)
            {
                vMax = 12f;
                rotRate = 120;
                targetPos = player.Center + rot;
                if (NPC.life > NPC.lifeMax / 2)
                {
                    reloadMax = 90;
                    if (reload > reloadMax)
                    {
                        reload = 0;
                        shoot = 1;
                    }
                }
                else
                {
                    reloadMax = 120;
                    if (reload > reloadMax)
                    {
                        reload = 0;
                        shoot = 2;
                    }
                }
                if (cycle >= 4)
                {
                    if (Math.Abs(NPC.position.X - player.position.X) < 4 && NPC.Center.Y < player.Center.Y)
                    {
                        cycle = 0;
                        moveType++;
                    }
                }
            }
            if (moveType == 2 || moveType == 5)
            {
                vMax = 14f;
                attacking = true;
                NPC.velocity.Y = 14;
                NPC.velocity.X = 0;
                if (NPC.position.Y - Main.player[NPC.target].position.Y > 280)
                {
                    cycle = 0;
                    shoot = 2;
                    moveType += 1;
                    if (moveType == 6)
                        moveType = 1;
                }
            }
            else
            {
                float dist = Vector2.Distance(targetPos, NPC.Center);
                tVel = dist / 15;
                if (vMag < vMax && vMag < tVel)
                {
                    vMag += vAccel;
                    vMag = tVel;
                }

                if (vMag > tVel)
                {
                    vMag = tVel;
                }

                if (vMag > vMax)
                {
                    vMag = vMax;
                }

                if (dist != 0)
                {
                    NPC.velocity = NPC.DirectionTo(targetPos) * vMag;
                }
            }

            //Attacks
            //Normal Shot
            if (shoot == 1 && Main.netMode != 1)
            {
                shoot = 0;
                Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, 0, 8, ModContent.ProjectileType<RockFalling>(), (int)(damage * .7), 3, Main.myPlayer);
                if (Main.expertMode)
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, 0, 0, ModContent.ProjectileType<RockLooseMini>(), damage / 2, 3, Main.myPlayer);
            }
            //Big Boom
            if (shoot == 2 && Main.netMode != 1)
            {
                shoot = 0;
                Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X, NPC.Center.Y, 0, 5, ModContent.ProjectileType<RockFalling>(), (int)(damage * .7), 3, Main.myPlayer);

                if (Main.expertMode && NPC.life < NPC.lifeMax * 2 / 3)
                {
                    if (attacking)
                    {
                        if (Main.rand.Next(3) == 0)
                            NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MagmaCaster>());
                        else if (Main.rand.Next(2) == 0)
                            NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MagmatipedeHead>());
                    }
                    else if (Main.rand.Next(5) == 0)
                    {
                        if (Main.rand.Next(3) == 0)
                            NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MagmaCaster>());
                        else if (Main.rand.Next(2) == 0)
                            NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X + rnd.Next(0, NPC.width), (int)NPC.position.Y + rnd.Next(0, NPC.height), ModContent.NPCType<MagmatipedeHead>());
                    }
                }
                attacking = false;
            }
        }



        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.OnFire, 90, true);
            }
        }

        public override void OnKill()
        {
            string RagnarD = this.GetLocalization("Chat.RagnarD").Value;
            if (!LaugicalityWorld.downedRagnar)
                Main.NewText(RagnarD, 250, 150, 50);
            LaugicalityWorld.downedRagnar = true;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var _Etheria = new LeadingConditionRule(new IDRNC(IDRNC.BossType.Etheria, true));

            _Etheria.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MoltenEtheria>()));
            npcLoot.Add(_Etheria);

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DarkShard>(), 1, 1, 3));
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ItemID.MagicMirror,
                49,
                53,
                ItemID.HermesBoots,
                ItemID.EnchantedBoomerang,
                ItemID.LavaCharm
            ));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<RagnarTreasureBag>(), 1));
        }

        /*
        public override void FindFrame(int frameHeight)
        {
            frameHeight = 96;
            if (attacking)
            {
                npc.frame.Y = frameHeight;
            }
            else
            {
                npc.frame.Y = 0;
            }
        }*/


        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }

    }
}