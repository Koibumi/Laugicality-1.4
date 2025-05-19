using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Magic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;


namespace Laugicality.Content.Items.Weapons.Magic
{
    public class Blitzfrig : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blitzfrieg");
            // Tooltip.SetDefault("'Cold Lightning'\nWhen in the Etherial after defeating Etheria, create twice as much branch Lightning.");
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 125;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 4;
            Item.width = 28;
            Item.height = 30;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 5;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item122;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<BlitzBolt1>();
            Item.shootSpeed = 14f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 90f;
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            return true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 8);
            recipe.AddIngredient(ItemID.BlizzardStaff);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}