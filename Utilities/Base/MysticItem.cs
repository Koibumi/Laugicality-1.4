using System.Collections.Generic;
using System.Linq;
using Laugicality.Content.Buffs.Mystic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;

namespace Laugicality.Utilities.Base
{
    public abstract class MysticItem : LaugicalityItem
    {
        public abstract void Destruction(LaugicalityPlayer modPlayer);

        public abstract void Illusion(LaugicalityPlayer modPlayer);

        public abstract void Conjuration(LaugicalityPlayer modPlayer);

        public abstract void SetMysticDefaults();

        public sealed override void SetDefaults()
        {
            Hold = 0;
            //Item.DamageType = DamageClass.Generic; // false
            Item.crit = 4;
            LuxCost = 10;
            VisCost = 10;
            MundusCost = 10;
            SetMysticDefaults();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.Mod == "Terraria");
            int index = tooltips.FindIndex(x => x.Name == "Damage" && x.Mod == "Terraria");
            if (tt != null)
            {
                
                string[] split = tt.Text.Split(' ');
                
                tt.Text = split.First() + " mystic " + split.Last();
            }
            if (Hold > 0)
                Hold--;

            TooltipLine tt2 = new TooltipLine(Mod, "PlayerMysticChanneling", GetMysticType());
            TooltipLine tt3 = new TooltipLine(Mod, "PlayerMysticChanneling", GetMysticaType());

            tooltips.Insert(index + 1, tt2);
            tooltips.Insert(index + 2, tt3);
            
        }

        public override void ModifyWeaponDamage(Player player, ref StatModifier damage)
        {
            var modPlayer = LaugicalityPlayer.Get(player);

            damage *= modPlayer.MysticDamage;

            switch (modPlayer.MysticMode)
            {
                case 1:
                    damage *= modPlayer.DestructionDamage;
                    if (modPlayer.Lux > modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost)
                        damage *= modPlayer.OverflowDamage;
                    else
                        damage *= modPlayer.AntiflowDamage;
                    break;
                case 2:
                    damage *= modPlayer.IllusionDamage;
                    if (modPlayer.Vis > modPlayer.VisMax + modPlayer.VisMaxPermaBoost)
                        damage *= modPlayer.OverflowDamage;
                    else
                        damage *= modPlayer.AntiflowDamage;
                    break;
                case 3:
                    damage *= modPlayer.ConjurationDamage;
                    if (modPlayer.Mundus > modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost)
                        damage *= modPlayer.OverflowDamage;
                    else
                        damage *= modPlayer.AntiflowDamage;
                    break;
            }

            if (modPlayer.MysticBurstDisabled)
                damage *= 1.05f; 

            modPlayer.MysticHold = 2;
        }


        public override void HoldItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            switch (modPlayer.MysticMode)
            {
                case 1 :
                    player.AddBuff(ModContent.BuffType<Destruction>(), 1, true);
                    Destruction(modPlayer);
                    break;
                case 2:
                    player.AddBuff(ModContent.BuffType<Illusion>(), 1, true);
                    Illusion(modPlayer);
                    break;
                case 3:
                    player.AddBuff(ModContent.BuffType<Conjuration>(), 1, true);
                    Conjuration(modPlayer);
                    break;
            }

            modPlayer.CurrentLuxCost = LuxCost;
            modPlayer.CurrentVisCost = VisCost;
            modPlayer.CurrentMundusCost = MundusCost;
            Hold = 2;

            Laugicality.Instance.MysticaUI.Update();
        }

        private string GetMysticType()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "[c/F1C40F:- Destruction -]";
                case 2:
                    return "[c/8E44AD:- Illusion -]";
                case 3:
                    return "[c/28B463:- Conjuration -]";
            }

            return "mystic";
        }

        private string GetMysticaType()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            switch (laugicalityPlayer.MysticMode)
            {
                case 1:
                    return "Uses " + (laugicalityPlayer.CurrentLuxCost * laugicalityPlayer.LuxUseRate * laugicalityPlayer.GlobalPotentiaUseRate) + " lux";
                case 2:
                    return "Uses " + (laugicalityPlayer.CurrentVisCost * laugicalityPlayer.VisUseRate * laugicalityPlayer.GlobalPotentiaUseRate) + " vis";
                case 3:
                    return "Uses " + (laugicalityPlayer.CurrentMundusCost * laugicalityPlayer.MundusUseRate * laugicalityPlayer.GlobalPotentiaUseRate) + " mundus";
            }

            return "mystica";
        }
        
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);

            switch (modPlayer.MysticMode)
            {
                case 1:
                    if (modPlayer.Lux >= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate)
                    {
                        modPlayer.Lux -= LuxCost * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Lux < 0)
                            modPlayer.Lux = 0;
                        if (modPlayer.Lux > (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow;
                        modPlayer.Vis += LuxCost * modPlayer.GlobalAbsorbRate * modPlayer.VisAbsorbRate * modPlayer.LuxDischargeRate * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Vis > (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow;
                        modPlayer.Mundus += LuxCost * modPlayer.GlobalAbsorbRate * modPlayer.MundusAbsorbRate * modPlayer.LuxDischargeRate * modPlayer.LuxUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Mundus > (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow;
                    }
                    else
                        return false;
                    break;
                case 2:
                    if (modPlayer.Vis >= VisCost * modPlayer.VisUseRate * modPlayer.GlobalPotentiaUseRate)
                    {
                        modPlayer.Vis -= VisCost * modPlayer.VisUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Vis < 0)
                            modPlayer.Vis = 0;
                        modPlayer.Lux += VisCost * modPlayer.GlobalAbsorbRate * modPlayer.LuxAbsorbRate * modPlayer.VisDischargeRate * modPlayer.VisUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Lux > (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow;
                        if (modPlayer.Vis > (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow;
                        modPlayer.Mundus += VisCost * modPlayer.GlobalAbsorbRate * modPlayer.MundusAbsorbRate * modPlayer.VisDischargeRate * modPlayer.VisUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Mundus > (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow;
                    }
                    else
                        return false;
                    break;
                case 3:
                    if (modPlayer.Mundus >= MundusCost * modPlayer.MundusUseRate * modPlayer.GlobalPotentiaUseRate)
                    {
                        modPlayer.Mundus -= MundusCost * modPlayer.MundusUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Mundus < 0)
                            modPlayer.Mundus = 0;
                        modPlayer.Lux += MundusCost * modPlayer.GlobalAbsorbRate * modPlayer.LuxAbsorbRate * modPlayer.MundusDischargeRate * modPlayer.MundusUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Lux > (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Lux = (modPlayer.LuxMax + modPlayer.LuxMaxPermaBoost) * modPlayer.LuxOverflow * modPlayer.GlobalOverflow;
                        modPlayer.Vis += MundusCost * modPlayer.GlobalAbsorbRate * modPlayer.VisAbsorbRate * modPlayer.MundusDischargeRate * modPlayer.MundusUseRate * modPlayer.GlobalPotentiaUseRate;
                        if (modPlayer.Vis > (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Vis = (modPlayer.VisMax + modPlayer.VisMaxPermaBoost) * modPlayer.VisOverflow * modPlayer.GlobalOverflow;
                        if (modPlayer.Mundus > (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow)
                            modPlayer.Mundus = (modPlayer.MundusMax + modPlayer.MundusMaxPermaBoost) * modPlayer.MundusOverflow * modPlayer.GlobalOverflow;
                    }
                    else
                        return false;
                    break;
            }

            return MysticShoot(player, ref position, ref velocity.X, ref velocity.Y, ref type, ref damage, ref knockback);
        }

        public virtual bool MysticShoot(Player player, ref Vector2 position, ref float velocityX, ref float velocityY, ref int type, ref int damage, ref float knockback)
        {
            return true;
        }

        public bool Mystic { get; } = true;

        public int LuxCost { get; set; } = 10;

        public int MundusCost { get; set; } = 10;

        public int VisCost { get; set; } = 10;

        public int Hold { get; private set; }
    }
}