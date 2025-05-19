using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Content.Items.Materials;

namespace Laugicality.Content.Items.Misc
{
    public class AncientScroll : LaugicalityItem
    {
        public override void Load()
        {
            string TableOfContents = this.GetLocalization("Tooltips.TableOfContents").Value;
            string TheMysticClass = this.GetLocalization("Tooltips.TheMysticClass").Value;
            string Mysticisms = this.GetLocalization("Tooltips.Mysticisms").Value;
            string Potentia = this.GetLocalization("Tooltips.Potentia").Value;
            string MysticDuration = this.GetLocalization("Tooltips.MysticDuration").Value;
            string Overflow = this.GetLocalization("Tooltips.Overflow").Value;
            string MysticBursts = this.GetLocalization("Tooltips.MysticBursts").Value;
            string PotentiaConversion = this.GetLocalization("Tooltips.PotentiaConversion").Value;
            string Origins = this.GetLocalization("Tooltips.Origins").Value;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 9;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 1;
            Item.useTime = 15;
            Item.useStyle = 1;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            string TableOfContents = this.GetLocalization("Tooltips.TableOfContents").Value;
            string TheMysticClass = this.GetLocalization("Tooltips.TheMysticClass").Value;
            string Mysticisms = this.GetLocalization("Tooltips.Mysticisms").Value;
            string Potentia = this.GetLocalization("Tooltips.Potentia").Value;
            string MysticDuration = this.GetLocalization("Tooltips.MysticDuration").Value;
            string Overflow = this.GetLocalization("Tooltips.Overflow").Value;
            string MysticBursts = this.GetLocalization("Tooltips.MysticBursts").Value;
            string PotentiaConversion = this.GetLocalization("Tooltips.PotentiaConversion").Value;
            string Origins = this.GetLocalization("Tooltips.Origins").Value;

            Player ttPlayer = Main.player[Main.myPlayer];
            string toolTip = "";
            switch(Item.stack)
            {
                case 1:
                    toolTip = TableOfContents;
                    break;
                case 2:
                    toolTip = TheMysticClass;
                    break;
                case 3:
                    toolTip = Mysticisms;
                    break;
                case 4:
                    toolTip = Potentia;
                    break;
                case 5:
                    toolTip = MysticDuration;
                    break;
                case 6:
                    toolTip = Overflow;
                    break;
                case 7:
                    toolTip = MysticBursts;
                    break;
                case 8:
                    toolTip = PotentiaConversion;
                    break;
                case 9:
                    toolTip = Origins;
                    break;
                default:
                    toolTip = TableOfContents;
                    break;
            }
            TooltipLine linePage = new TooltipLine(Mod, "", toolTip); tooltips.Add(linePage);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 1);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipeGroup(14);
            recipe.Register();
        }
    }
}