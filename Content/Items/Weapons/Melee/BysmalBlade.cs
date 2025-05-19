using Laugicality.Content.Buffs;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Utilities;
using Laugicality.Content.Tiles;

namespace Laugicality.Content.Items.Weapons.Melee
{
	public class BysmalBlade : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("'A chill like no other' \nInflicts 'Frostbite'.\nWhile in the Etherial after defeating Etheria, increased size and swing speed");
		}

		public override void SetDefaults()
		{
            Item.scale = 2.5f;
			Item.damage = 315;
			Item.DamageType = DamageClass.Melee;
			Item.width = 144;
			Item.height = 144;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 6;
            Item.value = 10000;
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 5);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
			recipe.Register();
		}

        public override void HoldItem(Player player)
        {
            if((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(player).Etherable > 0) && LaugicalityWorld.downedTrueEtheria)
            {
                Item.scale = 3.5f;
                Item.useTime = 12;
                Item.useAnimation = 12;
            }
            else
            {
                Item.scale = 2.5f;
                Item.useTime = 15;
                Item.useAnimation = 15;
            }
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
            target.AddBuff(ModContent.BuffType<Frostbite>(), 5 * 60);
        }
	}
}
