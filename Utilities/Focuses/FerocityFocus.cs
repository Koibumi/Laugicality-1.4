using Laugicality.Content.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using Laugicality.Utilities;
using Terraria.Localization;

namespace Laugicality.Utilities.Focuses
{
    public sealed class FerocityFocus : Focus
    {
        public FerocityFocus() : base(LaugicalityPlayer.FOCUS_NAME_FEROCITY, Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.Ferocity"), Color.Red, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedKingSlime", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedKingSlime")) { OverrideColor = new Color(0x2B, 0x9D, 0xE9) }), // Attacks inflict 'Slimed'
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedEyeOfCthulhu", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedEyeOfCthulhu")) { OverrideColor = new Color(0xB0, 0x3A, 0x2E) }), // +5% Damage at Night
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedDuneSharkron", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DuneSharkron")) { OverrideColor = new Color(0xF4, 0xE6, 0x92) }), // Increased damage the lower your life is
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedWorldEvilBoss", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedWorldEvilBoss")) { OverrideColor = new Color(0x88, 0x4E, 0xA0)}), // Gain 'Blood Rage' when struck, increasing damage for a time
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedHypothema", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedHypothema")) { OverrideColor = new Color(0x98, 0xE1, 0xEA) }), // Attacks inflict 'Frostburn'
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedQueenBee", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedQueenBee")) { OverrideColor = new Color(0xF3, 0x9C, 0x12)}), // Attacks inflict 'Poison', Thorns effect
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedRagnar", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedRagnar"))  { OverrideColor = new Color(0xED, 0x4B, 0x23) }), // Increased damage for a time after submerging in Lava
            new FocusEffect(p => NPC.downedBoss3, DownedSkeletronEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedSkeletron", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedSkeletron"))  { OverrideColor = new Color(0x83, 0x91, 0x92) }), // +8% Crit Chance
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedAnDio", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedAnDio")) { OverrideColor = new Color(0x42, 0x86, 0xF4) }), // Increased damage while Time is stopped
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedWallOfFleshEffect", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedWallOfFlesh")) { OverrideColor = new Color(0xAC, 0x39, 0x5A) }), // +8% Damage. Attacks inflict 'On Fire'
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedTwinsEffect", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedTwins")) { OverrideColor = new Color(0x2B, 0xD3, 0x4D) }), // Attacks inflict 'Cursed Flame'
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedDestroyerEffect", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedDestroyer")) { OverrideColor = new Color(0xDF, 0x0A, 0x0A) }), // Enemies that collide with you take 200% of the damage dealt to you
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedSkeletronPrimeEffect", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedSkeletronPrime")) { OverrideColor = new Color(0xAA, 0xAA, 0xAA) }), // Half of your global damage modifier is applied twice
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedAnnihilator", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedAnnihilator")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Pressing the Ability Key makes you deal 25% more damage and take 80% more damage. Can be stacked up to 2 times, then resets to 0.
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedSlybertron", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedSlybertron")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // +10% Damage when you have Potion Sickness
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedSteamTrain", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedSteamTrain")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // The faster you move, the higher your damage
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedPlantera", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedPlantera")) { OverrideColor = new Color(0x81, 0xD8, 0x79) }), // Attacks inflict 'Jungle Plague'
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedGolem", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedGolem")) { OverrideColor = new Color(0xCC, 0x88, 0x37) }), // The longer you stand still without moving while a boss is alive, the higher your damage.
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedDukeFishron", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedDukeFishron")) { OverrideColor = new Color(0x37, 0xC4, 0xCC) }), // +10% Damage when in liquid
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedEtheria", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedEtheria")) { OverrideColor = new Color(0x85, 0xCB, 0xF7) }), // +20% Damage in the Etherial
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "FerocityFocusDownedMoonLord",  Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.DownedMoonLord")) { OverrideColor = new Color(0x37, 0xCC, 0x8B) }), // Pressing the Ability key now makes you deal 100% more damage and makes you take 200% more damage per stack
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "FerocityFocusCurse1", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.Curse1")) { OverrideColor = Color.Red }), // -5% Damage
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "FerocityFocusCurse2", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.Curse2")) { OverrideColor = Color.Red }), // Your critical strike chance is halved
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "FerocityFocusCurse3", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.Curse3")) { OverrideColor = Color.Red }), // -20% Damage when above 50% Life
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "FerocityFocusCurse4", Language.GetTextValue("Mods.Laugicality.Focus.Ferocity.Curse4")) { OverrideColor = Color.Red }), // You cannot inflict special debuffs
        })
        {

        }

        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Slimey = true;
        }

        private static void DownedEyeOfCthulhuEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Main.dayTime)
                laugicalityPlayer.DamageBoost(.05f);
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DamageBoost(.2f * (1 - ((float)laugicalityPlayer.Player.statLife / (float)laugicalityPlayer.Player.statLifeMax2)));
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.BloodRage = true;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Frost = true;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Poison = true;
            laugicalityPlayer.Player.thorns += .33f;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.lavaWet)
                laugicalityPlayer.Player.AddBuff(ModContent.BuffType<LavaDamageBuff>(), 15 * 60);
        }

        private static void DownedSkeletronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            CritBoost(laugicalityPlayer, 8);
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(Laugicality.zaWarudo > 0)
                laugicalityPlayer.DamageBoost(.15f);
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.GetDamage(DamageClass.Generic) += .08f;
            laugicalityPlayer.Obsidium = true;
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CursedFlame = true;
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.thorns += 2f;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DamageBoost((laugicalityPlayer.GetGlobalDamage() - 1) / 2);
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (Laugicality.soulStoneAbility.JustPressed)
            {
                laugicalityPlayer.AbilityCount++;
                if (laugicalityPlayer.AbilityCount > 2)
                    laugicalityPlayer.AbilityCount = 0;
                Main.NewText("You have currently stacked the ability " + laugicalityPlayer.AbilityCount.ToString() + " times.", 225, 225, 225);
            }
            if(laugicalityPlayer.AbilityCount > 0)
            {
                if (NPC.downedMoonlord)
                {
                    laugicalityPlayer.DamageBoost(1f * laugicalityPlayer.AbilityCount);
                    laugicalityPlayer.Player.endurance -= 2f * laugicalityPlayer.AbilityCount;
                }
                else
                {
                    laugicalityPlayer.DamageBoost(.25f * laugicalityPlayer.AbilityCount);
                    laugicalityPlayer.Player.endurance -= .8f * laugicalityPlayer.AbilityCount;
                }
            }
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.potionDelay > 0)
                laugicalityPlayer.DamageBoost(.1f);
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            float moveSpeed = 0;
            moveSpeed = (float)Math.Abs(laugicalityPlayer.Player.velocity.X) / 50f;
            if (moveSpeed > .25f)
                moveSpeed = .25f;
            laugicalityPlayer.Player.GetDamage(DamageClass.Generic) += moveSpeed;
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.JunglePlague = true;
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            bool bossActive = false;
            foreach (NPC npc in Main.npc)
            {
                if (npc.boss)
                    bossActive = true;
            }
            if(!bossActive || laugicalityPlayer.Player.velocity.X != 0 || laugicalityPlayer.Player.velocity.Y != 0)
            {
                laugicalityPlayer.GolemBoost = 0;
            }
            else
            {
                if (laugicalityPlayer.GolemBoost < .5f)
                    laugicalityPlayer.GolemBoost += .002f;
            }
            laugicalityPlayer.Player.GetDamage(DamageClass.Generic) += laugicalityPlayer.GolemBoost;
        }

        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.wet || laugicalityPlayer.Player.honeyWet || laugicalityPlayer.Player.lavaWet)
                laugicalityPlayer.DamageBoost(.1f);
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (LaugicalityWorld.downedEtheria || laugicalityPlayer.Etherable > 0)
                laugicalityPlayer.DamageBoost(.2f);
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!LaugicalityWorld.downedAnnihilator)
                DownedAnnihilatorEffect(laugicalityPlayer, hideAccessory);
        }



        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DamageBoost(-.05f);
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.GetCritChance(DamageClass.Melee) /= 2;
            laugicalityPlayer.Player.GetCritChance(DamageClass.Magic) /= 2;
            laugicalityPlayer.Player.GetCritChance(DamageClass.Ranged) /= 2;
            laugicalityPlayer.Player.GetCritChance(DamageClass.Throwing) /= 2;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(laugicalityPlayer.Player.statLife > laugicalityPlayer.Player.statLifeMax2 / 2)
                laugicalityPlayer.DamageBoost(-.2f);
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.NoDebuffDamage = true;
        }

        private static void CritBoost(LaugicalityPlayer laugicalityPlayer, int Boost)
        {
            laugicalityPlayer.Player.GetCritChance(DamageClass.Melee) += Boost;
            laugicalityPlayer.Player.GetCritChance(DamageClass.Magic) += Boost;
            laugicalityPlayer.Player.GetCritChance(DamageClass.Ranged) += Boost;
            laugicalityPlayer.Player.GetCritChance(DamageClass.Throwing) += Boost;
        }
    }
}
