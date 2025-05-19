using System;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Content.Tiles;
using Terraria.WorldBuilding;

namespace Laugicality.Utilities
{
    public class BiomeTileCounterSystem : ModSystem
    {
        public static int ZoneObsidiumBiom = 0;

        public override void ResetNearbyTileEffects()
        {
            ZoneObsidiumBiom = 0;                     
        }

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            ZoneObsidiumBiom = tileCounts[ModContent.TileType<ObsidiumRock>()];
        }
    }
}