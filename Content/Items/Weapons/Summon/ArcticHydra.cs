using Laugicality.Content.Buffs;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Content.Projectiles.Summon;
using Laugicality.Utilities;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;

namespace Laugicality.Content.Items.Weapons.Summon
{
    public class ArcticHydra : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Arctic Hydra Staff");
            // Tooltip.SetDefault("'The beast of many Heads'\nWhen in the Etherial after defeating Etheria, Double Damage and Aggro range.");
        }

        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.DamageType = DamageClass.Summon;
            Item.mana = 16;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 36;
            Item.useAnimation = 36;
            Item.useStyle = 1;
            Item.noMelee = true;
            Item.knockBack = 3;
            Item.value = Item.buyPrice(0, 25, 0, 0);
            Item.rare = ItemRarityID.Lime;
            Item.UseSound = SoundID.Item44;
            Item.shoot = ModContent.ProjectileType<ArcticHydraHead>();
            Item.shootSpeed = 0;
            Item.buffType = ModContent.BuffType<Buffs.ArcticHydraBuff>();
            Item.buffTime = 60;
        }

        public override void HoldItem(Player player)
        {
            if ((LaugicalityWorld.downedEtheria || LaugicalityPlayer.Get(player).Etherable > 0) && LaugicalityWorld.downedTrueEtheria)
            {
                Item.damage = 200;
            }
            else
            {
                Item.damage = 100;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 14);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 6);
            recipe.AddIngredient(ItemID.StaffoftheFrostHydra);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}