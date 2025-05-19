using Laugicality.Content.NPCs.RockTwins;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.NPCs.Etheria;
using Laugicality.Content.Projectiles.BossSummons;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Laugicality.Content.Projectiles.Special;
using Laugicality.Utilities.Base;
using Laugicality.Utilities;

namespace Laugicality.Content.Items.Consumables
{
	public class EtherialAwakener : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Summons Dioritus");
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
			Item.consumable = true;
			Item.shoot = ModContent.ProjectileType<Nothing>();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, speed.X, speed.Y, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<Dioritus>(), knockback, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return (player.ZoneRockLayerHeight && LaugicalityWorld.downedEtheria && NPC.CountNPCS(ModContent.NPCType<Andesia>()) < 1 && NPC.CountNPCS(ModContent.NPCType<Dioritus>()) < 1 && NPC.CountNPCS(ModContent.NPCType<AnDio3>()) < 1);
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 3);
            recipe.AddTile(TileID.DemonAltar);
			recipe.Register();
        }
	}
}