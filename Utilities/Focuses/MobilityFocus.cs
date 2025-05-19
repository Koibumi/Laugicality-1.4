using Laugicality.Content.SoulStones;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using Terraria.Localization;

namespace Laugicality.Utilities.Focuses
{
    public sealed class MobilityFocus : Focus
    {
        public MobilityFocus() : base(LaugicalityPlayer.FOCUS_NAME_MOBILITY, Language.GetTextValue("Mods.Laugicality.Focus.Mobility.Mobility"), Color.Green, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedKingSlime", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedKingSlime")) { OverrideColor = new Color(0x2B, 0x9D, 0xE9) }), // Increased Jump Height
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedEyeOfCthulhu", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedEyeOfCthulhu")) { OverrideColor = new Color(0xB0, 0x3A, 0x2E) }), // Increased movement speed when below 50% life
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedDuneSharkron", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedDuneSharkron")) { OverrideColor = new Color(0xF4, 0xE6, 0x92) }), // Innate magic carpet effect
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedWorldEvilBoss", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedWorldEvilBoss")) { OverrideColor = new Color(0x88, 0x4E, 0xA0)}), // +10% Increased Movement Speed and Run Speed
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedHypothema", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedHypothema")) { OverrideColor = new Color(0x98, 0xE1, 0xEA) }), // Immunity to cold debuffs (including Chilled and Frostburn)
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedQueenBee", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedQueenBee")) { OverrideColor = new Color(0xF3, 0x9C, 0x12)}), // When not moving vertically, increased Run Speed
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedRagnar", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedRagnar")) { OverrideColor = new Color(0xED, 0x4B, 0x23) }), // Greatly increased Mobility while in the Obsidium, while in the Underworld, or while affected by a debuff
            new FocusEffect(p => NPC.downedBoss3, DownedSkeletronEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedSkeletron", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedSkeletron")) { OverrideColor = new Color(0x83, 0x91, 0x92) }), // Low chance to dodge an attack when hit
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedAnDio", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedAnDio")) { OverrideColor = new Color(0x42, 0x86, 0xF4) }), // Greatly increased Mobility while Time is stopped. You can move during Time Stop.
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedWallOfFleshEffect", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedWallOfFlesh")) { OverrideColor = new Color(0xAC, 0x39, 0x5A) }), // Pressing the Ability Key teleports you to the mouse. 15 second cooldown.
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedTwinsEffect", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedTwins")) { OverrideColor = new Color(0x2B, 0xD3, 0x4D) }), // Increased wing flight time if worn under wings
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedDestroyerEffect", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedDestroyer")) { OverrideColor = new Color(0xDF, 0x0A, 0x0A) }), // You are immune to Knockback
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedSkeletronPrimeEffect", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedSkeletronPrime")) { OverrideColor = new Color(0xAA, 0xAA, 0xAA) }), // Half of your global damage modifier is applied to your Run Speed
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedAnnihilator", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedAnnihilator")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Cooldown of the teleportation Ability reduced to 8 seconds. Become immune after teleporting
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedSlybertron", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedSlybertron")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Increased Jump Height and Wing acceleration when you have Potion Sickness
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedSteamTrain", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedSteamTrain")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // The faster you move, the higher your damage. +10% Max Run Speed.
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedPlantera", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedPlantera")) { OverrideColor = new Color(0x81, 0xD8, 0x79) }), // Large movement boost when under 50% life
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedGolem", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedGolem")) { OverrideColor = new Color(0xCC, 0x88, 0x37) }), // When standing still, charge up energy. Moving releases it in a burst of speed.
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedDukeFishron", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedDukeFishron")) { OverrideColor = new Color(0x37, 0xC4, 0xCC) }), // Free movement in liquids. Greatly increased Mobility while in liquids.
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedEtheria", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedEtheria")) { OverrideColor = new Color(0x85, 0xCB, 0xF7) }), // +20% Max Run Speed and Movement Speed while in the Etherial
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "MobilityFocusDownedMoonLord", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.DownedMoonLord")) { OverrideColor = new Color(0x37, 0xCC, 0x8B) }), // +50% Movement speed, +10% Max Run Speed. Chance to dodge attacks based on how fast you are moving
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "MobilityFocusCurse1", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.Curse1")) { OverrideColor = Color.Green }), // -5% Movement Speed & Max Run Speed
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "MobilityFocusCurse2", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.Curse2")) { OverrideColor = Color.Green }), // Taking damage slows you down for a time.
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "MobilityFocusCurse3", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.Curse3")) { OverrideColor = Color.Green }), // Reduced movement speed when above 50% Life
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "MobilityFocusCurse4", Language.GetTextValue("Mods.Laugicality.Focus.Mobility.Curse4")) { OverrideColor = Color.Green }), // You cannot fly
        })
        {

        }

        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.jumpSpeedBoost += 3;
        }

        private static void DownedEyeOfCthulhuEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.statLife < laugicalityPlayer.Player.statLifeMax2 / 2 + 1)
            {
                laugicalityPlayer.Player.moveSpeed += .25f;
                laugicalityPlayer.Player.maxRunSpeed += .25f;
                laugicalityPlayer.Player.accRunSpeed += .25f;
            }
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.carpet = true;
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.moveSpeed += .1f;
            laugicalityPlayer.Player.maxRunSpeed *= 1.1f;
            laugicalityPlayer.Player.accRunSpeed *= 1.1f;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.resistCold = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Frostburn] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Frozen] = true;
            laugicalityPlayer.Player.buffImmune[BuffID.Chilled] = true;
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.velocity.Y == 0)
            {
                laugicalityPlayer.Player.maxRunSpeed *= 1.2f;
                laugicalityPlayer.Player.accRunSpeed *= 1.2f;
            }
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(laugicalityPlayer.Player.ZoneUnderworldHeight || laugicalityPlayer.zoneObsidium || laugicalityPlayer.LosingLife)
            {
                laugicalityPlayer.Player.moveSpeed += .15f;
                laugicalityPlayer.Player.maxRunSpeed *= 1.15f;
                laugicalityPlayer.Player.accRunSpeed *= 1.15f;
            }
        }

        private static void DownedSkeletronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SkeletronEffect = true;
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.zMove = true;
            if(Laugicality.zaWarudo > 0)
            {
                laugicalityPlayer.Player.moveSpeed += 1;
                laugicalityPlayer.Player.maxRunSpeed *= 1.5f;
                laugicalityPlayer.Player.accRunSpeed *= 1.5f;
            }
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.Player.HasBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            laugicalityPlayer.Player.Center = Main.MouseWorld;
            if(LaugicalityWorld.downedAnnihilator)
            {
                laugicalityPlayer.Player.AddBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>(), 8 * 60);
                laugicalityPlayer.Player.immune = true;
                laugicalityPlayer.Player.immuneTime = 2 * 60;
            }
            else
                laugicalityPlayer.Player.AddBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>(), 15 * 60);
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
            float damageModifier = laugicalityPlayer.Player.GetDamage(DamageClass.Generic).Additive +
                                   laugicalityPlayer.Player.GetDamage(DamageClass.Generic).Multiplicative - 1;
            laugicalityPlayer.Player.maxRunSpeed *= (1 + damageModifier / 2);
            laugicalityPlayer.Player.moveSpeed *= (1 + damageModifier / 2);
            laugicalityPlayer.Player.accRunSpeed *= (1 + damageModifier / 2);
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            //Yeet
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.potionDelay > 0)
            {
                laugicalityPlayer.Player.jumpSpeedBoost += 6f;
            }
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.maxRunSpeed *= 1.1f;
            float moveSpeed = 0;
            moveSpeed = (float)Math.Abs(laugicalityPlayer.Player.velocity.X) / 50f;
            if (moveSpeed > .25f)
                moveSpeed = .25f;
            laugicalityPlayer.Player.GetDamage(DamageClass.Generic) += moveSpeed;
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.statLife < laugicalityPlayer.Player.statLifeMax2 / 2)
            {
                laugicalityPlayer.Player.moveSpeed += .25f;
                laugicalityPlayer.Player.maxRunSpeed *= 1.25f;
                laugicalityPlayer.Player.accRunSpeed *= 1.25f;
            }
        }

        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.velocity.X == 0 && laugicalityPlayer.Player.velocity.Y == 0)
                laugicalityPlayer.GolemBoost += .05f;
            else if(laugicalityPlayer.GolemBoost > 0)
            {
                laugicalityPlayer.Player.moveSpeed += laugicalityPlayer.GolemBoost;
                laugicalityPlayer.Player.maxRunSpeed += laugicalityPlayer.GolemBoost;
                laugicalityPlayer.Player.runAcceleration += laugicalityPlayer.GolemBoost;
                laugicalityPlayer.Player.jumpSpeedBoost += laugicalityPlayer.GolemBoost;
                laugicalityPlayer.GolemBoost -= .2f;
            }
            if (laugicalityPlayer.GolemBoost < 0)
                laugicalityPlayer.GolemBoost = 0;
            if (laugicalityPlayer.GolemBoost > 4)
                laugicalityPlayer.GolemBoost = 4;
        }

        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.ignoreWater = true;
            if(laugicalityPlayer.Player.wet || laugicalityPlayer.Player.honeyWet || laugicalityPlayer.Player.lavaWet)
            {
                laugicalityPlayer.Player.moveSpeed += .25f;
                laugicalityPlayer.Player.maxRunSpeed *= 1.25f;
            }
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (LaugicalityWorld.downedEtheria || laugicalityPlayer.Etherable > 0)
            {
                laugicalityPlayer.Player.moveSpeed += .2f;
                laugicalityPlayer.Player.maxRunSpeed *= 1.2f;
                laugicalityPlayer.Player.accRunSpeed *= 1.2f;
            }
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.moveSpeed += .5f;
            laugicalityPlayer.Player.maxRunSpeed *= 1.1f;
            laugicalityPlayer.Player.accRunSpeed *= 1.1f;
            laugicalityPlayer.MoonLordEffect = true;
        }

        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.moveSpeed *= .95f;
            laugicalityPlayer.Player.maxRunSpeed *= .95f;
            laugicalityPlayer.Player.accRunSpeed *= .95f;
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MobilityCurse2 = true;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (laugicalityPlayer.Player.statLife >= laugicalityPlayer.Player.statLifeMax2 / 2)
            {
                laugicalityPlayer.Player.moveSpeed *= .8f;
                laugicalityPlayer.Player.maxRunSpeed *= .8f;
            }
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.wingTimeMax = 1;
        }
    }
}
