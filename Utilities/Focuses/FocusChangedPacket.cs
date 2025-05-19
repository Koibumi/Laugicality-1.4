using System.IO;
using Terraria;
using Laugicality.Utilities.Players;
using Laugicality.Utilities;

using WebmilioCommons.Packets;

namespace Laugicality.Utilities.Focuses
{
    public class FocusChangedPacket : ModPlayerNetworkPacket<LaugicalityPlayer>
    {
        protected override bool PostReceive(BinaryReader reader, int fromWho)
        {
            Main.NewText($"Player {Player.name} now has focus {ModPlayer.Focus.DisplayName}");

            return true;
        }


        public string Focus
        {
            get => ModPlayer.Focus == null ? "" : ModPlayer.Focus.UnlocalizedName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    return;

                //ModPlayer.Focus = FocusManager.Instance[value];
            }
        }
    }
}