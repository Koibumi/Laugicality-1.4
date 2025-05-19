using System;
using Laugicality.Content.Buffs;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.NPCs.Slybertron;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities;
using Terraria.Audio;
using Laugicality.Utilities.Players;
using Terraria.GameContent.ItemDropRules;

namespace Laugicality.Content.NPCs.SteamTrain
{
    [AutoloadBossHead]
    public class SteamTrain : ModNPC
    {
        public override void Load()
        {
            string SteamTrainSay = this.GetLocalization("Chat.SteamTrainSay").Value; // Superdrive.
            string SteamTrainSay2 = this.GetLocalization("Chat.SteamTrainSay2").Value; // Hyperdrive.
            string SteamTrainSay3 = this.GetLocalization("Chat.SteamTrainSay3").Value; // Warpdrive.
            string SteamTrainSay4 = this.GetLocalization("Chat.SteamTrainSay4").Value; // CHOO CHOO!
        }
        private static readonly int _phase_Normaldrive = 0;
        private static readonly int _phase_Superdrive = 1;
        private static readonly int _phase_Hyperdrive = 2;
        private static readonly int _phase_Warpdrive = 3;
        private static readonly int _phase_Choochoo = 4;

        public static Random rnd = new Random();
        public int spawn = 0;
        public bool stage2 = false;
        public int phase = 0;
        public int dir = 0;
        public int vdir = 0;
        public float accel = 0f;
        public float maxAccel = 20f;
        public float vaccel = 0f;
        public float maxVaccel = 20f;
        public bool boosted = false;
        public int delay = 0;
        public int maxDelay = 60;
        public int range = 2000;
        public bool bitherial = true;
        public int plays = 0;
        int _despawn = 0;
        int _baseDamage = 0;

        public override void SetStaticDefaults()
        {
            LaugicalityVars.eNPCs.Add(NPC.type);
            // DisplayName.SetDefault("Steam Train");
        }

        public override void SetDefaults()
        {
            _baseDamage = 0;
            _despawn = 0;
            plays = 1;
            bitherial = true;
            maxDelay = 60;
            range = 2200;
            maxAccel = 20f;
            maxVaccel = 20f;
            accel = 0f;
            vaccel = 0f;
            spawn = 0;
            phase = 0;
            dir = 0;
            vdir = 0;
            delay = 0;
            boosted = false;
            NPC.width = 1700;
            NPC.height = 92;
            NPC.damage = 90;
            NPC.defense = 30;
            NPC.aiStyle = 0;
            NPC.lifeMax = 42000;
            NPC.HitSound = SoundID.NPCHit4;
            NPC.DeathSound = SoundID.NPCDeath14;
            NPC.npcSlots = 15f;
            NPC.value = 12f;
            NPC.knockBackResist = 0f;
            NPC.boss = true;
            NPC.lavaImmune = true;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.netAlways = true;
            Music = MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/SteamTrain");
        }

        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            plays = numPlayers;
            NPC.lifeMax = 50000 + numPlayers * 6000;
            NPC.damage = 100;
        }

        public override bool CheckActive()
        {
            if(_despawn < 300)
                return false;
            return true;
        }

        private void Retarget()
        {
            Player p = Main.player[NPC.target];
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest(true);
            }
            NPC.netUpdate = true;
        }

        private void DespawnCheck()
        {
            if (!Main.player[NPC.target].active || Main.player[NPC.target].dead)
            {
                NPC.TargetClosest(true);
                if (!Main.player[NPC.target].active || Main.player[NPC.target].dead)
                {
                    if (_despawn == 0)
                        _despawn++;
                }
                else
                    _despawn = 0;
            }
            if (_despawn >= 1)
            {
                _despawn++;
                NPC.noTileCollide = true;
                NPC.velocity.Y = 8f;
                if (_despawn >= 300)
                    NPC.active = false;
            }
        }

        public override void AI()
        {
            bitherial = true;
            NPC.spriteDirection = 0;

            Retarget();
            DespawnCheck();
            
            Vector2 delta = Main.player[NPC.target].Center - NPC.Center;
            float magnitude = (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y);

            if(_baseDamage == 0)
                _baseDamage = NPC.damage;
            //Checking which direction to move when spawned
            if (dir == 0)
            {
                if (delta.X < 0) dir = 1;
                else dir = -1;
            }

            //Horizontal Movement
            NPC.velocity.X = accel;
            if (dir == 1)
            {
                if (accel < maxAccel / 2)
                {
                    accel += .2f;
                }
                else
                {
                    if (boosted == false) //Play boosted sound effect
                    {
                        SoundEngine.PlaySound(new SoundStyle("Laugicality/Sounds/train_whistle"), NPC.position);
                        boosted = true;
                    }
                    accel = maxAccel;
                }
                if (delta.X < -range)
                {
                    boosted = false;
                    dir = -1;
                }
            }
            if (dir == -1)
            {
                if (accel > maxAccel / -2)
                {
                    accel -= .2f;
                }
                else
                {
                    if (boosted == false) //Play boosted sound effect
                    {
                        SoundEngine.PlaySound(new SoundStyle("Laugicality/Sounds/train_whistle"), NPC.position);
                        boosted = true;
                    }
                    accel = -maxAccel;
                }
                if (delta.X > range)
                {
                    boosted = false;
                    dir = 1;
                }
            }

            //Vertical Movement
            NPC.velocity.Y = vaccel;
            if (boosted == false)
            {
                if (Math.Abs(delta.Y) > 40)
                {
                    if (delta.Y > 40)
                    {
                        if (vaccel < maxVaccel) vaccel += .5f;
                    }
                    if (delta.Y < -40)
                    {
                        if (vaccel < maxVaccel) vaccel -= .5f;
                    }
                }
                else
                {
                    if (Math.Abs(vaccel) > .01f) vaccel *= .5f;
                    else vaccel = 0f;
                }
            }
            else vaccel = 0;

            //Attacking

            if (boosted)
            {
                delay += 1;
            }
            if (delay >= maxDelay && Main.netMode != 1)
            {

                if (delta.Y < 0)
                {
                    SoundEngine.PlaySound(SoundID.Item34, NPC.position);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 312, NPC.position.Y + 60, 0, -8, ModContent.ProjectileType<GasBallUp>(), NPC.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 522, NPC.position.Y + 60, 0, -8, ModContent.ProjectileType<GasBallUp>(), NPC.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 732, NPC.position.Y + 60, 0, -8, ModContent.ProjectileType<GasBallUp>(), NPC.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 942, NPC.position.Y + 60, 0, -8, ModContent.ProjectileType<GasBallUp>(), NPC.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 1156, NPC.position.Y + 60, 0, -8, ModContent.ProjectileType<GasBallUp>(), NPC.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 1372, NPC.position.Y + 60, 0, -8, ModContent.ProjectileType<GasBallUp>(), NPC.damage / 3, 3f, Main.myPlayer);
                }
                else
                {
                    //Projectile.NewProjectile(npc.position.X + 312, npc.position.Y + 60, 0, 8, ModContent.ProjectileType<Coginator>(), npc.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 522, NPC.position.Y + 60, 0, 8, ModContent.ProjectileType<SteamyShadow>(), NPC.damage / 3, 3f, Main.myPlayer);
                    //Projectile.NewProjectile(npc.position.X + 732, npc.position.Y + 60, 0, 8, ModContent.ProjectileType<Coginatore>(), npc.damage / 3, 3f, Main.myPlayer);
                    //Projectile.NewProjectile(npc.position.X + 942, npc.position.Y + 60, 0, 8, ModContent.ProjectileType<Coginator>(), npc.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 1156, NPC.position.Y + 60, 0, 8, ModContent.ProjectileType<SteamyShadow>(), NPC.damage / 3, 3f, Main.myPlayer);
                    //Projectile.NewProjectile(npc.position.X + 1372, npc.position.Y + 60, 0, 8, ModContent.ProjectileType<Coginator>(), npc.damage / 3, 3f, Main.myPlayer);
                }
                if (phase != _phase_Normaldrive)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 1572, NPC.position.Y + 60, 0, -8, ModContent.ProjectileType<Coginator>(), NPC.damage / 3, 3f, Main.myPlayer);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.position.X + 102, NPC.position.Y + 60, 0, -8, ModContent.ProjectileType<Coginator>(), NPC.damage / 3, 3f, Main.myPlayer);
                }
                delay = 0;

            }

            string SteamTrainSay = this.GetLocalization("Chat.SteamTrainSay").Value;
            string SteamTrainSay2 = this.GetLocalization("Chat.SteamTrainSay2").Value;
            string SteamTrainSay3 = this.GetLocalization("Chat.SteamTrainSay3").Value;
            string SteamTrainSay4 = this.GetLocalization("Chat.SteamTrainSay4").Value;

            //Health Phases
            if (NPC.life < NPC.lifeMax * .67 && phase == _phase_Normaldrive)
            {
                phase = _phase_Superdrive;
                Main.NewText(SteamTrainSay, 150, 0, 0);
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
            }

            if (NPC.life < NPC.lifeMax * .33 && phase == _phase_Superdrive)
            {
                phase = _phase_Hyperdrive;
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                Main.NewText(SteamTrainSay2, 200, 0, 0);
            }
            if (NPC.life < NPC.lifeMax * .10 && phase == _phase_Hyperdrive && Main.expertMode)
            {
                phase = _phase_Warpdrive;
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                Main.NewText(SteamTrainSay3, 250, 0, 0);
                NPC.life = (int)(NPC.lifeMax * .15);
            }
            if (NPC.life < NPC.lifeMax * .10 && phase == _phase_Warpdrive && Main.expertMode && LaugicalityWorld.downedEtheria)
            {
                phase = _phase_Choochoo;
                SoundEngine.PlaySound(SoundID.Roar, NPC.position);
                Main.NewText(SteamTrainSay4, 255, 0, 50);
                NPC.life = (int)(NPC.lifeMax * .33);
            }
            HealthEffects();
        }

        private void HealthEffects()
        {
            //Phase Stat Changing
            if (phase == _phase_Superdrive)
            {
                range = 1800;
                maxAccel = 26f;
                maxVaccel = 26f;
                maxDelay = 50;
                NPC.defense = 25;
                NPC.damage = _baseDamage + 20;
            }

            if (phase == _phase_Hyperdrive)
            {
                range = 1400;
                maxAccel = 32f;
                maxVaccel = 32f;
                maxDelay = 40;
                NPC.damage = _baseDamage + 30;
            }
            if (phase == _phase_Warpdrive)
            {
                range = 1000;
                maxAccel = 38f;
                maxVaccel = 38f;
                maxDelay = 30;
                NPC.damage = _baseDamage + 40;
            }
            if (phase == _phase_Choochoo)
            {
                range = 600;
                maxAccel = 48f;
                maxVaccel = 48f;
                maxDelay = 24;
                NPC.damage = _baseDamage + 60;
                Main.player[NPC.target].AddBuff(ModContent.BuffType<WingClip>(), 2, true);
            }
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
            if (plays == 0)
                plays = 1;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get();
            LaugicalityWorld.downedSteamTrain = true;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            var _Etheria = new LeadingConditionRule(new IDRNC(IDRNC.BossType.Etheria, true));

            _Etheria.OnSuccess(ItemDropRule.Common(ModContent.ItemType<EtherialTank>()));
            npcLoot.Add(_Etheria);

            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SteamBar>(), 1, 15, 30));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulOfWrought>(), 1, 20, 40));
            npcLoot.Add(ItemDropRule.ByCondition(new Conditions.IsExpert(), ModContent.ItemType<SteamTrainTreasureBag>(), 1));
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = 499;
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
