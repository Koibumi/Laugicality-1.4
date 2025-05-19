using Laugicality.Content.Projectiles.Mystic.Conjuration;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Weapons.Mystic
{
    public class GaiasWorld : MysticItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gaia's World");
            // Tooltip.SetDefault("The World is in your hands\nIllusion inflicts a random elemental debuff\nFires different projectiles based on Mysticism");
            Item.staff[Item.type] = true;
        }

        public override void SetMysticDefaults()
        {
            Item.damage = 25;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.value = 10000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<GaiaDestruction>();
            Item.shootSpeed = 6f;
        }

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.damage = 25;
            Item.useTime = 28;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 6;
            Item.shootSpeed = 10;
            Item.shoot = ModContent.ProjectileType<GaiaDestruction>();
            LuxCost = 7;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.damage = 25;
            Item.useTime = 20;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 4;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<GaiaIllusion>();
            VisCost = 10;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.damage = 25;
            Item.useTime = 32;
            Item.useAnimation = 32;
            Item.knockBack = 3;
            Item.shootSpeed = 8f;
            Item.shoot = ModContent.ProjectileType<GaiaConjuration>();
            MundusCost = 12;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 8);
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 4);
            recipe.AddIngredient(ItemID.Amethyst);
            recipe.AddIngredient(ItemID.Topaz);
            recipe.AddIngredient(ItemID.Sapphire);
            recipe.AddIngredient(ItemID.Emerald);
            recipe.AddIngredient(ItemID.Ruby);
            recipe.AddIngredient(ItemID.Diamond);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}