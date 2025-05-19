using Laugicality.Content.Buffs;
using Laugicality.Content.Dusts;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Melee
{
	public class TrainScythe : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("CHOO CHOO! \nInflicts 'Steamy'");
		}

		public override void SetDefaults()
		{
            Item.scale = 3f;
			Item.damage = 832;
			Item.DamageType = DamageClass.Melee;
			Item.width = 144;
			Item.height = 144;
			Item.useTime = 55;
			Item.useAnimation = 55;
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
			recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<SoulOfWrought>(), 8);
            recipe.AddIngredient(ModContent.ItemType<Gear>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(2) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Steam>());
			}
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(ModContent.BuffType<Steamy>(), 2 * 60);
		}
	}
}
