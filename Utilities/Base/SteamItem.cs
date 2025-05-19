using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;

namespace Laugicality.Utilities.Base
{
    public abstract class SteamItem : LaugicalityItem
    {

        public static int steamTier = 1;
        public static bool steam = false;
        public static int steamCost = 1;
        public override void SetDefaults()
        {
            Item.crit = 4;
            //Item.DamageType = DamageClass.Generic = false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (tt != null)
            {
                string[] split = tt.Text.Split(' ');
                tt.Text = split.First() + " steam " + split.Last();
            }
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get(player);
            damage *= laugicalityPlayer.steamDamage;
        }    
    }
}