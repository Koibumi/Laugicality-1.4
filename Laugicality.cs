using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using System.IO;
using WebmilioCommonsAddon.Networking;
using Laugicality.Utilities.UI;
using Laugicality.Utilities.Etherial;

namespace Laugicality
{
	public class Laugicality : Mod
	{
        public static Mod Calamity;

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
                /*AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/DuneSharkron"), ModContent.ItemType<DuneSharkronMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.DuneSharkronMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Hypothema"), ModContent.ItemType<HypothemaMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.HypothemaMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Obsidium"), ModContent.ItemType<ObsidiumMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.ObsidiumMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Ragnar"), ModContent.ItemType<RagnarMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.RagnarMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/RockPhase3"), ModContent.ItemType<DioritusMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.DioritusMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/AnDio"), ModContent.ItemType<AnDioMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.AnDioMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Annihilator"), ModContent.ItemType<AnnihilatorMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.AnnihilatorMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Slybertron"), ModContent.ItemType<SlybertronMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.SlybertronMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/SteamTrain"), ModContent.ItemType<SteamTrainMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.SteamTrainMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Etheria"), ModContent.ItemType<EtheriaMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.EtheriaMusicBox>());
                AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/ObsidiumSurface"), ModContent.ItemType<GreatShadowMusicBox>(), ModContent.TileType<Tiles.MusicBoxes.GreatShadowMusicBox>());*/
                //AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Obsidium"), ModContent.ItemType<AmelderaMusicBoxItem>(), ModContent.TileType<Tiles.MusicBoxes.AmelderaMusicBox>());
                //AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/ObsidiumSurface"), ModContent.ItemType<AmelderaSurfaceMusicBoxItem>(), ModContent.TileType<Tiles.MusicBoxes.AmelderaSurfaceMusicBox>());


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
            Calamity = null;

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
