using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using System.IO;
using WebmilioCommonsAddon.Networking;
using Laugicality.Utilities.UI;
using Laugicality.Utilities.Etherial;
using Laugicality.Content.Items.Placeable.MusicBoxes;

namespace Laugicality
{
	public class Laugicality : Mod
	{
        internal static ModKeybind toggleMystic, toggleSoulStoneV, toggleSoulStoneM, quickMystica, soulStoneAbility, restockNearby;

        public static int zaWarudo = 0;
        public Laugicality()
        {
            Instance = this;

        }
        public override void Load()
        {
            zaWarudo = 0;

            if (!Main.dedServ)
            {
                //Foreground Filter (RGB)
                Filters.Scene["Laugicality:Etherial"] = new Filter(new EtherialShader("FilterMiniTower").UseColor(0.1f, 0.4f, 1.0f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Laugicality:Etherial"] = new EtherialVisual();
                Filters.Scene["Laugicality:Etherial2"] = new Filter(new ScreenShaderData("FilterBloodMoon").UseColor(0f, 2f, 8f).UseOpacity(0.8f), EffectPriority.VeryHigh);
                Filters.Scene["Laugicality:ZaWarudo"] = new Filter(new ZaShader("FilterMiniTower").UseColor(0.5f, .5f, .5f).UseOpacity(0.5f), EffectPriority.VeryHigh);
                SkyManager.Instance["Laugicality:ZaWarudo"] = new ZaWarudoVisual();

                // Register a new music box
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/DuneSharkron"), ModContent.ItemType<DuneSharkronMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.DuneSharkronMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/Obsidium"), ModContent.ItemType<AmelderaMusicBoxItem>(), ModContent.TileType<Content.Tiles.MusicBoxes.AmelderaMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/ObsidiumSurface"), ModContent.ItemType<AmelderaSurfaceMusicBoxItem>(), ModContent.TileType<Content.Tiles.MusicBoxes.AmelderaSurfaceMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/AnDio"), ModContent.ItemType<AnDioMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.AnDioMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/Annihilator"), ModContent.ItemType<AnnihilatorMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.AnnihilatorMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/RockPhase3"), ModContent.ItemType<DioritusMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.DioritusMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/ObsidiumSurfaceClon"), ModContent.ItemType<GreatShadowMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.GreatShadowMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/Etheria"), ModContent.ItemType<EtheriaMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.EtheriaMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/Hypothema"), ModContent.ItemType<HypothemaMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.HypothemaMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/ObsidiumClone"), ModContent.ItemType<ObsidiumMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.ObsidiumMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/Ragnar"), ModContent.ItemType<RagnarMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.RagnarMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/Slybertron"), ModContent.ItemType<SlybertronMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.SlybertronMusicBox>(), 0);
                MusicLoader.AddMusicBox(this, MusicLoader.GetMusicSlot("Laugicality/Sounds/Music/SteamTrain"), ModContent.ItemType<SteamTrainMusicBox>(), ModContent.TileType<Content.Tiles.MusicBoxes.SteamTrainMusicBox>(), 0);

                MysticaUI = new LaugicalityUI();
                MysticaUI.Activate();
                MysticaUI.Load();
                MysticaUserInterface = new UserInterface();
                MysticaUserInterface.SetState(MysticaUI);
            }

            toggleMystic = KeybindLoader.RegisterKeybind(this, "Toggle Mysticism", "Mouse2");
            toggleSoulStoneV = KeybindLoader.RegisterKeybind(this, "Toggle Visual Effects", "V");
            toggleSoulStoneM = KeybindLoader.RegisterKeybind(this, "Toggle Mobility Effects", "C");
            quickMystica = KeybindLoader.RegisterKeybind(this, "Quick Mystica", "G");
            soulStoneAbility = KeybindLoader.RegisterKeybind(this, "Soul Stone Ability", "Mouse3");
            restockNearby = KeybindLoader.RegisterKeybind(this, "Restock from Nearby Chests", "N");
        }
        public override void Unload()
        {
            Instance = null;

            MysticaUI.Unload();
            MysticaUserInterface = null;
        }
        public override void HandlePacket(BinaryReader reader, int whoAmI)
        {
            NetworkPacketLoader.Instance.HandlePacket(reader, whoAmI);
        }

        enum EnigmaMessageType : byte
        {
            ZaWarudoTime,
        }
        public override void Close()
        {
            base.Close();
        }
        public static Laugicality Instance { get; private set; }
        public UserInterface MysticaUserInterface { get; private set; }
        public LaugicalityUI MysticaUI { get; private set; }
    }
}
