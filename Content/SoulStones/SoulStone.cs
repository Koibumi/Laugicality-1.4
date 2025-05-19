using System.Collections.Generic;
using Laugicality.Content.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Laugicality.Utilities;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;
using Terraria.Localization;

namespace Laugicality.Content.SoulStones
{
    public class SoulStone : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            // Tooltip.SetDefault("Absorbs the souls of powerful fallen creatures\nAn otherwordly entity seems to have sealed some of its power...");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.width = 30;
            Item.height = 28;
            Item.value = Item.buyPrice(silver: 20);
            Item.rare = ItemRarityID.Expert;

            Item.accessory = true;
        }

        public override bool CanEquipAccessory(Player player, int slot, bool modded) => base.CanEquipAccessory(player, slot, modded) && player.GetModPlayer<LaugicalityPlayer>().Focus != null;

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(tooltips);
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            if (laugicalityPlayer.Focus == null)
            {
                tooltips.Add(new TooltipLine(Mod, "SoulStoneNoPlayerFocus", Language.GetTextValue("Mods.Laugicality.Focus.SoulStone.SoulStoneTooltips1")) // You must select a Focus to use the Soul Stone!
                {
                    OverrideColor = Color.Red
                });
                return;
            }

            tooltips.Add(new TooltipLine(Laugicality.Instance, "SoulStoneDisplayFocusName", Language.GetTextValue("Mods.Laugicality.Focus.SoulStone.SoulStoneTooltips2") + laugicalityPlayer.Focus.DisplayName + '.') // Your focus is 
            {
                OverrideColor = laugicalityPlayer.Focus.AssociatedColor
            });

            for (int i = 0; i < laugicalityPlayer.Focus.EffectsCount; i++)
            {
                if (laugicalityPlayer.Focus.GetEffect(i).Condition(laugicalityPlayer))
                    tooltips.Add(laugicalityPlayer.Focus.GetEffect(i).Tooltip);
            }

            if(LaugicalityWorld.GetCurseCount() > 0)
            {
                tooltips.Add(new TooltipLine(Laugicality.Instance, "CurseLine", Language.GetTextValue("Mods.Laugicality.Focus.SoulStone.SoulStoneTooltips3")) // "----Curses----")
                {
                    OverrideColor = Color.Red
                });

                GetCurseTooltips(tooltips);
            }
        }

        private static void GetCurseTooltips(List<TooltipLine> tooltips)
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            for (int i = 0; i < LaugicalityWorld.GetCurseCount() && i < laugicalityPlayer.Focus.CursesCount; i++)
            {
                for (int j = 0; j < laugicalityPlayer.Focus.NemesesCount; j++)
                {
                    if (laugicalityPlayer.Focus.Nemeses[j].GetCurse(i).Condition(laugicalityPlayer))
                        tooltips.Add(laugicalityPlayer.Focus.Nemeses[j].GetCurse(i).Tooltip);
                }
            }

            for (int i = 0; i < Math.Floor((float)LaugicalityWorld.GetCurseCount() / 2f) && i < laugicalityPlayer.Focus.CursesCount; i++)
            {
                for (int j = 0; j < laugicalityPlayer.Focus.EnemiesCount; j++)
                {
                    if (laugicalityPlayer.Focus.Enemies[j].GetCurse(i).Condition(laugicalityPlayer))
                        tooltips.Add(laugicalityPlayer.Focus.Enemies[j].GetCurse(i).Tooltip);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (Main.LocalPlayer != player)
                return;

            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get(Main.LocalPlayer);

            if (laugicalityPlayer.Focus == null)
                return;

            for (int i = 0; i < laugicalityPlayer.Focus.EffectsCount; i++)
            {
                if (laugicalityPlayer.Focus.GetEffect(i).Condition(laugicalityPlayer))
                    laugicalityPlayer.Focus.GetEffect(i).Effect(laugicalityPlayer, hideVisual);
            }

            if(LaugicalityWorld.GetCurseCount() > 0)
                GetCurseEffects(player, hideVisual);
            base.UpdateAccessory(player, hideVisual);
        }

        private static void GetCurseEffects(Player player, bool hideVisual)
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get(player);

            for (int i = 0; i < LaugicalityWorld.GetCurseCount() && i < laugicalityPlayer.Focus.CursesCount; i++)
            {
                for (int j = 0; j < laugicalityPlayer.Focus.NemesesCount; j++)
                {
                    if (laugicalityPlayer.Focus.Nemeses[j].GetCurse(i).Condition(laugicalityPlayer))
                        laugicalityPlayer.Focus.Nemeses[j].GetCurse(i).Effect(laugicalityPlayer, hideVisual);
                }
            }

            for (int i = 0; i < Math.Floor((float)LaugicalityWorld.GetCurseCount() / 2f) && i < laugicalityPlayer.Focus.CursesCount; i++)
            {
                for (int j = 0; j < laugicalityPlayer.Focus.EnemiesCount; j++)
                {
                    if (laugicalityPlayer.Focus.Enemies[j].GetCurse(i).Condition(laugicalityPlayer))
                        laugicalityPlayer.Focus.Enemies[j].GetCurse(i).Effect(laugicalityPlayer, hideVisual);
                }
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LifeCrystal);
            recipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 10);
            recipe.AddTile(ModContent.TileType<Content.Tiles.AlchemicalInfuser>());
            recipe.Register();
        }
    }
}