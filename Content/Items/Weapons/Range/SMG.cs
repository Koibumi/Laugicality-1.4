using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Utilities.Base;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Laugicality.Content.Items.Weapons.Range
{
    public class SMG : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("S.M.G.");
            // Tooltip.SetDefault("'Snow Machine Gun'\n20% chance not to consume ammo");
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 50;
            Item.height = 26;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.knockBack = 2;
            Item.value = 1000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item34;
            Item.autoReuse = true;
            Item.shootSpeed = 13f;
            Item.useAmmo = AmmoID.Snowball;
            Item.shoot = ProjectileID.SnowBallFriendly;
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            if (Main.rand.Next(5) == 0)
                return false;
            return base.CanConsumeAmmo(ammo, player);
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SnowballCannon);
            recipe.AddIngredient(ModContent.ItemType<FrostShard>());
            recipe.AddIngredient(ModContent.ItemType<ChilledBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}