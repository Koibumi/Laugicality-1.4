using System;
using Laugicality.Content.Buffs;
using Laugicality.Content.Dusts;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
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
    public class Hypothema : ModNPC
    {
        public int despawn = 0;

        public int MovementPhase { get; set; } = 0;
        public int MovementCounter { get; set; } = 0;
        public bool YPassed { get; set; } = false;
        public bool XPassed { get; set; } = false;
        public Vector2 targetPos;
        private float xAccel = 0;

        public int AttackCounter { get; set; } = 0;
        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(NPC.type);
            // DisplayName.SetDefault("Hypothema");
        }

        public override void SetDefaults()
        {
            NPC.width = 64;
            NPC.height = 64;
            NPC.damage = 40;
            NPC.defense = 8;
            NPC.aiStyle = 0;
            NPC.lifeMax = 3000;
            NPC.HitSound = SoundID.NPCHit5;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.npcSlots = 15f;
            NPC.value = 12f;
            NPC.knockBackResist = 0f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            //bossBag = ModContent.ItemType<HypothemaTreasureBag>();
            Music = MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/Hypothema");
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = 5000 + numPlayers * 2000;
            NPC.damage = 80;
        }


        public override void AI()
        {
            DespawnCheck(NPC);
            for(int i = 0; i < 3; i++)
                Dust.NewDust(NPC.position + NPC.velocity, NPC.width, NPC.height, ModContent.DustType<Frost>(), 0f, 0f);
            NPC.dontTakeDamage = !Main.player[NPC.target].ZoneSnow;
            Movement();
            Attacks();
        }

        private void Movement()
        {
            switch (MovementPhase)
            {
                case 0:
                    Hover();
                    break;
                case 1:
                    Dash();
                    break;
                case 2:
                    Fall();
                    break;
                default:
                    Follow();
                    break;
            }
            NPC.netUpdate = true;
        }

        private void Hover()
        {
            targetPos = Main.player[NPC.target].Center + new Vector2(0, -120);
            if (NPC.Center.Y > targetPos.Y)
            {
                NPC.velocity.Y -= .2f;
                if (NPC.velocity.Y > 0)
                    NPC.velocity.Y *= .98f;
            }
            if (NPC.Center.Y < targetPos.Y)
            {
                NPC.velocity.Y += .2f;
                if (NPC.velocity.Y < 0)
                    NPC.velocity.Y *= .98f;
            }
            if (Math.Abs(NPC.velocity.Y) > 16)
                NPC.velocity.Y *= .98f;
            if (NPC.Center.X > targetPos.X)
                xAccel -= .2f;
            if (NPC.Center.X < targetPos.X)
                xAccel += .2f;
            if (Math.Abs(xAccel) > 16)
                xAccel *= .98f;
            NPC.velocity.X = xAccel;
            MovementCounter++;
            if(MovementCounter > 12 * 60)
            {
                ResetMovementPhase();
                MovementPhase++;
            }
        }

        private void Dash()
        {
            if(MovementCounter % 2 == 0)
                targetPos = Main.player[NPC.target].Center + new Vector2(300, 0);
            else
                targetPos = Main.player[NPC.target].Center + new Vector2(-300, 0);
            if (NPC.Center.Y > targetPos.Y)
            {
                NPC.velocity.Y -= .2f;
                if (NPC.velocity.Y > 0)
                    NPC.velocity.Y *= .9f;
            }
            if (NPC.Center.Y < targetPos.Y)
            {
                NPC.velocity.Y += .2f;
                if (NPC.velocity.Y < 0)
                    NPC.velocity.Y *= .9f;
            }
            if (Math.Abs(NPC.velocity.Y) > 16)
                NPC.velocity.Y *= .98f;
            if (NPC.Center.X > targetPos.X)
            {
                xAccel -= .3f;
                if (MovementCounter % 2 == 0)
                {
                    MovementCounter++;
                    Burst();
                }
            }
            if (NPC.Center.X < targetPos.X)
            {
                xAccel += .3f;
                if (MovementCounter % 2 != 0)
                {
                    MovementCounter++;
                    Burst();
                }
            }
            if (Math.Abs(xAccel) > 16)
                xAccel *= .98f;
            NPC.velocity.X = xAccel;
            if (MovementCounter > 6)
            {
                ResetMovementPhase();
                MovementPhase++;
            }
        }

        private void Fall()
        {
            if (MovementCounter % 2 == 0)
                targetPos = Main.player[NPC.target].Center + new Vector2(0, 150);
            else
                targetPos = Main.player[NPC.target].Center + new Vector2(0, -150);
            if (NPC.Center.Y > targetPos.Y)
            {
                NPC.velocity.Y -= .45f;
                if (MovementCounter % 2 == 0)
                    MovementCounter++;
            }
            if (NPC.Center.Y < targetPos.Y)
            {
                NPC.velocity.Y += .3f;
                if (MovementCounter % 2 != 0)
                    MovementCounter++;
            }
            if (Math.Abs(NPC.velocity.Y) > 16)
                NPC.velocity.Y *= .98f;
            if (NPC.Center.X > targetPos.X)
            {
                xAccel -= .3f;
                if (NPC.velocity.X > 0)
                    NPC.velocity.X *= .9f;
            }
            if (NPC.Center.X < targetPos.X)
            {
                xAccel += .3f;
                if (NPC.velocity.X < 0)
                    NPC.velocity.X *= .9f;
            }
            if (Math.Abs(xAccel) > 16)
                xAccel *= .98f;
            NPC.velocity.X = xAccel;
            if (MovementCounter > 6)
            {
                ResetMovementPhase();
                MovementPhase++;
            }
            if(Main.rand.NextBool(4) || NPC.life < NPC.lifeMax / 3)
                Hail();
        }

        private void Follow()
        {
            targetPos = Main.player[NPC.target].Center;
            if (NPC.Center.Y > targetPos.Y)
            {
                NPC.velocity.Y -= .3f;
                if (NPC.velocity.Y > 0)
                    NPC.velocity.Y *= .9f;
            }
            if (NPC.Center.Y < targetPos.Y)
            {
                NPC.velocity.Y += .3f;
                if (NPC.velocity.Y < 0)
                    NPC.velocity.Y *= .9f;
            }
            if (NPC.Center.X > targetPos.X)
            {
                xAccel -= .3f;
                if (NPC.velocity.X > 0)
                    NPC.velocity.X *= .95f;
            }
            if (NPC.Center.X < targetPos.X)
            {
                xAccel += .3f;
                if (NPC.velocity.X < 0)
                    NPC.velocity.X *= .95f;
            }
            if (Math.Abs(xAccel) > 16)
                xAccel *= .98f;
            NPC.velocity.X = xAccel;
            MovementCounter++;
            if (MovementCounter > 12 * 60)
            {
                ResetMovementPhase();
                MovementPhase = 0;
            }
        }

        private void ResetMovementPhase()
        {
            MovementCounter = 0;
            YPassed = false;
            XPassed = false;
        }

        private void Attacks()
        {
            if (NPC.Center.Y < Main.player[NPC.target].Center.Y - 140 && Math.Abs(NPC.Center.X - Main.player[NPC.target].Center.X) < 250)
                Hail();
        }

        private void Hail()
        {
            if (Main.rand.Next(4) == 0 && Main.netMode != 1)
                Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(NPC.Center.X - 12 + Main.rand.Next(24), NPC.Center.Y - 12 + Main.rand.Next(24)), new Vector2(0, 9), ModContent.ProjectileType<HailProj>(), NPC.damage / 4, 1);
        }

        private void Burst()
        {
            if(Main.netMode != 1)
            {
                for(int i = 0; i < 12; i++)
                {
                    float theta = Main.rand.NextFloat() * 2 * (float)Math.PI;
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2((float)Math.Cos(theta) * 8, (float)Math.Sin(theta) * 8), ModContent.ProjectileType<HailProj>(), NPC.damage / 4, 1);
                }
                if(NPC.life < NPC.lifeMax / 2)
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 0), ModContent.ProjectileType<IceShard>(), NPC.damage / 4, 1);
            }
        }

        private void DespawnCheck(NPC npc)
        {
            if (Main.player[npc.target].statLife < 1 || Vector2.Distance(Main.player[npc.target].Center, npc.Center) > 2500)
            {
                npc.TargetClosest(true);
                if (Main.player[npc.target].statLife < 1 || Vector2.Distance(Main.player[npc.target].Center, npc.Center) > 2500)
                {
                    if (despawn == 0)
                        despawn++;
                }
                else
                    despawn = 0;
            }
            if (despawn >= 1)
            {
                despawn++;
                npc.noTileCollide = true;
                npc.velocity.Y = 8f;
                if (despawn >= 300)
                    npc.active = false;
            }
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (LaugicalityWorld.downedEtheria)
            {
                target.AddBuff(ModContent.BuffType<Frostbite>(), 4 * 60, true);
            }
            if (Main.expertMode)
            {
                target.AddBuff(BuffID.Frostburn, 90, true);
                target.AddBuff(BuffID.Chilled, 60, true);
            }
        }

        public override void OnKill()
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get();

            LaugicalityWorld.downedHypothema = true;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var _Etheria = new LeadingConditionRule(new IDRNC(IDRNC.BossType.Etheria, true));

            _Etheria.OnSuccess(ItemDropRule.Common(ModContent.ItemType<EtherialFrost>()));
            npcLoot.Add(_Etheria);

            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<HypothemaTreasureBag>(), 1));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostShard>(), 1, 1, 3));
            npcLoot.Add(ItemDropRule.Common(ItemID.SnowBlock, 1, 30, 60));
            npcLoot.Add(ItemDropRule.Common(ItemID.IceBlock, 1, 30, 60));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChilledBar>(), 1, 16, 25));
            npcLoot.Add(ItemDropRule.OneFromOptions(1,
                ItemID.IceBoomerang,
                ItemID.IceBlade,
                ItemID.IceSkates,
                ItemID.SnowballCannon,
                987,
                ItemID.FlurryBoots
            ));
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 188;
        }

    }
}
