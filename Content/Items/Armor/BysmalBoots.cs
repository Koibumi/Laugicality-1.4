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
	[AutoloadEquip(EquipType.Legs)]
	public class BysmalBoots : LaugicalityItem
	{
		public override void SetStaticDefaults()
		{
			// Tooltip.SetDefault("+15% Movement Speed\n+25% More Movement Speed and Max Run Speed when in the Etherial");
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 26;
			Item.value = 10000;
			Item.rare = ItemRarityID.Orange;
			Item.defense = 14;
		}

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.15f;
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if(modPlayer.Etherable > 0 || LaugicalityWorld.downedEtheria)
            {
                player.moveSpeed += 0.25f;
                player.maxRunSpeed += 1f;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}