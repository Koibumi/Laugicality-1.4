using System;
using Laugicality.Content.Dusts;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities;
using Terraria.GameContent.ItemDropRules;

namespace Laugicality.Content.NPCs.PreTrio
{
    [AutoloadBossHead]
    public class DuneSharkron : ModNPC
    {
        public bool Enraged { get; set; }
        public int MovementPhaseCounter { get; set; } = 0;
        public int MovementPhaseSteps { get; set; } = 0;
        public int MovementPhase { get; set; } = 0;
        public Vector2 targetPos;
        public int AttackCounter { get; set; } = 0;
        public int AttackDelay { get; set; } = 0;
        private int DespawnCounter { get; set; } = 0;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(NPC.type);
            // DisplayName.SetDefault("Dune Sharkron");
        }

        public override void SetDefaults()
        {
            NPC.width = 150;
            NPC.height = 60;
            NPC.damage = 35;
            NPC.defense = 12;
            NPC.aiStyle = 103;
            NPC.lifeMax = 2000;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.npcSlots = 15f;
            NPC.value = 12f;
            NPC.knockBackResist = 0f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            Music = MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/DuneSharkron");
            NPC.scale = 1.25f;
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = 3500 + numPlayers * 1500;
            NPC.damage = 70;
        }

        private void Enrage()
        {
            Player player = Main.player[NPC.target];
            Enraged = !player.ZoneDesert;
            if (Enraged)
            {
                NPC.defense = 32;
                CrystalRain();
            }
            else
                NPC.defense = 12;
        }

        private bool CheckDespawn()
        {
            if (Main.player[NPC.target].statLife < 1 || Vector2.Distance(Main.player[NPC.target].Center, NPC.Center) > 3500)
            {
                DespawnCounter++;
                if (DespawnCounter > 300)
                    NPC.active = false;
                return true;
            }
            DespawnCounter = 0;
            return false;
        }

        public override void AI()
        {
            if(CheckDespawn())
                return;
            Enrage();
            PickMovement();
            CheckBounce();
            MakeDust();
            NPC.netUpdate = true;
        }

        private void PickMovement()
        {
            switch (MovementPhase)
            {
                case 1:
                    DashAI();
                    break;
                case 2:
                    SuperJumpAI();
                    break;
                case 3:
                    LeapAboveAI();
                    break;
                default:
                    FollowAI();
                    break;
            }
            SpriteDirection();
        }

        private void SpriteDirection()
        {
            Player player = Main.player[NPC.target];
            if (NPC.Center.X < player.Center.X)
                NPC.spriteDirection = -1;
            else
                NPC.spriteDirection = 1;
        }

        private void FollowAI()
        {
            Player player = Main.player[NPC.target];
            NPC.aiStyle = 103;
            MovementPhaseCounter++;
            if (MovementPhaseCounter == 5 * 60 && NPC.life < NPC.lifeMax * 2 / 3)
            {
                SandnadoSpawn();
                CrystalBurst(12);
            }
            if (MovementPhaseCounter > 5 * 60)
            {
                NPC.velocity.Y = -12;
            }
            if (MovementPhaseCounter > 5 * 60 + 30)
            {
                MovementPhaseCounter = 0;
                MovementPhase = ChangeMovementPhase(MovementPhase);
            }
            if (NPC.Center.X < player.Center.X - 800)
                NPC.velocity.X = 8;
            if (NPC.Center.X > player.Center.X + 800)
                NPC.velocity.X = -8;
            if (NPC.Center.Y > player.Center.Y + 300)
                NPC.velocity.Y = -8;
            if (NPC.Center.Y < player.Center.Y)
                CrystalRain();
            if (NPC.Center.Y > player.Center.Y + 300)
                NPC.velocity.Y -= .5f;
        }

        private void DashAI()
        {
            Player player = Main.player[NPC.target];
            NPC.aiStyle = -1;

            if (AttackDelay > 0)
            {
                AttackDelay--;
                NPC.velocity.X *= .99f;
            }
            else if (MovementPhaseSteps % 2 == 0)
            {
                if(NPC.Center.X > player.Center.X - 600)
                {
                    if (NPC.velocity.X > -12)
                        NPC.velocity.X -= .4f;
                    else
                        NPC.velocity.X *= .98f;
                }
                else
                {
                    AttackDelay = 2 * 60;
                    CrystalBurst(20);
                    if(MovementPhaseSteps == 0 && NPC.life < NPC.lifeMax / 2)
                        SandnadoSpawn();
                    MovementPhaseSteps++;
                    NPC.velocity = NPC.DirectionTo(player.Center) * 25;
                    if (MovementPhaseSteps > 4)
                        MovementPhase = ChangeMovementPhase(MovementPhase);
                    if (NPC.velocity.Y > 16)
                        NPC.velocity.Y = 16;
                    else if (NPC.velocity.Y < -16)
                        NPC.velocity.Y = -16;
                }
            }
            else
            {
                if (NPC.Center.X < player.Center.X + 600)
                {
                    if (NPC.velocity.X < 12)
                        NPC.velocity.X += .4f;
                    else
                        NPC.velocity.X *= .98f;
                }
                else
                {
                    AttackDelay = 2 * 60;
                    CrystalBurst(20);
                    if (MovementPhaseSteps == 3 && NPC.life < NPC.lifeMax / 2)
                        SandnadoSpawn();
                    MovementPhaseSteps++;
                    NPC.velocity = NPC.DirectionTo(player.Center) * 25;
                    if (MovementPhaseSteps > 4)
                        MovementPhase = ChangeMovementPhase(MovementPhase);
                    if (NPC.velocity.Y > 16)
                        NPC.velocity.Y = 16;
                    else if(NPC.velocity.Y < -16)
                        NPC.velocity.Y = -16;
                }
            }

            if (NPC.Center.Y > player.Center.Y + 300)
                NPC.velocity.Y -= .5f;
            else
                NPC.velocity.Y += .4f;

            if (NPC.velocity.Y > 16)
                NPC.velocity.Y = 16;
            else if (NPC.velocity.Y < -16)
                NPC.velocity.Y = -16;

            if (NPC.Center.Y < player.Center.Y)
                CrystalRain();
        }

        private void SuperJumpAI()
        {
            Player player = Main.player[NPC.target];
            NPC.aiStyle = -1;

            if (AttackDelay > 0)
                AttackDelay--;

            if (NPC.Center.X < player.Center.X - 80)
                NPC.velocity.X += .1f;
            else if (NPC.Center.X > player.Center.X + 80)
                NPC.velocity.X -= .1f;
            else if (NPC.Center.Y > player.Center.Y + 180 && AttackDelay == 0)
            {
                NPC.velocity.Y = -20;
                AttackDelay = 2 * 60;
                if (MovementPhaseCounter == 0)
                {
                    NPC.velocity.X *= .5f;
                    MovementPhaseCounter++;
                    MovementPhaseSteps++;

                    SandnadoSpawn();
                    CrystalBurst(12);
                    if (MovementPhaseSteps > 2)
                        MovementPhase = ChangeMovementPhase(MovementPhase);
                }
            }
            else if (MovementPhaseCounter > 0)
                MovementPhaseCounter = 0;
            else
                NPC.velocity.X *= .9f;

            if (NPC.Center.Y < player.Center.Y)
                CrystalRain();
            if (NPC.Center.Y > player.Center.Y + 300)
                NPC.velocity.Y -= .5f;
            if(NPC.velocity.Y < 8)
                NPC.velocity.Y += .4f;
        }

        private void LeapAboveAI()
        {
            Player player = Main.player[NPC.target];
            NPC.aiStyle = -1;
            if (MovementPhaseSteps % 2 == 0)
            {
                if (NPC.Center.X > player.Center.X - 800)
                {
                    if (NPC.velocity.X > -12)
                        NPC.velocity.X -= .4f;
                    else
                        NPC.velocity.X *= .98f;
                }
                else if(NPC.Center.Y > player.Center.Y + 150)
                {
                    MovementPhaseSteps++;
                    NPC.velocity.X = 28;
                    NPC.velocity.Y = -24;
                    if (MovementPhaseSteps > 4)
                        MovementPhase = ChangeMovementPhase(MovementPhase);
                }
                else
                {
                    NPC.velocity.X *= .98f;
                    if (NPC.Center.Y > player.Center.Y + 200)
                        NPC.velocity.Y -= .8f;
                    else
                        NPC.velocity.Y += .4f;
                }
            }
            else
            {
                if (NPC.Center.X < player.Center.X + 800)
                {
                    if (NPC.velocity.X < 12)
                        NPC.velocity.X += .4f;
                    else
                        NPC.velocity.X *= .98f;
                }
                else if (NPC.Center.Y > player.Center.Y + 150)
                {
                    MovementPhaseSteps++;
                    NPC.velocity.X = -28;
                    NPC.velocity.Y = -24;
                    if (MovementPhaseSteps > 4)
                        MovementPhase = ChangeMovementPhase(MovementPhase);
                }
                else
                {
                    NPC.velocity.X *= .98f;
                    if (NPC.Center.Y > player.Center.Y + 200)
                        NPC.velocity.Y -= .8f;
                    else
                        NPC.velocity.Y += .4f;
                }
            }
            if (NPC.Center.Y > player.Center.Y + 300)
                NPC.velocity.Y -= .5f;
            NPC.velocity.Y += .4f;
            if (NPC.Center.Y < player.Center.Y)
                CrystalRain();
            CrystalRain();
        }

        private int ChangeMovementPhase(int prevPhase)
        {
            MovementPhaseSteps = 0;
            MovementPhaseCounter = 0;
            AttackDelay = 0;
            if (prevPhase == 0)
                return Main.rand.Next(1, 4);
            return 0;
        }

        private void SandnadoSpawn()
        {
            Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, -4), ModContent.ProjectileType<Sandnado>(), NPC.damage / 4, 3f, NPC.target, 0, 1);
        }

        private void CrystalRain()
        {
            AttackCounter++;
            if (AttackCounter > 15)
            {
                float theta = Main.rand.NextFloat() * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 3 + 3;
                if (Main.netMode != 1)
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), ModContent.ProjectileType<SharkronCrystalShard>(), NPC.damage / 4, 3f);
                if (NPC.life < NPC.lifeMax / 2)
                {
                    theta = Main.rand.NextFloat() * (float)Math.PI;
                    mag = Main.rand.NextFloat() * 3 + 3;
                    if (Main.netMode != 1)
                        Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), ModContent.ProjectileType<SharkronCrystalShard>(), NPC.damage / 4, 3f);
                }
                AttackCounter = 0;
            }
        }

        private void CrystalBurst(int amount)
        {
            if (amount < 1)
                amount = 1;
            for (int i = 0; i < amount; i++)
            {
                float theta = Main.rand.NextFloat() * (float)Math.PI;
                float mag = Main.rand.NextFloat() * 3 + 3;
                Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2((float)Math.Cos(theta) * mag, (float)Math.Sin(theta) * -mag), ModContent.ProjectileType<SharkronCrystalShard>(), NPC.damage / 4, 3f);
            }
        }

        private void CheckBounce()
        {
            Player player = Main.player[NPC.target];
            if (NPC.position.Y > player.position.Y + 800)
                NPC.velocity.Y = -16;
        }

        private float MoveToTarget(float mag)
        {
            float dist = Vector2.Distance(targetPos, NPC.Center);

            if (dist != 0)
            {
                NPC.velocity = NPC.DirectionTo(targetPos) * mag;
            }
            return dist;
        }

        private void MakeDust()
        {
            if(Main.tile[(int)NPC.Center.X / 16, (int)NPC.Center.Y / 16].TileType != 0)
                Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, ModContent.DustType<White>(), 0f, 0f);
        }

        public override void OnKill()
        {
            LaugicalityWorld.downedDuneSharkron = true;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var _Etheria = new LeadingConditionRule(new IDRNC(IDRNC.BossType.Etheria, true));

            _Etheria.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Etheramind>()));
            npcLoot.Add(_Etheria);

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<DuneSharkronTreasureBag>(), 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientShard>(), 1, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Crystilla>(), 1, 4, 11));
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ItemID.SandstorminaBottle,
                ItemID.FlyingCarpet,
                ItemID.BandofRegeneration,
                ItemID.MagicMirror,
                ItemID.CloudinaBottle,
                ItemID.HermesBoots,
                ItemID.EnchantedBoomerang
            ));
        }


        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }
    }
}
