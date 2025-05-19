using Terraria;
using Terraria.ModLoader;

namespace Laugicality.Utilities.Globals
{
    public class GlobalSpeed : GlobalItem
    {
        public bool _Speed = false;
        public override bool InstancePerEntity => true;

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (_Speed)
            {
                player.moveSpeed += 0.1f;
                player.maxRunSpeed += player.maxRunSpeed * 0.015f;
                player.accRunSpeed += 0.2f;
            }
        }
    }
}