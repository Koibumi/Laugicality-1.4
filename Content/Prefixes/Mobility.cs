using Laugicality.Utilities.Globals;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Content.Prefixes
{
    public class SpeedyPrefix : ModPrefix
    {
        public override void Load()
        {
            string Tooltips1 = this.GetLocalization("Tooltips.Tooltips1").Value; // Yeeting
            string Tooltips2 = this.GetLocalization("Tooltips.Tooltips2").Value; // % Max Run speed and Movement speed
        }

        public virtual float Power => 1f;

        public SpeedyPrefix() { }

        public override PrefixCategory Category => PrefixCategory.Accessory;

        public override float RollChance(Item item)
        {
            return 80f;
        }
        public override bool CanRoll(Item item)
        {
            return true;
        }
        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1f + 0.05f * Power;
        }
        public override void Apply(Item item)
        {
            item.GetGlobalItem<GlobalSpeed>()._Speed = true;
        }
        public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
        {
            string Tooltips1 = this.GetLocalization("Tooltips.Tooltips1").Value; 
            string Tooltips2 = this.GetLocalization("Tooltips.Tooltips2").Value; 

            yield return new TooltipLine(Mod, Tooltips1, "+" + 1.5 + Tooltips2 ) 
            {
                IsModifier = true,
            };
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            
        }
    }
}