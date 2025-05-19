using Laugicality.Utilities.Base;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Loot
{
	public class SoulOfHaught : LaugicalityItem
    {
        public override void Load()
        {
            string DropHell = this.GetLocalization("Drop.DropHell").Value; // Drops from any enemy in the Underworld during Hardmode
        }
        public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Soul of Haught");
			// Tooltip.SetDefault("'The essence of hot creatures'");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 8));
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
            Item.scale *= 4.5f;
        }

		public override void GrabRange(Player player, ref int grabRange)
		{
			grabRange *= 3;
		}
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string DropHell = this.GetLocalization("Drop.DropHell").Value;
            TooltipLine line = new TooltipLine(Mod, "UnderworldHardmodeDropInfo", DropHell)
            {
                OverrideColor = new Color(255, 69, 0) 
            };
            tooltips.Add(line);
        }


        public override void PostUpdate()
		{
			Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
		}
	}
    
}