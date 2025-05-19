using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Melee
{
    public class EnginatorM : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Enginator");
            // Tooltip.SetDefault("CHOO CHOO");
        }
        public override void SetDefaults()
        {
            Item.damage = 110;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.width = 106;
            Item.height = 74;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10;
            Item.rare = ItemRarityID.Orange;
            Item.reuseDelay = 20;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<EnginatorMProj>();
            Item.shootSpeed = 16f;
            Item.useTurn = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.noUseGraphic = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 16);
            recipe.AddIngredient(ModContent.ItemType<SoulOfFraught>(), 8);
            recipe.AddIngredient(ModContent.ItemType<Gear>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}