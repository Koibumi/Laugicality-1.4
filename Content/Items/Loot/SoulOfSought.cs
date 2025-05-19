using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Laugicality.Utilities.Base;
using System.Collections.Generic;
using Terraria.ModLoader;
using System;

namespace Laugicality.Content.Items.Loot
{
	public class SoulOfSought : LaugicalityItem
	{
        public override void Load()
        {
            string DropSky = this.GetLocalization("Drop.DropSky").Value; // Drops from any enemy in the sky during Hardmode
        }
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Soul of Sought");
			// Tooltip.SetDefault("'The essence of space creatures'");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofSight);
			Item.width = refItem.width;
			Item.height = refItem.height;
			Item.maxStack = 9999;
			Item.value = 1000;
			Item.rare = ItemRarityID.Orange;
            Item.scale *= 1.5f;
		}

		public override void GrabRange(Player player, ref int grabRange)
		{
			grabRange *= 3;
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string DropSky = this.GetLocalization("Drop.DropSky").Value;
            TooltipLine line = new TooltipLine(Mod, "SkyHardmodeDropInfo", DropSky)
            {
                OverrideColor = new Color(135, 206, 235) 
            };
            tooltips.Add(line);
        }

        public override void PostUpdate()
		{
			Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
		}
	}
    
}