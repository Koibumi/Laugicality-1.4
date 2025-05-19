using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Content.Tiles;
using Laugicality.Utilities;
using Laugicality.Utilities.Players;
using Laugicality.Utilities.Base;
using Microsoft.Xna.Framework;
using Laugicality.Content.Dusts;
using Terraria.Audio;

namespace Laugicality.Content.Items.Useables
{
    public class SoulOfTheAncients : LaugicalityItem
    {
        public override void Load()
        {
            string SoulOfTheAncientsI = this.GetLocalization("Chat.SoulOfTheAncientsI").Value; // You stored part of your Soul in the Vase.
            string SoulOfTheAncientsII = this.GetLocalization("Chat.SoulOfTheAncientsII").Value; // Your soul has been released.
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Soul of the Ancients");
            // Tooltip.SetDefault("Seal away a part of your Soul.\nUsing this item prevents you from unleashing Mystic Bursts, but increases Mystic Damage by 5%.");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.value = 100;
            Item.rare = ItemRarityID.Pink;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
        }

        public override bool? UseItem(Player player)
        {
            string SoulOfTheAncientsI = this.GetLocalization("Chat.SoulOfTheAncientsI").Value; 
            string SoulOfTheAncientsII = this.GetLocalization("Chat.SoulOfTheAncientsII").Value; 

            SoundEngine.PlaySound(new SoundStyle("Laugicality/Sounds/SoulStore"), Item.position);
            LaugicalityPlayer.Get(player).MysticBurstDisabled = !LaugicalityPlayer.Get(player).MysticBurstDisabled;
            if (LaugicalityPlayer.Get(player).MysticBurstDisabled)
                Main.NewText(SoulOfTheAncientsI, 150, 100, 0);
            else
                Main.NewText(SoulOfTheAncientsII, 150, 100, 0);
            for (int i = 0; i < 12; i++)
            {
                Dust.NewDust(player.position + player.velocity, player.width, player.height, ModContent.DustType<Sandy>(), 0f, 0f);
            }
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(20, 0);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AncientShard>(), 2);
            recipe.AddIngredient(ModContent.ItemType<Crystilla>(), 8);
            recipe.AddIngredient(ItemID.SandBlock, 40);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
        }
    }
}