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
    public class BysmalKey : LaugicalityItem
    {
        public override void Load()
        {
            string BysmalKeyI = this.GetLocalization("Chat.BysmalKeyI").Value; // Your Bysmal Armor has been locked, and won't absorb any more bonuses.
            string BysmalKeyII = this.GetLocalization("Chat.BysmalKeyII").Value; // Your Bysmal Armor has been unlocked, and will absorb bonuses again. 
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Bysmal Key");
            // Tooltip.SetDefault("Prevent Bysmal Armor from cycling in new Bonuses until toggled on again.");
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
            string BysmalKeyI = this.GetLocalization("Chat.BysmalKeyI").Value;
            string BysmalKeyII = this.GetLocalization("Chat.BysmalKeyII").Value;
            SoundEngine.PlaySound(new SoundStyle("Laugicality/Sounds/EtherialChange"), Item.position);
            LaugicalityPlayer.Get(player).BysmalAbsorbDisabled = !LaugicalityPlayer.Get(player).BysmalAbsorbDisabled;
            if (LaugicalityPlayer.Get(player).BysmalAbsorbDisabled)
                Main.NewText(BysmalKeyI, 0, 100, 150);
            else
                Main.NewText(BysmalKeyII, 0, 100, 150);
            for (int i = 0; i < 12; i++)
            {
                Dust.NewDust(player.position + player.velocity, player.width, player.height, ModContent.DustType<EtherialDust>(), 0f, 0f);
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
            recipe.AddIngredient(ModContent.ItemType<BysmalBar>(), 4);
            recipe.AddIngredient(ModContent.ItemType<EtherialEssence>(), 2);
            recipe.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe.Register();
        }
    }
}