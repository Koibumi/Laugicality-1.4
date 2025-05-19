using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using Laugicality.Utilities.Base;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Laugicality.Content.Projectiles.Mystic.Conjuration;

namespace Laugicality.Content.Items.Weapons.Mystic
{
    public class ChlorysBlade : MysticItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Chlorys's Blade");
            // Tooltip.SetDefault("Illusion inflicts 'Poisoned'\nFires different projectiles based on Mysticism");
        }

        public override void SetMysticDefaults()
        {
            Item.damage = 10;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = 1;
            Item.noMelee = false;
            Item.knockBack = 2;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed = 6f;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.damage = 10;
            Item.useTime = 48;
            Item.useAnimation = (int)(Item.useTime / 2);
            Item.knockBack = 3;
            Item.shootSpeed = 10f;
            Item.shoot = ModContent.ProjectileType<ChlorysDestruction>();
            Item.UseSound = SoundID.Item1;
            LuxCost = 6;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.damage = 8;
            Item.useTime = 30;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 5;
            Item.shootSpeed = 8f;
            Item.shoot = ModContent.ProjectileType<ChlorysIllusion>();
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.scale = 1f;
            VisCost = 6;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.damage = 10;
            Item.useTime = 60;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 2;
            Item.shootSpeed = 4f;
            Item.shoot = ModContent.ProjectileType<ChlorysConjuration1>();
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item1;
            Item.scale = 1f;
            MundusCost = 10;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 16);
            //recipe.RequireGroup();
            recipe.AddIngredient(ItemID.Acorn, 6);
            recipe.AddIngredient(ItemID.Sunflower, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}