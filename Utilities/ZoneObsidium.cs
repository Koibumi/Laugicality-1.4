using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Utilities
{
    public class ZoneObsidium : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            bool inObsidium = BiomeTileCounterSystem.ZoneObsidiumBiom > 150;
            player.GetModPlayer<LaugicalityPlayer>().zoneObsidium = inObsidium;
            return inObsidium;
        }

        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;

        public override int Music => MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Obsidium");
        public override string MapBackground => "Laugicality/Backgrounds/ObsidiumBiomeMapBackground";
    }
}
