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
	public class EtherialBone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Etherial Crown");
            // Tooltip.SetDefault("Summons Skeletron");
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
			//item.UseSound = SoundID.Item44;
			Item.consumable = true;
			Item.shoot = ModContent.ProjectileType<Nothing>();
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, speed.X, speed.Y, ModContent.ProjectileType<GeneralBossSpawn>(), NPCID.SkeletronHead, knockback, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            return (!Main.dayTime && LaugicalityWorld.downedEtheria && NPC.CountNPCS(NPCID.SkeletronHead) < 1);
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