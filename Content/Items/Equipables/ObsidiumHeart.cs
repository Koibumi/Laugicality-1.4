using Laugicality.Content.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Equipables
{
	public class ObsidiumHeart : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("'A special kind of love.'\nHave a Heart from a Heart in a Heart in a Heart");
        }
        public override void SetDefaults()
        {
            //item.CloneDefaults(ItemID.ZephyrFish);
            Item.width = 28;
			Item.height = 28;
            Item.shoot = ModContent.ProjectileType<ObsidiumHeartProjectile>();
            Item.buffType = ModContent.BuffType<Content.Buffs.ObsidiumHeartBuff>();
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.maxStack = 1;
			Item.rare = ItemRarityID.Orange;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item4;
		}
        
        public override void UseStyle(Player player, Rectangle heldItemFrame)
        {
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(Item.buffType, 3600, true);
            }
        }
    }
}