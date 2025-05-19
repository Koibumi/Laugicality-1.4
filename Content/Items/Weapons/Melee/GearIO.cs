using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Projectiles.Melee;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Melee
{
    public class GearIO : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Geariken");
            // Tooltip.SetDefault("Don't prick yourself!");

            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 19;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = 5;
            Item.width = 32;
            Item.height = 26;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.knockBack = 2.5f;
            Item.damage = 100;
            Item.rare = ItemRarityID.Orange;

            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;

            Item.UseSound = SoundID.Item1;
            Item.value = Item.sellPrice(silver: 1);
            Item.shoot = ModContent.ProjectileType<GearIOProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<Gear>(), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
