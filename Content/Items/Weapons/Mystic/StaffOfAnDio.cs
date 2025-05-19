using Laugicality.Content.Projectiles.Mystic.Conjuration;
using Laugicality.Content.Projectiles.Mystic.Destruction;
using Laugicality.Content.Projectiles.Mystic.Illusion;
using Laugicality.Content.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Players;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Mystic
{
	public class StaffOfAnDio : MysticItem
    {
		public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Loki's Staff");
            // Tooltip.SetDefault("'Many tricks up his sleeve'\nIllusion inflicts 'Chilled'\nFires different projectiles based on Mysticism");
            Item.staff[Item.type] = true; 
        }

		public override void SetMysticDefaults()
		{
			Item.damage = 40;
            Item.width = 48;
			Item.height = 48;
			Item.useTime = 18;
			Item.useAnimation = 28;
			Item.useStyle = 5;
			Item.noMelee = true; 
			Item.knockBack = 2;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shootSpeed = 6f;
		}

        public override void Destruction(LaugicalityPlayer modPlayer)
        {
            Item.damage = 52;
            Item.useTime = 24;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 8;
            Item.shootSpeed = 14f;
            Item.shoot = ModContent.ProjectileType<AnDioDestruction1>();
            Item.UseSound = SoundID.Item20;
            Item.scale = 1f;
            LuxCost = 8;
        }

        public override void Illusion(LaugicalityPlayer modPlayer)
        {
            Item.damage = 26;
            Item.useTime = 2;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 5;
            Item.shootSpeed = 12f;
            Item.shoot = ModContent.ProjectileType<AnDioIllusion>();
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item20;
            Item.scale = 1f;
            VisCost = 1;
        }

        public override void Conjuration(LaugicalityPlayer modPlayer)
        {
            Item.damage = 38;
            Item.useTime = 30;
            Item.useAnimation = Item.useTime;
            Item.knockBack = 2;
            Item.shootSpeed = 18f;
            Item.shoot = ModContent.ProjectileType<AnDioConjuration1>();
            Item.noUseGraphic = false;
            Item.UseSound = SoundID.Item20;
            Item.scale = 1f;
            MundusCost = 10;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DioritusCore>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AndesiaCore>(), 1);
            recipe.AddIngredient(3081, 25);
            recipe.AddIngredient(3086, 25);
            recipe.AddRecipeGroup("TitaniumBars", 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}