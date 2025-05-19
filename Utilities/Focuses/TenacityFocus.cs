using Laugicality.Content.Buffs;
using Laugicality.Content.SoulStones;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using Terraria.Localization;

namespace Laugicality.Utilities.Focuses
{
    public sealed class TenacityFocus : Focus
    {
        public TenacityFocus() : base(LaugicalityPlayer.FOCUS_NAME_TENACITY, Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.Tenacity"), Color.Silver, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedKingSlime", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedKingSlime")) { OverrideColor = new Color(0x2B, 0x9D, 0xE9) }), // You are immune to slimes
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedEyeOfCthulhu", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedEyeOfCthulhu")) { OverrideColor = new Color(0xB0, 0x3A, 0x2E) }), // Movement speed increased for a time after taking damage
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedDuneSharkron", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedDuneSharkron")) { OverrideColor = new Color(0xF4, 0xE6, 0x92) }), // You are immune to fall damage
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedWorldEvilBoss", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedWorldEvilBoss")) { OverrideColor = new Color(0x88, 0x4E, 0xA0)}), // +5 Defense when below 50% Life
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedHypothema", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedHypothema")) { OverrideColor = new Color(0x98, 0xE1, 0xEA) }), // Increased defense when affected by a life draining debuff
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedQueenBee", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedQueenBee")) { OverrideColor = new Color(0xF3, 0x9C, 0x12)}), // Immune to 'Poison' and 'Venom'
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedRagnar", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedRagnar")) { OverrideColor = new Color(0xED, 0x4B, 0x23) }), // Increased Defense for a time after submerging in Lava
            new FocusEffect(p => NPC.downedBoss3, DownedSkeletronEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedSkeletron", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedSkeletron")) { OverrideColor = new Color(0x83, 0x91, 0x92) }), // +5 Defense at Night
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedAnDio", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedAnDio")) { OverrideColor = new Color(0x42, 0x86, 0xF4) }), // Don't take damage while Time is stopped
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedWallOfFleshEffect", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedWallOfFlesh")) { OverrideColor = new Color(0xAC, 0x39, 0x5A) }), // The longer you go without taking damage, the higher your defense
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedTwinsEffect", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedTwins")) { OverrideColor = new Color(0x2B, 0xD3, 0x4D) }), // +6 Defense when flying
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedDestroyerEffect", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedDestroyer")) { OverrideColor = new Color(0xDF, 0x0A, 0x0A) }), // Prevent a lethal hit of damage if it does over 50 damage once every 90 seconds
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedSkeletronPrimeEffect", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedSkeletronPrime")) { OverrideColor = new Color(0xAA, 0xAA, 0xAA) }), // Half of your global damage modifier is applied to your defense
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedAnnihilator", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedAnnihilator")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Pressing the Ability Key makes you invincible for 4 seconds. 60 Second Cooldown
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedSlybertron", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedSlybertron")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // +8 Defense when you have potion sickness
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedSteamTrain", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedSteamTrain")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Negate contact damage once every 90 seconds
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedPlantera", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedPlantera")) { OverrideColor = new Color(0x81, 0xD8, 0x79) }), // +8 Defense when you are grappling
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedGolem", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedGolem")) { OverrideColor = new Color(0xCC, 0x88, 0x37) }), // +15 Defense and immune to Knockback when standing still
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedDukeFishron", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedDukeFishron")) { OverrideColor = new Color(0x37, 0xC4, 0xCC) }), // Being in liquid greatly increases defense
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedEtheria", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedEtheria")) { OverrideColor = new Color(0x85, 0xCB, 0xF7) }), // Take 20% less damage in the Etherial
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "TenacityFocusDownedMoonLord", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.DownedMoonLord")) { OverrideColor = new Color(0x37, 0xCC, 0x8B) }), // Negate a hit of damage once every 30 seconds
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "TenacityFocusCurse1", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.Curse1")) { OverrideColor = Color.Silver }), // -5% Defense
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "TenacityFocusCurse2", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.Curse2")) { OverrideColor = Color.Silver }), // Taking damage makes you lose 10 defense for a time
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "TenacityFocusCurse3", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.Curse3")) { OverrideColor = Color.Silver }), // You take 15% more damage above 50% Life
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "TenacityFocusCurse4", Language.GetTextValue("Mods.Laugicality.Focus.Tenacity.Curse4")) { OverrideColor = Color.Silver }), // Your defense is halved.
        })
        {

        }

        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.npcTypeNoAggro[1] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[16] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[59] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[71] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[81] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[138] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[121] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[122] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[141] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[147] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[183] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[184] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[204] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[225] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[244] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[302] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[333] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[335] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[334] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[336] = true;
            laugicalityPlayer.Player.npcTypeNoAggro[537] = true;
        }

        private static void DownedEyeOfCthulhuEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.panic = true;
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.noFallDmg = true;
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if ((float)laugicalityPlayer.Player.statLife < (float)laugicalityPlayer.Player.statLifeMax2 / 2f)
                laugicalityPlayer.Player.statDefense += 5;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.HypothemaEffect = true;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            //laugicalityPlayer.QueenBeeEffect = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Poisoned] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Venom] = true;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.lavaWet)
                laugicalityPlayer.Player.AddBuff(ModContent.BuffType<LavaDefenseBuff>(), 60 * 15);
        }

        private static void DownedSkeletronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Main.dayTime)
                laugicalityPlayer.Player.statDefense += 5;
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Laugicality.zaWarudo > 0)
            {
                laugicalityPlayer.Player.immune = true;
                laugicalityPlayer.Player.immuneTime = 60;
            }
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(laugicalityPlayer.DefenseCounter < 250)
                laugicalityPlayer.DefenseCounter += 1 / 120f;
            laugicalityPlayer.Player.statDefense += (int)(laugicalityPlayer.DefenseCounter);
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.velocity.Y < 0)
                laugicalityPlayer.Player.statDefense += 6;
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DestroyerEffect = true;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            float globalDmg = laugicalityPlayer.Player.GetDamage(DamageClass.Generic).Additive - 1;
            int currentDefense = laugicalityPlayer.Player.statDefense.Positive; 
            int newDefense = currentDefense + (int)(currentDefense * (globalDmg / 2));
            laugicalityPlayer.Player.statDefense.AdditiveBonus += newDefense - currentDefense; 
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.Player.HasBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            laugicalityPlayer.Player.immune = true;
            laugicalityPlayer.Player.immuneTime += 4 * 60;

            laugicalityPlayer.Player.AddBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>(), 60 * 60);
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(laugicalityPlayer.Player.potionDelay > 0)
                laugicalityPlayer.Player.statDefense += 8;

        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SteamTrainEffect = true;
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.grapCount > 0)
                laugicalityPlayer.Player.statDefense += 8;
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.velocity.X == 0 && laugicalityPlayer.Player.velocity.Y == 0)
            {
                laugicalityPlayer.Player.statDefense += 15;
                laugicalityPlayer.Player.noKnockback = true;
            }
        }

        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.wet || laugicalityPlayer.Player.honeyWet || laugicalityPlayer.Player.lavaWet)
            {
                laugicalityPlayer.Player.statDefense += 20;
            }
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (LaugicalityWorld.downedEtheria || laugicalityPlayer.Etherable > 0)
                laugicalityPlayer.Player.endurance += .2f;
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MoonLordEffect = true;
        }

        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.statDefense.AdditiveBonus += (int)(laugicalityPlayer.Player.statDefense.Positive * -0.05f);
        }


        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.TenacityCurse2 = true;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.statLife > laugicalityPlayer.Player.statLifeMax2 / 2)
                laugicalityPlayer.Player.endurance *= .85f;
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.statDefense /= 2;
        }
    }
}
