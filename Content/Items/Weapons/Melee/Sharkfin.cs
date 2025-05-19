using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Melee
{
    class Sharkfin : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("'Crystil barrage'");
        }

        public override void SetDefaults()
        {
            Item.damage = 32;
            Item.DamageType = DamageClass.Melee;
            Item.width = 42;
            Item.height = 48;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = 1;
            Item.knockBack = 5;
            Item.value = 10000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.CrystalBullet;
            Item.shootSpeed = 16f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 6);
            recipe.AddIngredient(ItemID.FossilOre, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
