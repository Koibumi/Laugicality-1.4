using Laugicality.Content.Buffs;
using Laugicality.Content.Items.Loot;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Melee
{
    public class BrassClaymore : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Inflicts 'Steamy'");
        }

        public override void SetDefaults()
        {
            Item.scale = 1.25f;
            Item.damage = 90;
            Item.DamageType = DamageClass.Melee;
            Item.width = 54;
            Item.height = 64;
            Item.useTime = 14;
            Item.useAnimation = 14;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SteamBar>(), 14);
            recipe.AddIngredient(ItemID.Cog, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
        
        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(ModContent.BuffType<Steamy>(), 5 * 60);
        }
    }
}
