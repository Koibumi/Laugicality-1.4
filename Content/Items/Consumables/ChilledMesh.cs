using Laugicality.Content.NPCs.PreTrio;
using Laugicality.Content.Projectiles.BossSummons;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Content.Projectiles.Special;
using Laugicality.Utilities.Base;
using Laugicality.Content.NPCs.RockTwins;
using Terraria.DataStructures;

namespace Laugicality.Content.Items.Consumables
{
	public class ChilledMesh : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //Tooltip.SetDefault("Summons Hypothema\n'It's almost freezing your fingers off.'");
        }

        public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
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
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<Hypothema>(), knockback, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return (player.ZoneSnow && NPC.CountNPCS(ModContent.NPCType<Hypothema>()) < 1);
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SnowBlock, 25);
            recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddIngredient(ItemID.DemoniteBar, 12);
            recipe.AddTile(TileID.DemonAltar);
			recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.SnowBlock, 25);
            recipe2.AddIngredient(ItemID.IceBlock, 25);
            recipe2.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe2.AddTile(TileID.DemonAltar);
            recipe2.Register();
        }
	}
}