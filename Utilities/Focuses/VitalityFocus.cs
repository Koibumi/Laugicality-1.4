using Laugicality.Content.Buffs;
using Laugicality.Content.SoulStones;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using System.Collections.Generic;
using Terraria.Localization;

namespace Laugicality.Utilities.Focuses
{
    public sealed class VitalityFocus : Focus, ILocalizedModType
    {
        public VitalityFocus() : base(LaugicalityPlayer.FOCUS_NAME_VITALITY, Language.GetTextValue("Mods.Laugicality.Focus.Vitality.Vitality"), Color.Gold, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect,  new TooltipLine(Laugicality.Instance, "VitalityFocusDownedKingSlime",  Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedKingSlime")) { OverrideColor = new Color(0x2B, 0x9D, 0xE9) }), // +4 Life Regen while Jumping
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedEyeOfCthulhu", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedEyeOfCthulhuEffect")) { OverrideColor = new Color(0xB0, 0x3A, 0x2E) }),  // +25 Max Life during the Night
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedDuneSharkron", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedDuneSharkron")) { OverrideColor = new Color(0xF4, 0xE6, 0x92) }), // +25 Max Life during the Day
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedWorldEvilBoss", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedWorldEvilBoss")) { OverrideColor = new Color(0x88, 0x4E, 0xA0)}), // If you are losing life, lose 2 less life (to a minimum of 1)
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedHypothema", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedHypothema")) { OverrideColor = new Color(0x98, 0xE1, 0xEA) }), // Increased defense when affected by a life draining debuff
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedQueenBee",  Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedQueenBee")) { OverrideColor = new Color(0xF3, 0x9C, 0x12)}), // Honey provides quadruple the normal regeneration
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedRagnar", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedRagnar")) { OverrideColor = new Color(0xED, 0x4B, 0x23) }), // Greatly increased Life Regeneration while submerged in Lava
            new FocusEffect(p => NPC.downedBoss3, (p, h) => p.Player.statLifeMax2 += p.Player.statDefense, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedSkeletronEffect", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedSkeletron")) { OverrideColor = new Color(0x83, 0x91, 0x92) }), // Your defense is added to your Max Life
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedAnDio", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedAnDio")) { OverrideColor = new Color(0x42, 0x86, 0xF4) }), // Greatly increased Life Regeneration while Time is Stopped
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedWallOfFleshEffect", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedWallOfFlesh")) { OverrideColor = new Color(0xAC, 0x39, 0x5A) }), // Pressing the Ability Key will heal you for 15% of your max life. 30 second cooldown.
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedTwinsEffect", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedTwins")) { OverrideColor = new Color(0x2B, 0xD3, 0x4D) }), // Increased life regen while flying
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedDestroyerEffect", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedDestroyer")) { OverrideColor = new Color(0xDF, 0x0A, 0x0A) }), // Prevent a lethal hit of damage if it does over 50 damage once every 90 seconds
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedSkeletronPrimeEffect",  Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedSkeletronPrime")) { OverrideColor = new Color(0xAA, 0xAA, 0xAA) }), // Half your global damage modifier is applied to your Max Life
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedAnnihilator",  Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedAnnihilator")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Ability cooldown reduced to 20 seconds. Attacks inflict 'Lovestruck'
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedSlybertron",  Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedSlybertron")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Increased life regen when you have Potion Sickness
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedSteamTrain",  Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedSteamTrain")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Taking damage when not at full health returns you to full health instead once every 150 seconds.
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedPlantera", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedPlantera")) { OverrideColor = new Color(0x81, 0xD8, 0x79) }), // Greatly increased life regen when grappled to a tile
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedGolem", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedGolem")) { OverrideColor = new Color(0xCC, 0x88, 0x37) }), // Greatly increased life regen while standing still
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedDukeFishron", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedDukeFishron")) { OverrideColor = new Color(0x37, 0xC4, 0xCC) }), // Being in liquid quadruples regeneration from Honey (again)
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedEtheria", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedEtheria")) { OverrideColor = new Color(0x85, 0xCB, 0xF7) }), //+20% Max Life while in the Etherial
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "VitalityFocusDownedMoonLord", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.DownedMoonLord")) { OverrideColor = new Color(0x37, 0xCC, 0x8B) }), // If you would die from taking damage, your Max Life is reduced by 50% and you return to your max life. If your Max Life is under 100, this effect does not trigger.
        },  new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "VitalityFocusCurse1", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.Curse1")) { OverrideColor = Color.Gold }), // -5% Max Life
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "VitalityFocusCurse2", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.Curse2")) { OverrideColor = Color.Gold }), // If you are losing life, lose an additional 2 life per second
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "VitalityFocusCurse3", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.Curse3")) { OverrideColor = Color.Gold }), // You cannot regen above 50% of your Max Life
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "VitalityFocusCurse4", Language.GetTextValue("Mods.Laugicality.Focus.Vitality.Curse4")) { OverrideColor = Color.Gold }), // You cannot boost your life total
        })
        {

        }
        
        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.velocity.Y != 0f)
                laugicalityPlayer.Player.lifeRegen += 4;
        }

        private static void DownedEyeOfCthulhuEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Main.dayTime)
                laugicalityPlayer.Player.statLifeMax2 += 25;
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Main.dayTime)
                laugicalityPlayer.Player.statLifeMax2 += 25;
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.EvilBossEffect = true;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.HypothemaEffect = true;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.honey)
                laugicalityPlayer.HoneyRegenMultiplier *= 4;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.lavaWet)
            {
                laugicalityPlayer.Player.lifeRegen += 4;
                laugicalityPlayer.Player.AddBuff(ModContent.BuffType<LavaRegen>(), 15 * 60);
            }
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Laugicality.zaWarudo > 0)
                laugicalityPlayer.Player.lifeRegen += 12;
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.Player.HasBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            laugicalityPlayer.Player.statLife += (int)(laugicalityPlayer.Player.statLifeMax2 * 0.15f);

            if (LaugicalityWorld.downedAnnihilator)
                laugicalityPlayer.Player.AddBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>(), 20 * 60);
            else
                laugicalityPlayer.Player.AddBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>(), 30 * 60);
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.velocity.Y < 0f)
                laugicalityPlayer.Player.lifeRegen += 8;
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DestroyerEffect = true;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            float globalDmg = laugicalityPlayer.Player.GetDamage(DamageClass.Generic).Additive + laugicalityPlayer.Player.GetDamage(DamageClass.Generic).Multiplicative - 1;
            laugicalityPlayer.Player.statLifeMax2 = (int)(laugicalityPlayer.Player.statLifeMax2 + laugicalityPlayer.Player.statLifeMax2 * globalDmg / 2);
        }


        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Lovestruck = true;
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.potionDelay > 0)
                laugicalityPlayer.Player.lifeRegen += 8;
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SteamTrainEffect = true;
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.grapCount > 0)
                laugicalityPlayer.Player.lifeRegen += 10;
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Math.Abs(laugicalityPlayer.Player.velocity.X) < .1 && Math.Abs(laugicalityPlayer.Player.velocity.Y) < .1)
                laugicalityPlayer.Player.lifeRegen += 15;
        }
        
        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.honey && (laugicalityPlayer.Player.wet || laugicalityPlayer.Player.honeyWet || laugicalityPlayer.Player.lavaWet))
                laugicalityPlayer.HoneyRegenMultiplier *= 4;
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (LaugicalityWorld.downedEtheria || laugicalityPlayer.Etherable > 0)
                laugicalityPlayer.Player.statLifeMax2 = (int)(1.2f * laugicalityPlayer.Player.statLifeMax2);
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MoonLordEffect = true;

            if(laugicalityPlayer.MoonLordLifeMult <= 1f)
                laugicalityPlayer.Player.statLifeMax2 = (int)(laugicalityPlayer.MoonLordLifeMult * laugicalityPlayer.Player.statLifeMax2);
        }

        private static void Yeet(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            //Lol
        }


        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.statLifeMax2 = ((int)Math.Round((double)laugicalityPlayer.Player.statLifeMax2 * .95 / 10)) * 10;
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.VitalityCurse2 = true;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.statLife >= laugicalityPlayer.Player.statLifeMax2 / 2)
                laugicalityPlayer.Player.lifeRegen = 0;
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.VitalityCurse4 = true;
        }
    }
}