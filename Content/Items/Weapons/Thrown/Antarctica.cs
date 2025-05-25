using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Placeable;
using Laugicality.Content.Projectiles.Thrown;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Thrown
{
    public class Antarctica : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Antarctica");
            // Tooltip.SetDefault("'A blizzard hails from above'\nWhen in the Etherial after defeating Etheria, rain down more Hail,\nand stay stuck in enemies for twice as long.");
        }
        public override void SetDefaults()
        {
            Item.damage = 150;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.width = 12;
            Item.height = 12;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<AntarcticaProjectile>();
            Item.shootSpeed = 26f;
            Item.useTurn = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.noUseGraphic = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.NorthPole);
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 6);
            recipe.AddTile(ModContent.TileType<Tiles.AlchemicalInfuser>());
            recipe.Register();
        }
    }
}