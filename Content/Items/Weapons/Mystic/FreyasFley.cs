using Laugicality.Content.Projectiles.Mystic.Conjuration;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Laugicality.Content.Projectiles.Special;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Mystic
{
    public class FreyasFley : MysticItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Freya's Fley");
            // Tooltip.SetDefault("Spores of the gods\nIllusion inflicts 'Shroomed', which slowly drains enemy life\nFires different projectiles based on Mysticism");
            Item.staff[Item.type] = true;
        }

        public override void SetMysticDefaults()
        {
            Item.damage = 11;
            Item.width = 52;
            Item.height = 50;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.value = 10000;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Nothing>();
            Item.shootSpeed = 6f;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.damage = 10;
            Item.useTime = 9;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 1;
            Item.shootSpeed = 10f;
            Item.shoot = ModContent.ProjectileType<FreyaDestruction>();
            LuxCost = 3;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.damage = 10;
            Item.damage = (int)(Item.damage * modPlayer.IllusionDamage);
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.knockBack = 1;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<FreyaIllusion>();
            VisCost = 10;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.damage = 12;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.knockBack = 5;
            Item.shootSpeed = 2f;
            Item.shoot = ModContent.ProjectileType<FreyaConjuration1>();
            MundusCost = 14;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(183, 12);
            recipe.AddIngredient(176, 10);
            recipe.AddIngredient(ItemID.FallenStar, 2);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}