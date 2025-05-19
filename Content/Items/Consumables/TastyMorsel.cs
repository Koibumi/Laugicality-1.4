using Laugicality.Content.NPCs.PreTrio;
using Laugicality.Content.Projectiles.BossSummons;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Content.Projectiles.Special;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Consumables
{
	public class TastyMorsel : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Summons Dune Sharkron in the desert \n\'Mmm... Looks delicious.\'");
        }

        public override void SetDefaults()
		{
			Item.width = 16;
			Item.height = 20;
			Item.maxStack = 20;
			Item.rare = ItemRarityID.Blue;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item44;
			Item.consumable = true;
			Item.shoot = ModContent.ProjectileType<Nothing>();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<DuneSharkron>(), knockback, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player) => player.ZoneDesert && NPC.CountNPCS(ModContent.NPCType<DuneSharkron>()) < 1;

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Lens, 2);
			recipe.AddIngredient(ItemID.Vertebrae, 3);
            recipe.AddIngredient(ItemID.SharkFin, 2);
            recipe.AddTile(TileID.DemonAltar);
			recipe.Register();


            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.Lens, 2);
            recipe1.AddIngredient(ItemID.RottenChunk, 3);
            recipe1.AddIngredient(ItemID.SharkFin, 2);
            recipe1.AddTile(TileID.DemonAltar);
            recipe1.Register();
        }
	}
}