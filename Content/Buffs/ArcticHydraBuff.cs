using Laugicality.Content.Projectiles.Summon;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Buffs
{
    public class ArcticHydraBuff : LaugicalityBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Arctic Hydra");
            // Description.SetDefault("The Hydra Hoard will fight for you");
            Main.buffNoTimeDisplay[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (player.ownedProjectileCounts[ModContent.ProjectileType<ArcticHydraHead>()] > 0)
            {
                modPlayer.ArcticHydraSummon = true;
            }
            if (!modPlayer.ArcticHydraSummon)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}