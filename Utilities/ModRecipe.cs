using Laugicality.Content.Items.Equipables;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Laugicality.Content.Items.Loot;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Tiles;
using Laugicality.Content.Items.Accessories;

namespace Laugicality.Utilities
{
    public class ModRecipe : ModSystem, ILocalizedModType
    {
        public string LocalizationCategory => "ModRecipeSystem";

        public static bool _steamsparkJetboots = false;
        public override void Load()
        {
            string Emblem = this.GetLocalization("Chat.Emblem").Value;
            string Gem = this.GetLocalization("Chat.Gem").Value;
            string GoldBar = this.GetLocalization("Chat.GoldBar").Value;
            string SilverBar = this.GetLocalization("Chat.SilverBar").Value;
            string TitaniumBar = this.GetLocalization("Chat.TitaniumBar").Value;
            string LargeGem = this.GetLocalization("Chat.LargeGem").Value;
            string DungeonTable = this.GetLocalization("Chat.DungeonTable").Value;
            string EvilBar = this.GetLocalization("Chat.EvilBar").Value;
            string DoubleJumpBottle = this.GetLocalization("Chat.DoubleJumpBottle").Value;
            string ColoredBalloon = this.GetLocalization("Chat.ColoredBalloon").Value;

        }
        public const string GOLD_BARS_GROUP = "GldBars";
        public const string EVIL_BARS_GROUP = "EnigmaEvilBars";
        public const string DOUBLE_JUMP_GROUP = "EnigmaDoubleJump";
        public const string COLORED_BALLOON_GROUP = "EnigmaColoredBalloon";

        #region Recipe Groups
        public override void AddRecipeGroups()
        {
            //Emblems
            string Emblem = this.GetLocalization("Chat.Emblem").Value;
            RecipeGroup.RegisterGroup("Emblems", new RecipeGroup(() => Lang.misc[37] + Emblem, new int[]
            {
                ItemID.RangerEmblem,
                ItemID.WarriorEmblem,
                ItemID.SorcererEmblem,
                ItemID.SummonerEmblem,
                //ModContent.ItemType<NullEmblem>(),
                ModContent.ItemType<MysticEmblem>(),
                ModContent.ItemType<NinjaEmblem>()
            }));


            //Gems
            string Gem = this.GetLocalization("Chat.Gem").Value;
            RecipeGroup.RegisterGroup("Gems", new RecipeGroup(() => Lang.misc[37] + Gem, new int[]
            {
                ItemID.Amethyst,
                ItemID.Topaz,
                ItemID.Ruby,
                ItemID.Sapphire,
                ItemID.Emerald,
                ItemID.Ruby,
                ItemID.Diamond,
                ItemID.Amber
            }));

            //Gold Bars
            string GoldBar = this.GetLocalization("Chat.GoldBar").Value;
            RecipeGroup.RegisterGroup(GOLD_BARS_GROUP, new RecipeGroup(() => Lang.misc[37] + GoldBar, new int[]
            {
                ItemID.GoldBar,
                ItemID.PlatinumBar
            }));

            //Silver Bars
            string SilverBar = this.GetLocalization("Chat.SilverBar").Value;
            RecipeGroup.RegisterGroup("SilverBars", new RecipeGroup(() => Lang.misc[37] + SilverBar, new int[]
            {
                ItemID.SilverBar,
                ItemID.TungstenBar
            }));

            //Titanium Bars
            string TitaniumBar = this.GetLocalization("Chat.TitaniumBar").Value;
            RecipeGroup.RegisterGroup("TitaniumBars", new RecipeGroup(() => Lang.misc[37] + TitaniumBar, new int[]
            {
                ItemID.TitaniumBar,
                ItemID.AdamantiteBar
            }));

            //Large Gems
            string LargeGem = this.GetLocalization("Chat.LargeGem").Value;
            RecipeGroup.RegisterGroup("LargeGems", new RecipeGroup(() => Lang.misc[37] + LargeGem, new int[]
            {
                ItemID.LargeAmethyst,
                ItemID.LargeTopaz,
                ItemID.LargeSapphire,
                ItemID.LargeEmerald,
                ItemID.LargeRuby,
                ItemID.LargeDiamond,
                ItemID.LargeAmber
            }));

            //Dungeon Tables
            string DungeonTable = this.GetLocalization("Chat.DungeonTable").Value;
            RecipeGroup.RegisterGroup("DungeonTables", new RecipeGroup(() => Lang.misc[37] + DungeonTable, new int[]
            {
                ItemID.GothicTable, //Gothic
                ItemID.BlueDungeonTable, //Blue
                ItemID.GreenDungeonTable, //Green
                ItemID.PinkDungeonTable  //Pink
            }));

            //Evil Bars
            string EvilBar = this.GetLocalization("Chat.EvilBar").Value;
            RecipeGroup.RegisterGroup(EVIL_BARS_GROUP, new RecipeGroup(() => Lang.misc[37] + EvilBar, new int[]
            {
                ItemID.DemoniteBar,
                ItemID.CrimtaneBar
            }));

            //DoubleJump
            string DoubleJumpBottle = this.GetLocalization("Chat.DoubleJumpBottle").Value;
            RecipeGroup.RegisterGroup(DOUBLE_JUMP_GROUP, new RecipeGroup(() => Lang.misc[37] + DoubleJumpBottle, new int[]
            {
                ItemID.CloudinaBottle,
                ItemID.SandstorminaBottle,
                ItemID.BlizzardinaBottle,
                ItemID.TsunamiInABottle
            }));

            //ColoredBalloon
            string ColoredBalloon = this.GetLocalization("Chat.ColoredBalloon").Value;
            RecipeGroup.RegisterGroup(COLORED_BALLOON_GROUP, new RecipeGroup(() => Lang.misc[37] + ColoredBalloon, new int[]
            {
                ItemID.BlueHorseshoeBalloon,
                ItemID.WhiteHorseshoeBalloon,
                ItemID.YellowHorseshoeBalloon,
                ItemID.BalloonHorseshoeFart,
                ItemID.BalloonHorseshoeHoney,
                ItemID.BalloonHorseshoeSharkron,
            }));
        }
        #endregion 

        #region New Recipe
        public override void AddRecipes()
        {
            Recipe warrecipe = Recipe.Create(ItemID.WarriorEmblem);
            warrecipe.AddRecipeGroup("Emblems");
            warrecipe.AddIngredient(ItemID.SoulofNight, 4);
            warrecipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 4);
            warrecipe.AddTile(TileID.MythrilAnvil);
            warrecipe.Register();

            Recipe ranrecipe = Recipe.Create(ItemID.RangerEmblem);
            ranrecipe.AddRecipeGroup("Emblems");
            ranrecipe.AddIngredient(ItemID.SoulofLight, 4);
            ranrecipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 4);
            ranrecipe.AddTile(TileID.MythrilAnvil);
            ranrecipe.Register();

            Recipe sorrecipe = Recipe.Create(ItemID.SorcererEmblem);
            sorrecipe.AddRecipeGroup("Emblems");
            sorrecipe.AddIngredient(ItemID.SoulofNight, 4);
            sorrecipe.AddIngredient(ItemID.SoulofLight, 4);
            sorrecipe.AddTile(TileID.MythrilAnvil);
            sorrecipe.Register();

            Recipe sumrecipe = Recipe.Create(ItemID.SummonerEmblem);
            sumrecipe.AddRecipeGroup("Emblems");
            sumrecipe.AddIngredient(ItemID.SoulofLight, 4);
            ranrecipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 4);
            sumrecipe.AddTile(TileID.MythrilAnvil);
            sumrecipe.Register();

            Recipe ninrecipe = Recipe.Create(ModContent.ItemType<NinjaEmblem>());
            ninrecipe.AddRecipeGroup("Emblems");
            ninrecipe.AddIngredient(ItemID.SoulofNight, 4);
            ranrecipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 4);
            ninrecipe.AddTile(TileID.MythrilAnvil);
            ninrecipe.Register();

            Recipe mysrecipe = Recipe.Create(ModContent.ItemType<MysticEmblem>());
            mysrecipe.AddRecipeGroup("Emblems");
            mysrecipe.AddIngredient(ModContent.ItemType<SoulOfHaught>(), 4);
            mysrecipe.AddIngredient(ModContent.ItemType<SoulOfSought>(), 4);
            mysrecipe.AddTile(TileID.MythrilAnvil);
            mysrecipe.Register();

            Recipe enchrecipe1 = Recipe.Create(ItemID.EnchantedSword);
            enchrecipe1.AddIngredient(ItemID.SilverBroadsword);
            enchrecipe1.AddIngredient(ModContent.ItemType<ArcaneShard>(), 12);
            enchrecipe1.AddIngredient(ModContent.ItemType<AquosDust>(), 6);
            enchrecipe1.AddIngredient(ModContent.ItemType<RubrumDust>(), 4);
            enchrecipe1.AddTile(ModContent.TileType<Content.Tiles.AlchemicalInfuser>());
            enchrecipe1.Register();

            Recipe enchrecipe2 = Recipe.Create(ItemID.EnchantedSword);
            enchrecipe2.AddIngredient(ItemID.TungstenBroadsword);
            enchrecipe1.AddIngredient(ModContent.ItemType<ArcaneShard>(), 12);
            enchrecipe1.AddIngredient(ModContent.ItemType<AquosDust>(), 6);
            enchrecipe1.AddIngredient(ModContent.ItemType<RubrumDust>(), 4);
            enchrecipe2.AddTile(ModContent.TileType<Content.Tiles.AlchemicalInfuser>());
            enchrecipe2.Register();

            Recipe starfuryrecipe = Recipe.Create(ItemID.Starfury);
            starfuryrecipe.AddRecipeGroup(ModRecipe.GOLD_BARS_GROUP, 12);
            starfuryrecipe.AddIngredient(ItemID.SunplateBlock, 24);
            starfuryrecipe.AddIngredient(ModContent.ItemType<ArcaneShard>(), 8);
            starfuryrecipe.AddIngredient(ModContent.ItemType<RegisDust>(), 6);
            starfuryrecipe.AddIngredient(ModContent.ItemType<AuraDust>(), 4);
            starfuryrecipe.AddTile(ModContent.TileType<Content.Tiles.AlchemicalInfuser>());
            starfuryrecipe.Register();

            Recipe golemcellrecipe = Recipe.Create(ItemID.LihzahrdPowerCell);
            golemcellrecipe.AddIngredient(2766, 4); //Solar Tablet Fragment
            golemcellrecipe.AddIngredient(ItemID.HallowedBar, 1);
            golemcellrecipe.AddTile(ModContent.TileType<Content.Tiles.AncientEnchanter>());
            golemcellrecipe.Register();

            Recipe _ArcaneShard = Recipe.Create(ItemID.FallenStar);
            _ArcaneShard.AddIngredient(ItemID.Cloud, 10);
            _ArcaneShard.AddIngredient(ModContent.ItemType<ArcaneShard>());
            _ArcaneShard.AddTile(ModContent.TileType<AlchemicalInfuser>());
            _ArcaneShard.Register();

            Recipe _LaugicalWorkbench = Recipe.Create(3119);
            _LaugicalWorkbench.AddTile(114);
            _LaugicalWorkbench.AddIngredient(3202);
            _LaugicalWorkbench.AddIngredient(583);
            _LaugicalWorkbench.Register();

            Recipe _Lycoris = Recipe.Create(ModContent.ItemType<Content.Items.Placeable.Lycoris>(), 4);
            _Lycoris.AddTile(TileID.Hellforge);
            _Lycoris.AddIngredient(ModContent.ItemType<Content.Items.Placeable.LavaGem>());
            _Lycoris.AddIngredient(ModContent.ItemType<Content.Items.Placeable.ObsidiumRock>(), 4);
            _Lycoris.Register();

            Recipe _ObsidiumPlant = Recipe.Create(ItemID.LifeCrystal);
            _ObsidiumPlant.AddTile(TileID.Hellforge);
            _ObsidiumPlant.AddIngredient(ModContent.ItemType<Content.Items.Placeable.LavaGem>(), 4);
            _ObsidiumPlant.AddIngredient(ModContent.ItemType<Content.Items.Placeable.ObsidiumOre>(), 8);
            _ObsidiumPlant.AddIngredient(ModContent.ItemType<RubrumDust>(), 4);
            _ObsidiumPlant.Register();

            Recipe _ObsidiumPlant2 = Recipe.Create(ItemID.LifeCrystal);
            _ObsidiumPlant2.AddTile(TileID.Hellforge);
            _ObsidiumPlant2.AddIngredient(ModContent.ItemType<Content.Items.Placeable.LavaGem>(), 4);
            _ObsidiumPlant2.AddIngredient(ItemID.Hellstone, 8);
            _ObsidiumPlant2.AddIngredient(ModContent.ItemType<RubrumDust>(), 4);
            _ObsidiumPlant2.Register();

            Recipe _EtherialEssence = Recipe.Create(ItemID.TruffleWorm);
            _EtherialEssence.AddTile(TileID.DemonAltar);
            _EtherialEssence.AddIngredient(ModContent.ItemType<EtherialEssence>(), 10);
            _EtherialEssence.Register();

            Recipe _ShadowFlameKnife = Recipe.Create(ItemID.ShadowFlameKnife);
            _ShadowFlameKnife.AddIngredient(ModContent.ItemType<Shadowflame>(), 4);
            _ShadowFlameKnife.AddIngredient(ItemID.MagicDagger);
            _ShadowFlameKnife.AddTile(TileID.MythrilAnvil);
            _ShadowFlameKnife.Register();

            Recipe _ShadowFlameBow = Recipe.Create(ItemID.ShadowFlameBow);
            _ShadowFlameBow.AddIngredient(ModContent.ItemType<Shadowflame>(), 4);
            _ShadowFlameBow.AddIngredient(ItemID.HellwingBow);
            _ShadowFlameBow.AddTile(TileID.MythrilAnvil);
            _ShadowFlameBow.Register();


            Recipe _ShadowFlameHexDoll = Recipe.Create(ItemID.ShadowFlameHexDoll);
            _ShadowFlameHexDoll.AddIngredient(ModContent.ItemType<Shadowflame>(), 4);
            _ShadowFlameHexDoll.AddTile(TileID.MythrilAnvil);
            _ShadowFlameHexDoll.AddIngredient(ItemID.BookofSkulls);
            _ShadowFlameHexDoll.Register();

            Recipe _ShadowflameHadesDye = Recipe.Create(ItemID.ShadowflameHadesDye);
            _ShadowflameHadesDye.AddIngredient(ModContent.ItemType<Shadowflame>());
            _ShadowflameHadesDye.AddIngredient(ItemID.DyeVat);
            _ShadowflameHadesDye.AddTile(TileID.MythrilAnvil);
            _ShadowflameHadesDye.Register();

            Recipe wWrecipe = Recipe.Create(863);
            wWrecipe.AddIngredient(54);
            wWrecipe.AddIngredient(ModContent.ItemType<WaterWalkingGem>());
            wWrecipe.AddTile(114);
            wWrecipe.Register();

            Recipe hrecipe = Recipe.Create(2422);
            hrecipe.AddIngredient(ModContent.ItemType<ObsidiumBar>(), 8);
            hrecipe.AddTile(77);
            hrecipe.Register();

            Recipe recipe1 = Recipe.Create(50);
            recipe1.AddIngredient(170, 8); //Glass
            recipe1.AddIngredient(ModContent.ItemType<RecallGem>());
            recipe1.AddIngredient(109); //Mana Crystal
            recipe1.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe1.Register();

            Recipe recipe2 = Recipe.Create(3199);
            recipe2.AddIngredient(170, 8); //Glass
            recipe2.AddIngredient(664, 8); //Ice
            recipe2.AddIngredient(ModContent.ItemType<RecallGem>());
            recipe2.AddIngredient(109); //Mana Crystal
            recipe2.AddTile(ModContent.TileType<AlchemicalInfuser>());
            recipe2.Register();

            Recipe _GoldenKey = Recipe.Create(ItemID.GoldenKey);
            _GoldenKey.AddRecipeGroup(GOLD_BARS_GROUP, 4);
            _GoldenKey.AddIngredient(ItemID.Bone);
            _GoldenKey.AddTile(TileID.Hellforge);
            _GoldenKey.Register();

            if (_steamsparkJetboots)
            {
                Recipe _SteamsparkJetboots = Recipe.Create(ModContent.ItemType<SteamsparkJetboots>());
                _SteamsparkJetboots.AddIngredient(ModContent.ItemType<HyperwarpLightboots>(), 1);
                _SteamsparkJetboots.AddIngredient(ItemID.Jetpack, 1);
                _SteamsparkJetboots.AddIngredient(ModContent.ItemType<SteamBar>(), 16);
                _SteamsparkJetboots.AddIngredient(ModContent.ItemType<Gear>(), 25);
                _SteamsparkJetboots.AddTile(TileID.MythrilAnvil);
                _SteamsparkJetboots.Register();
            }

            Recipe _SkyMill = Recipe.Create(ItemID.SkyMill);
            _SkyMill.AddIngredient(ItemID.SunplateBlock, 20);
            _SkyMill.AddTile(ModContent.TileType<LaugicalWorkbench>());
            _SkyMill.Register();

            Recipe _LihzahrdPowerCell = Recipe.Create(ItemID.LihzahrdPowerCell);
            _LihzahrdPowerCell.AddIngredient(ModContent.ItemType<EtherialEssence>(), 5);
            _LihzahrdPowerCell.AddTile(TileID.DemonAltar);
            _LihzahrdPowerCell.Register();
        }
        #endregion
    }
}