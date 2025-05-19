using Terraria;
using Terraria.UI;
using Laugicality.Utilities.Players;

namespace Laugicality.Utilities.UI
{
    public class EnigmaMysticaInterface : GameInterfaceLayer
    {
        private readonly LaugicalityUI mysticaUI;

        public EnigmaMysticaInterface(LaugicalityUI mysticaUI) : base("Enigma: Mystica", InterfaceScaleType.UI)
        {
            this.mysticaUI = mysticaUI;
        }

        protected override bool DrawSelf()
        {
            LaugicalityPlayer laugicalityPlayer = LaugicalityPlayer.Get();

            if (laugicalityPlayer == null)
                return true;

            if (laugicalityPlayer.MysticHold > 0)
                mysticaUI.Draw(Main.spriteBatch);

            return true;
        }
    }
}