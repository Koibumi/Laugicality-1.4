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
	public class EmblemOfEtheria : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Emblem of Etheria");
            // Tooltip.SetDefault("Calls Etheria\n\'This seems like a terrible idea.\'");
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
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, ModContent.ProjectileType<GeneralBossSpawn>(), ModContent.NPCType<Etheria>(), knockback, player.whoAmI);
            return false;
        }

        public override bool CanUseItem(Player player)
        {
            if (Main.dayTime && !LaugicalityWorld.downedEtheria)
                return false;
            else if (NPC.CountNPCS(ModContent.NPCType<Etheria>()) > 0)
                return false;
            return true;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpookyWood, 75);
            recipe.AddIngredient(ItemID.Ectoplasm, 15);
            recipe.AddTile(TileID.DemonAltar);
			recipe.Register();

            Recipe arecipe = CreateRecipe();
            arecipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 15);
            arecipe.AddTile(TileID.DemonAltar);
            arecipe.Register();
        }
	}
}