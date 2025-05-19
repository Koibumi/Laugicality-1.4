using Laugicality.Utilities.Base;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace Laugicality.Content.Items.Loot
{
	public class SoulOfThought : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Soul of Thought");
			// Tooltip.SetDefault("'The essence of intelligence'");
			// ticksperframe, frameCount
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		// TODO -- Velocity Y smaller, post NewItem?
		public override void SetDefaults()
		{
			Item refItem = new Item();
			refItem.SetDefaults(ItemID.SoulofSight);
			Item.width = refItem.width;
			Item.height = refItem.height;
			Item.maxStack = 999;
			Item.value = 1000;
			Item.rare = ItemRarityID.Orange;
            Item.scale *= 1.5f;
        }

		public override void GrabRange(Player player, ref int grabRange)
		{
			grabRange *= 3;
		}
		public override void PostUpdate()
		{
			Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
		}
	}
    
}