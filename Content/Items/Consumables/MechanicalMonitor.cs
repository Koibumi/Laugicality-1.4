using Laugicality.Content.NPCs.Bosses;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.NPCs.Etheria;
using Laugicality.Content.Tiles;
using Laugicality.Content.Projectiles.BossSummons;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Content.Projectiles.Special;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Utilities;

namespace Laugicality.Content.Items.Consumables
{
	public class MechanicalMonitor : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Steam-O-Vision");
            // Tooltip.SetDefault("Summons The Annihilator");
        }
        
        public override void SetDefaults()
		{
			Item.width = 48;
			Item.height = 40;
			Item.maxStack = 20;
			Item.rare = ItemRarityID.Pink;
			Item.useAnimation = 45;
			Item.useTime = 45;
			Item.useStyle = ItemUseStyleID.HoldUp;
			Item.UseSound = SoundID.Item44;
			Item.consumable = true;
			Item.shoot = ModContent.ProjectileType<Nothing>();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, speed.X, speed.Y, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<TheAnnihilator>(), knockback, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player) => !Main.dayTime && NPC.CountNPCS(ModContent.NPCType<TheAnnihilator>()) < 1;

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 5);
            recipe.AddIngredient(ItemID.Lens, 3);
			recipe.AddIngredient(ItemID.Vertebrae, 3);
            recipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 3);
            recipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 3);
            recipe.AddIngredient(ItemID.Cog, 20);
            recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
            
            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ItemID.HallowedBar, 5);
            recipe1.AddIngredient(ItemID.Lens, 3);
            recipe1.AddIngredient(ItemID.RottenChunk, 3);
            recipe1.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 3);
            recipe1.AddIngredient(ModContent.ItemType<SoulOfSought>(), 3);
            recipe1.AddIngredient(ItemID.Cog, 20);
            recipe1.AddTile(TileID.MythrilAnvil);
            recipe1.Register();
        }
	}
}