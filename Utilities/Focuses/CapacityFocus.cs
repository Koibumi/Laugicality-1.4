using Laugicality.Content.SoulStones.Projectiles;
using Laugicality.Content.SoulStones;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using Laugicality.Utilities;
using Terraria.Localization;

namespace Laugicality.Utilities.Focuses
{
    public sealed class CapacityFocus : Focus
    {
        public CapacityFocus() : base(LaugicalityPlayer.FOCUS_NAME_CAPACITY, Language.GetTextValue("Mods.Laugicality.Focus.Capacity.Capacity"), Color.Blue, new FocusEffect[]
        {
            new FocusEffect(p => NPC.downedSlimeKing, DownedKingSlimeEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedKingSlime",  Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedKingSlime")) { OverrideColor = new Color(0x2B, 0x9D, 0xE9) }), // If you take contact damage while falling, stomp on the enemy that deals the damage
            new FocusEffect(p => NPC.downedBoss1, DownedEyeOfCthulhuEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedEyeOfCthulhu", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedEyeOfCthulhu")) { OverrideColor = new Color(0xB0, 0x3A, 0x2E) }), // Release Eyes when damaged
            new FocusEffect(p => LaugicalityWorld.downedDuneSharkron, DownedDuneSharkronEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedDuneSharkron", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedDuneSharkron")) { OverrideColor = new Color(0xF4, 0xE6, 0x92) }), // Launch enemies affected by gravity into the air on contact
            new FocusEffect(p => NPC.downedBoss2, DownedWorldEvilBossEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedWorldEvilBoss", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedWorldEvilBoss")) { OverrideColor = new Color(0x88, 0x4E, 0xA0)}), // "Gain 'Blood Rage' when struck, increasing damage for a time
            new FocusEffect(p => LaugicalityWorld.downedHypothema, DownedHypothemaEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedHypothema", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedHypothema")) { OverrideColor = new Color(0x98, 0xE1, 0xEA) }), // Frost Touch- Inflict Frostburn on enemies in a short radius around you
            new FocusEffect(p => NPC.downedQueenBee, DownedQueenBeeEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedQueenBee", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedQueenBee")) { OverrideColor = new Color(0xF3, 0x9C, 0x12)}), // Taking damage creates a ring of Thorns around you that damage and knock back enemies
            new FocusEffect(p => LaugicalityWorld.downedRagnar, DownedRagnarEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedRagnar", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedRagnar")) { OverrideColor = new Color(0xED, 0x4B, 0x23) }), // Reduced damage from lava. Increased Damage and Defense while On Fire
            new FocusEffect(p => NPC.downedBoss3, DownedSkeletronEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedSkeletron", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedSkeletron")) { OverrideColor = new Color(0x83, 0x91, 0x92) }), // Spawn a friendly Dungeon Guardian when you take contact damage
            new FocusEffect(p => LaugicalityWorld.downedAnDio, DownedAnDioEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedAnDio", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedAnDio")) { OverrideColor = new Color(0x42, 0x86, 0xF4) }), // Taking damage below 25% life automatically stops time. You are immune while time is stopped
            new FocusEffect(p => Main.hardMode, DownedWallOfFleshEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedWallOfFleshEffect", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedWallOfFlesh")) { OverrideColor = new Color(0xAC, 0x39, 0x5A) }), // Taking more than 1 damage is reduced to 1 damage once every 2 minutes
            new FocusEffect(p => NPC.downedMechBoss2, DownedTwinsEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedTwinsEffect", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedTwins")) { OverrideColor = new Color(0x2B, 0xD3, 0x4D) }), // Taking damage creates a Shadow Double that follows you and deals damage to enemies
            new FocusEffect(p => NPC.downedMechBoss1, DownedDestroyerEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedDestroyerEffect", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedDestroyer")) { OverrideColor = new Color(0xDF, 0x0A, 0x0A) }), // Taking damage when below 66% life spawns a friendly Probe
            new FocusEffect(p => NPC.downedMechBoss3, DownedSkeletronPrimeEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedSkeletronPrimeEffect", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedSkeletronPrime")) { OverrideColor = new Color(0xAA, 0xAA, 0xAA) }), // Call a Dungeon Guardian Prime to fight for you when below 50% life
            new FocusEffect(p => LaugicalityWorld.downedAnnihilator, DownedAnnihilatorEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedAnnihilator", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedAnnihilator")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Pressing the Ability Key makes you take 1 damage. 5 second cooldown
            new FocusEffect(p => LaugicalityWorld.downedSlybertron, DownedSlybertronEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedSlybertron", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedSlybertron")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Have an Electrosphere Aura around you which deals damage to enemies in a short range while you have Potion Sickness
            new FocusEffect(p => LaugicalityWorld.downedSteamTrain, DownedSteamTrainEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedSteamTrain", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedSteamTrain")) { OverrideColor = new Color(0xF9, 0xEB, 0x90) }), // Deal more damage when Immune. Immune time increased
            new FocusEffect(p => NPC.downedPlantBoss, DownedPlanteraEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedPlantera", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedPlantera")) { OverrideColor = new Color(0x81, 0xD8, 0x79) }), // Innate Spore Sack
            new FocusEffect(p => NPC.downedGolemBoss, DownedGolemEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedGolem", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedGolem")) { OverrideColor = new Color(0xCC, 0x88, 0x37) }), // Spawn a Golem Head that shoots lasers at nearby enemies when below 50% life
            new FocusEffect(p => NPC.downedFishron, DownedDukeFishronEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedDukeFishron", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedDukeFishron")) { OverrideColor = new Color(0x37, 0xC4, 0xCC) }), // Unleash the Sharks upon taking damage
            new FocusEffect(p => LaugicalityWorld.downedEtheria || LaugicalityWorld.downedTrueEtheria, DownedEtheriaEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedEtheria", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedEtheria")) { OverrideColor = new Color(0x85, 0xCB, 0xF7) }), // 'Etherial Rage'- After taking damage, gain +20 Defense and +20% Damage for a time
            new FocusEffect(p => NPC.downedMoonlord, DownedMoonLordEffect, new TooltipLine(Laugicality.Instance, "CapacityFocusDownedMoonLord", Language.GetTextValue("Mods.Laugicality.Focus.Capacity.DownedMoonLord")) { OverrideColor = new Color(0x37, 0xCC, 0x8B) }), // Immune time after taking damage doubled. 20% Damage reduction. Spawn a True Eye of Cthulhu when below 50% Life
        }, new FocusEffect[]
        {
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect1, new TooltipLine(Laugicality.Instance, "CapacityFocusCurse1",  Language.GetTextValue("Mods.Laugicality.Focus.Capacity.Curse1")) { OverrideColor = Color.Blue }), // Take 5 additional damage each time you are damaged
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect2, new TooltipLine(Laugicality.Instance, "CapacityFocusCurse2",  Language.GetTextValue("Mods.Laugicality.Focus.Capacity.Curse2")) { OverrideColor = Color.Blue }), // Taking damage reduces your defense for a time
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect3, new TooltipLine(Laugicality.Instance, "CapacityFocusCurse3",  Language.GetTextValue("Mods.Laugicality.Focus.Capacity.Curse3")) { OverrideColor = Color.Blue }), // Take 50% more collision damage above 50% Life
            new FocusEffect(p => LaugicalityWorld.GetCurseCount() >= 1, CurseEffect4, new TooltipLine(Laugicality.Instance, "CapacityFocusCurse4",  Language.GetTextValue("Mods.Laugicality.Focus.Capacity.Curse4")) { OverrideColor = Color.Blue }), // Your immune time is halved
        })
        {

        }

        private static void DownedKingSlimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.KingSlimeStomp = true;
        }

        private static void DownedEyeOfCthulhuEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Eyes = true;
        }

        private static void DownedDuneSharkronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SharkronEffect = true;
        }

        private static void DownedWorldEvilBossEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.BloodRage = true;
        }

        private static void DownedHypothemaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.HypothemaEffect = true;
            foreach(NPC npc in Main.npc)
            {
                float range = 48;
                if (npc.active && !npc.friendly && (npc.damage > 0 || npc.type == NPCID.TargetDummy) && !npc.dontTakeDamage && !npc.buffImmune[BuffID.Frostburn] && Vector2.Distance(laugicalityPlayer.Player.Center, npc.Center) <= range)
                {
                    if (npc.FindBuffIndex(BuffID.Frostburn) == -1)
                    {
                        npc.AddBuff(BuffID.Frostburn, 2 * 60, false);
                    }
                }
            }
        }

        private static void DownedQueenBeeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.QueenBeeEffect = true;
        }

        private static void DownedRagnarEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.Player.lavaRose = true;
            if(laugicalityPlayer.Player.onFire)
            {
                laugicalityPlayer.DamageBoost(.25f);
                laugicalityPlayer.Player.statDefense += 15;
            }
        }

        private static void DownedSkeletronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SkeletronEffect = true;
        }

        private static void DownedAnDioEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.AnDioCapacityEffect = true;
            if(Laugicality.zaWarudo > 0)
            {
                laugicalityPlayer.Player.immune = true;
                laugicalityPlayer.Player.immuneTime = 60;
            }
        }

        private static void DownedWallOfFleshEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.WallOfFleshEffect = true;
        }

        private static void DownedTwinsEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.TwinsEffect = true;
        }

        private static void DownedDestroyerEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.DestroyerCapacityEffect = true;
        }

        private static void DownedSkeletronPrimeEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SkeletronPrimeEffect = true;
        }

        private static void DownedAnnihilatorEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if (!Laugicality.soulStoneAbility.JustPressed || laugicalityPlayer.Player.HasBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>())) return;

            laugicalityPlayer.Player.Hurt(PlayerDeathReason.ByOther(2), 1, 0);

            laugicalityPlayer.Player.AddBuff(ModContent.BuffType<SoulStoneAbilityCooldownBuff>(), 5 * 60);
        }

        private static void DownedSlybertronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            if(laugicalityPlayer.Player.potionDelay > 0)
            {
                if (laugicalityPlayer.SlybertronCounter <= 0)
                {
                    laugicalityPlayer.SlybertronCounter = 15;
                    if (Main.netMode != 1)
                    {
                        Projectile.NewProjectile(laugicalityPlayer.Player.GetSource_FromThis(), laugicalityPlayer.Player.Center, new Vector2(0, 0), ModContent.ProjectileType<ElectroAura>(), (int)(48 * laugicalityPlayer.GetGlobalDamage()), 0, laugicalityPlayer.Player.whoAmI);
                    }
                }
                else
                    laugicalityPlayer.SlybertronCounter--;
            }
        }

        private static void DownedSteamTrainEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.SteamTrainEffect = true;
            laugicalityPlayer.Player.longInvince = true;
            if (laugicalityPlayer.Player.immuneTime > 0 && laugicalityPlayer.Player.immune)
                laugicalityPlayer.DamageBoost(.1f);
        }

        private static void DownedPlanteraEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            Item source = laugicalityPlayer.Player.HeldItem; 
            if (source == null || source.IsAir)
                return; 

            laugicalityPlayer.Player.SporeSac(source);
            laugicalityPlayer.Player.sporeSac = true;
        }


        private static void DownedGolemEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.GolemEffect = true;
        }

        private static void DownedDukeFishronEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.FishronEffect = true;
        }

        private static void DownedEtheriaEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.EtheriaEffect = true;
        }

        private static void DownedMoonLordEffect(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.MoonLordEffect = true;
            laugicalityPlayer.Player.endurance += .2f;
        }


        //Curses
        private static void CurseEffect1(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CapacityCurse1 = true;
        }

        private static void CurseEffect2(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CapacityCurse2 = true;
        }

        private static void CurseEffect3(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CapacityCurse3 = true;
        }

        private static void CurseEffect4(LaugicalityPlayer laugicalityPlayer, bool hideAccessory)
        {
            laugicalityPlayer.CapacityCurse4 = true;
        }
    }
}
