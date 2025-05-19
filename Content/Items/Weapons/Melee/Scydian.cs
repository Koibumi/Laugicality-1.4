using Laugicality.Content.Dusts;
using Laugicality.Content.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Melee
{
	public class Scydian : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("The power of magma \nInflicts 'On Fire!'");
		}

		public override void SetDefaults()
		{
            Item.scale *= 1.25f;
			Item.damage = 66;
			Item.DamageType = DamageClass.Melee;
			Item.width = 64;
			Item.height = 56;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = 1;
			Item.knockBack = 5;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 20);
			recipe.AddTile(16);
			recipe.Register();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.Next(3) == 0)
			{
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<Magma>());
			}
		}

		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 2 * 60);
		}
	}
}
