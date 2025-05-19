using Laugicality.Content.Items.Loot;
using Laugicality.Content.Projectiles.Melee;
using Laugicality.Content.Tiles;
using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;

namespace Laugicality.Content.Items.Weapons.Melee
{
    public class BysmalBrand : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Borealis");
            // Tooltip.SetDefault("'The great frost comes'\nWhile in the Etherial after defeating Etheria, Borealis projectiles spawn twice as many Bysmal Blasts on hit");
        }

        public override void SetDefaults()
        {
            Item.scale *= 1.25f;
            Item.damage = 110;
            Item.DamageType = DamageClass.Melee;
            Item.width = 144;
            Item.height = 144;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10000;
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Borealis>();
            Item.shootSpeed = 18f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Aurora>(), 1);
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 5);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
        /*
        public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
        {
            if(!LaugicalityVars.ENPCs.Contains(target.type) && !LaugicalityVars.etherial.Contains(target.type) && target.damage > 0 && target.boss == false)
            {
                target.GetGlobalNPC<EtherialGlobalNPC>().etherial = true;
            }
            target.AddBuff(ModContent.BuffType<Frostbite>(), 2 * 60);
        }*/
    }
}
