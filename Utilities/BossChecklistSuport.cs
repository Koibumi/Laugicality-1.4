using System;
using System.Collections.Generic;
using Terraria.ModLoader;
using Laugicality.Content.Items.Consumables;
using Laugicality.Content.NPCs.Bosses;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.NPCs.Slybertron;
using Laugicality.Content.NPCs.SteamTrain;
using Laugicality.Content.NPCs.PreTrio;
using Laugicality.Content.Items.Materials;
using Terraria.ID;
using Laugicality.Content.NPCs.Etheria;
using Laugicality.Content.NPCs.RockTwins;

namespace Laugicality.Utilities
{
    public class BossChecklistSuport : ModSystem
    {
        public override void PostSetupContent()
        {
            DoBossChecklistIntegration();
        }

        private void DoBossChecklistIntegration()
        {

            if (!ModLoader.TryGetMod("BossChecklist", out Mod bossChecklistMod))
            {
                return;
            }

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }
            string internalName = "TheAnnihilatorB";

            float weight = 11.991f;

            Func<bool> downed = () => LaugicalityWorld.downedAnnihilator;

            int bossType = ModContent.NPCType<TheAnnihilator>();

            int spawnItem = ModContent.ItemType<MechanicalMonitor>();

            List<int> collectibles = new List<int>()
            {
                ModContent.ItemType<CogOfEtheria>(),
                ModContent.ItemType<SteamBar>(),
                ModContent.ItemType<SoulOfThought>(),
                ModContent.ItemType<AnnihilatorTreasureBag>()
            };

            bossChecklistMod.Call(
               "LogBoss",
               Mod,
               internalName,
               weight,
               downed,
               bossType,
               new Dictionary<string, object>()
               {
                   ["spawnItems"] = spawnItem,
                   ["collectibles"] = collectibles,
               }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
               "LogBoss",
               Mod,
               internalName = "SlybertronBoss",
               weight = 11.992f,
               downed = (Func<bool>)(() => LaugicalityWorld.downedSlybertron),
               bossType = ModContent.NPCType<Slybertron>(),
               new Dictionary<string, object>()
               {
                   ["spawnItems"] = spawnItem = ModContent.ItemType<SteamCrown>(),
                   ["collectibles"] = collectibles = new List<int>()
                   {
                       ModContent.ItemType<Etherworks>(),
                       ModContent.ItemType<SteamBar>(),
                       ModContent.ItemType<SoulOfFraught>(),
                       ModContent.ItemType<SlybertronTreasureBag>()
                   }
               }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
               "LogBoss",
               Mod,
               internalName = "SteamTrainBoss",
               weight = 11.993f,
               downed = (Func<bool>)(() => LaugicalityWorld.downedSteamTrain),
               bossType = ModContent.NPCType<SteamTrain>(),
               new Dictionary<string, object>()
               {
                   ["spawnItems"] = spawnItem = ModContent.ItemType<SuspiciousTrainWhistle>(),
                   ["collectibles"] = collectibles = new List<int>()
                   {
                       ModContent.ItemType<EtherialTank>(),
                       ModContent.ItemType<SteamBar>(),
                       ModContent.ItemType<SoulOfWrought>(),
                       ModContent.ItemType<SteamTrainTreasureBag>()
                   }
               }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
               "LogBoss",
               Mod,
               internalName = "DuneSharkronBoss",
               weight = 2.3f,
               downed = (Func<bool>)(() => LaugicalityWorld.downedDuneSharkron),
               bossType = ModContent.NPCType<DuneSharkron>(),
               new Dictionary<string, object>()
               {
                   ["spawnItems"] = spawnItem = ModContent.ItemType<TastyMorsel>(),
                   ["collectibles"] = collectibles = new List<int>()
                   {
                       ModContent.ItemType<Etheramind>(),
                       ModContent.ItemType<DuneSharkronTreasureBag>(),
                       ModContent.ItemType<AncientShard>(),
                       ItemID.SandstorminaBottle,
                       ItemID.FlyingCarpet,
                       ItemID.BandofRegeneration,
                       ItemID.MagicMirror,
                       ItemID.CloudinaBottle,
                       ItemID.HermesBoots,
                       ItemID.EnchantedBoomerang
                   }
               }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
               "LogBoss",
               Mod,
               internalName = "HypothemaBoss",
               weight = 3.8f,
               downed = (Func<bool>)(() => LaugicalityWorld.downedHypothema),
               bossType = ModContent.NPCType<Hypothema>(),
               new Dictionary<string, object>()
               {
                   ["spawnItems"] = spawnItem = ModContent.ItemType<ChilledMesh>(),
                   ["collectibles"] = collectibles = new List<int>()
                   {
                       ModContent.ItemType<EtherialFrost>(),
                       ModContent.ItemType<HypothemaTreasureBag>(),
                       ModContent.ItemType<FrostShard>(),
                       ModContent.ItemType<ChilledBar>(),
                       ItemID.SnowBlock,
                       ItemID.IceBlock,
                       ItemID.IceBoomerang,
                       ItemID.IceBlade,
                       ItemID.IceSkates,
                       ItemID.FlurryBoots,
                       ItemID.BlizzardinaBottle,
                       ItemID.SnowballCannon
                   }
               }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
               "LogBoss",
               Mod,
               internalName = "RagnarBoss",
               weight = 4.5f,
               downed = (Func<bool>)(() => LaugicalityWorld.downedRagnar),
               bossType = ModContent.NPCType<Ragnar>(),
               new Dictionary<string, object>()
               {
                   ["spawnItems"] = spawnItem = ModContent.ItemType<MoltenMess>(),
                   ["collectibles"] = collectibles = new List<int>()
                   {
                       ModContent.ItemType<MoltenEtheria>(),
                       ModContent.ItemType<DarkShard>(),
                       ItemID.MagicMirror,
                       ItemID.BandofRegeneration,
                       ItemID.CloudinaBottle,
                       ItemID.HermesBoots,
                       ItemID.EnchantedBoomerang,
                       ItemID.LavaCharm
                   }
               }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
               "LogBoss",
               Mod,
               internalName = "EtheriaBoss",
               weight = 13.51f,
               downed = (Func<bool>)(() => LaugicalityWorld.downedTrueEtheria),
               bossType = ModContent.NPCType<Etheria>(),
               new Dictionary<string, object>()
               {
                   ["spawnItems"] = spawnItem = ModContent.ItemType<EmblemOfEtheria>(),
                   ["collectibles"] = collectibles = new List<int>()
                   {
                       ModContent.ItemType<EtherialEssence>()
                   }
               }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
               "LogBoss",
               Mod,
               internalName = "DioritusBoss",
               weight = 5.91f,
               downed = (Func<bool>)(() => LaugicalityWorld.downedAnDio),
               bossType = ModContent.NPCType<Dioritus>(),
               new Dictionary<string, object>()
               {
                   ["spawnItems"] = spawnItem = ModContent.ItemType<AncientAwakener>()
               }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
               "LogBoss",
               Mod,
               internalName = "AndesiaBoss",
               weight = 5.92f,
               downed = (Func<bool>)(() => LaugicalityWorld.downedAnDio),
               bossType = ModContent.NPCType<Andesia>(),
               new Dictionary<string, object>()
               {
                 
               }
            );

            if (bossChecklistMod.Version < new Version(1, 6))
            {
                return;
            }

            bossChecklistMod.Call(
               "LogBoss",
               Mod,
               internalName = "AnDioBoss",
               weight = 5.93f,
               downed = (Func<bool>)(() => LaugicalityWorld.downedAnDio),
               bossType = ModContent.NPCType<AnDio3>(),
               new Dictionary<string, object>()
               {
                   ["collectibles"] = collectibles = new List<int>()
                   {
                       ModContent.ItemType<TheWorldOfEtheria>(),
                       ModContent.ItemType<DioritusCore>(),
                       ModContent.ItemType<AndesiaCore>(),
                       ItemID.Granite,
                       ItemID.Marble,
                       ModContent.ItemType<AnDioTreasureBag>(),
                   }
               }
            );
        }
    }
}