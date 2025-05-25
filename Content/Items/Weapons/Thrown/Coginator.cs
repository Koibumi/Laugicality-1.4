using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Thrown;
using Laugicality.Utilities.Base;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Thrown
{
    public class Coginator : LaugicalityItem
    {
        public override void SetDefaults()
        {
            Item.damage = 80;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.width = 24;
            Item.height = 24;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CoginatorP>();
            Item.shootSpeed = 16f;
            Item.useTurn = true;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.noUseGraphic = true;

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(75);
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}