using Laugicality.Content.Buffs;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Summon;
using Laugicality.Utilities.Base;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Summon
{
	public class Antenna : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("Summons a TV to fight for you.");
		}

		public override void SetDefaults()
		{
			Item.damage = 55;
			Item.DamageType = DamageClass.Summon;
			Item.mana = 16;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = 1;
			Item.noMelee = true;
			Item.knockBack = 3;
			Item.value = Item.buyPrice(0, 25, 0, 0);
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item44;
			Item.shoot = ModContent.ProjectileType<TV>();
			Item.shootSpeed = 12f;
			Item.buffType = ModContent.BuffType<TVBuff>();
			Item.buffTime = 3600;
		}
		
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			return player.altFunctionUse != 2;
		}
		
		public override bool? UseItem(Player player)
		{
			if(player.altFunctionUse == 2)
			{
				player.MinionNPCTargetAim(false);
			}
			return base.UseItem(player);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<SoulOfThought>(), 20);
            recipe.AddIngredient(1344, 40);
            recipe.Register();
        }
    }
}
