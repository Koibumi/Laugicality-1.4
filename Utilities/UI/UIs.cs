using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace Laugicality.Utilities.UI
{
    public class UIs : ModSystem
    {
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));

            if (mouseTextIndex != -1 && Laugicality.Instance?.MysticaUserInterface?.CurrentState != null)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "Enigma: Mystica",
                    delegate
                    {
                        Laugicality.Instance.MysticaUI.Draw(Main.spriteBatch);
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }
    }
}