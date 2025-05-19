using Laugicality.Content.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Melee
{
    public class Aurora : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aurora");
            // Tooltip.SetDefault("'Chill them into submission'");
        }

        public override void SetDefaults()
        {
            Item.damage = 65;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = false;
            Item.width = 54;
            Item.height = 58;
            Item.useTime = 23;
            Item.useAnimation = 23;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 100000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.Melee.AuroraProjectile>();
            Item.shootSpeed = 16f;
            Item.useTurn = true;
            Item.maxStack = 1;
            Item.consumable = false;
        }

        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FrostBlade>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 6);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddRecipeGroup("TitaniumBars", 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}