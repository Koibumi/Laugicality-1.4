using Laugicality.Content.Buffs;
//using Laugicality.NPCs.Etherial.Enemies;
using Laugicality.Content.SoulStones;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using Terraria.Localization;

namespace Laugicality.Utilities.Focuses
{
    public sealed class UtilityFocus : Focus
    {
        public UtilityFocus() : base(LaugicalityPlayer.FOCUS_NAME_UTILITY, Language.GetTextValue("Mods.Laugicality.Focus.Utility.Utility"), Color.Purple, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedKingSlime", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedKingSlime")) { OverrideColor = new Color(0x2B, 0x9D, 0xE9) }), // You are immune to slimes
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedEyeOfCthulhu", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedEyeOfCthulhu")) { OverrideColor = new Color(0xB0, 0x3A, 0x2E) }), // Hunter & Shine potion effects
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedDuneSharkron",  Language.GetTextValue("Mods.Laugicality.Focus.Utility.DuneSharkron")) { OverrideColor = new Color(0xF4, 0xE6, 0x92) }), // Immune to fall damage
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedWorldEvilBoss", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedWorldEvilBoss")) { OverrideColor = new Color(0x88, 0x4E, 0xA0)}),  // Immune to Confusion, Cursed Flames. Immune to Contact Damage once every 2 minutes
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedHypothema", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedHypothema")) { OverrideColor = new Color(0x98, 0xE1, 0xEA) }), // Immune to cold debuffs (including 'Frostburn')
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedQueenBee", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedQueenBee")) { OverrideColor = new Color(0xF3, 0x9C, 0x12)}), // Super Bees, Immune to Poison
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedRagnar", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedRagnar")) { OverrideColor = new Color(0xED, 0x4B, 0x23) }), // Immunity to Lava, 'On Fire', and 'Burning'. Wrath potions are 50% more effective
            new FocusEffect(p => NPC.downedBoss3, DownedSkeletronEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedSkeletron", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedSkeletron")) { OverrideColor = new Color(0x83, 0x91, 0x92) }), // Immune to Cursed & Darkness. Night Owl & Dangersense potion effects
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedAnDio", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedAnDio")) { OverrideColor = new Color(0x42, 0x86, 0xF4) }), // Decreased cooldown of Time Stop. You are Immune to Time Stop
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedWallOfFleshEffect", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedWallOfFlesh")) { OverrideColor = new Color(0xAC, 0x39, 0x5A) }), // Spelunker Effect, Ironskin and Regen Potions are 50% stronger, +15% Mining Speed
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedTwinsEffect", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedTwins")) { OverrideColor = new Color(0x2B, 0xD3, 0x4D) }), // Increased Flight Time if worn under wings
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedDestroyerEffect", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedDestroyer")) { OverrideColor = new Color(0xDF, 0x0A, 0x0A) }), // Immunity to Knockback
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedSkeletronPrimeEffect",  Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedSkeletronPrime")) { OverrideColor = new Color(0xAA, 0xAA, 0xAA) }), // Innate Ankh Charm
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedAnnihilator", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedAnnihilator")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Pressing the Ability Key destroys hostile projectiles and gives you 4 seconds of immunity. 90 second cooldown
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedSlybertron", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedSlybertron")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Taking a healing potion gives less Potion Sickness
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedSteamTrain", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedSteamTrain")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // You are immune to 'Steamy'. Attacks inflict 'Steamy'
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedPlantera",  Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedPlantera")) { OverrideColor = new Color(0x81, 0xD8, 0x79) }), // You are immune while grappled to a tile, but also True Cursed
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedGolem", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedGolem")) { OverrideColor = new Color(0xCC, 0x88, 0x37) }), // Increase to all stats during the Daytime
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedDukeFishron", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedDukeFishron")) { OverrideColor = new Color(0x37, 0xC4, 0xCC) }), // Free movement in liquids. Increased Mobility while in liquids
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedEtheria", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedEtheria")) { OverrideColor = new Color(0x85, 0xCB, 0xF7) }), // Immune to 'Frostbite' and Etherial Spirits
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "UtilityFocusDownedMoonLord", Language.GetTextValue("Mods.Laugicality.Focus.Utility.DownedMoonLord")) { OverrideColor = new Color(0x37, 0xCC, 0x8B) }), // You cannot lose life to life draining debuffs
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "UtilityFocusCurse1", Language.GetTextValue("Mods.Laugicality.Focus.Utility.Curse1")) { OverrideColor = Color.Purple }), // +5% Damage Taken
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "UtilityFocusCurse2", Language.GetTextValue("Mods.Laugicality.Focus.Utility.Curse2")) { OverrideColor = Color.Purple }), // You cannot be immune to knockback
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "UtilityFocusCurse3", Language.GetTextValue("Mods.Laugicality.Focus.Utility.Curse3")) { OverrideColor = Color.Purple }), // Debuffs deal double damage when you are above 50% life
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "UtilityFocusCurse4", Language.GetTextValue("Mods.Laugicality.Focus.Utility.Curse4")) { OverrideColor = Color.Purple }), // You are immune to most positive buffs
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
            laugicalityPlayer.Player.detectCreature = true;
            Lighting.AddLight((int)(laugicalityPlayer.Player.position.X + (float)(laugicalityPlayer.Player.width / 2)) / 16, (int)(laugicalityPlayer.Player.position.Y + (float)(laugicalityPlayer.Player.height / 2)) / 16, 0.8f, 0.95f, 1f);
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.noFallDmg = true;
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.buffImmune[BuffID.Confused] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.CursedInferno] = true;

            laugicalityPlayer.EvilBossEffect = true;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.buffImmune[BuffID.Frostburn] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Frozen] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Chilled] = true;
            laugicalityPlayer.Player.resistCold = true;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.strongBees = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Poisoned] = true;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.lavaImmune = true;
            laugicalityPlayer.Player.fireWalk = true;
            laugicalityPlayer.Player.buffImmune[BuffID.OnFire] = true;

            if (laugicalityPlayer.Player.HasBuff(BuffID.Wrath))
                laugicalityPlayer.DamageBoost(.05f);
        }

        private static void DownedSkeletronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.buffImmune[BuffID.Cursed] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Darkness] = true;
            laugicalityPlayer.Player.nightVision = true;
            laugicalityPlayer.Player.dangerSense = true;
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.zImmune = true;
            laugicalityPlayer.zCoolDown -= 6 * 60;
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.findTreasure = true;
            laugicalityPlayer.Player.pickSpeed -= 0.15f;
            if (laugicalityPlayer.Player.HasBuff(BuffID.Ironskin))
                laugicalityPlayer.Player.statDefense += 4;
            if (laugicalityPlayer.Player.HasBuff(BuffID.Regeneration))
                laugicalityPlayer.Player.lifeRegen += 2;
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.wingTimeMax += 2 * 60;
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.noKnockback = true;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.buffImmune[33] = true;
            laugicalityPlayer.Player.buffImmune[36] = true;
            laugicalityPlayer.Player.buffImmune[30] = true;
            laugicalityPlayer.Player.buffImmune[20] = true;
            laugicalityPlayer.Player.buffImmune[32] = true;
            laugicalityPlayer.Player.buffImmune[31] = true;
            laugicalityPlayer.Player.buffImmune[35] = true;
            laugicalityPlayer.Player.buffImmune[23] = true;
            laugicalityPlayer.Player.buffImmune[22] = true;
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.Player.HasBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            foreach(Projectile projectile in Main.projectile)
            {
                laugicalityPlayer.Player.immune = true;
                laugicalityPlayer.Player.immuneTime = 5 * 60;
                if (projectile.hostile && projectile.damage > 0 && projectile.timeLeft > 10)
                    projectile.Kill();
            }

            laugicalityPlayer.Player.AddBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>(), 90 * 60);
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.potionDelayTime -= 15 * 60;
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<Steamy>()] = true;
            laugicalityPlayer.Steamified = true;
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.grapCount > 0)
            {
                laugicalityPlayer.Player.immune = true;
                laugicalityPlayer.Player.immuneTime = 2;
                laugicalityPlayer.Player.AddBuff(ModContent.BuffType<TrueCurse>(), 2);
            }
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(Main.dayTime)
            {
                laugicalityPlayer.Player.statDefense += 5;
                laugicalityPlayer.DamageBoost(.05f);
                laugicalityPlayer.Player.lifeRegen += 5;
                laugicalityPlayer.Player.endurance += .05f;
            }
        }

        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.ignoreWater = true;
            if (laugicalityPlayer.Player.wet || laugicalityPlayer.Player.honeyWet || laugicalityPlayer.Player.lavaWet)
            {
                laugicalityPlayer.Player.moveSpeed += .25f;
                laugicalityPlayer.Player.maxRunSpeed *= 1.25f;
            }
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<Frostbite>()] = true;
            //laugicalityPlayer.Player.npcTypeNoAggro[ModContent.NPCType<EtherialSpirit>()] = true;
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MoonLordEffect = true;
        }


        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.endurance -= .05f;
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CancelNoKnockback = true;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.UtilityCurse3 = true;
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.buffImmune[BuffID.Ironskin] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Regeneration] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.ManaRegeneration] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.MagicPower] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Wrath] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Rage] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Endurance] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Titan] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Thorns] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Archery] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Calm] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Heartreach] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Lifeforce] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.ObsidianSkin] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Summoning] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Swiftness] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Warmth] = true;
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<DestructionBoost>()] = true;
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<IllusionBoost>()] = true;
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<ConjurationBoost>()] = true;
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<Albus>()] = true;
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<Aquos>()] = true;
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<Aura>()] = true;
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<Rubrum>()] = true;
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<Regis>()] = true;
            laugicalityPlayer.Player.buffImmune[ModContent.BuffType<Verdi>()] = true;
        }
    }
}
