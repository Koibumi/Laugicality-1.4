using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Items.Loot;
using Laugicality.Utilities.Players;
using Laugicality.Utilities;

namespace Laugicality.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class BysmalMask : LaugicalityItem
	{
        public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("+10% Damage \n+10% Additional Damage when in the Etherial");
		}

		public override void SetDefaults()
		{
			Item.width = 34;
			Item.height = 22;
			Item.value = 10000;
			Item.rare = ItemRarityID.LightPurple;
			Item.defense = 16;
		}
        
        public override void UpdateEquip(Player player)
        {
            float dmgBoost = .1f;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if (modPlayer.Etherable > 0|| LaugicalityWorld.downedEtheria)
                dmgBoost += .1f;

            player.GetDamage(DamageClass.Generic) += dmgBoost;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 15);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}