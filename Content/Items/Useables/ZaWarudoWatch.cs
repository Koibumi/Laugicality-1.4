using Laugicality.Content.Buffs;
using Laugicality.Content.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities.Base;
using Laugicality.Utilities.Players;
using Terraria.Audio;

namespace Laugicality.Content.Items.Useables
{
    public class ZaWarudoWatch : LaugicalityItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The World");
            // Tooltip.SetDefault("'ZA WARUDO!'");
        }

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.value = 100;
            Item.rare = ItemRarityID.Pink;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.expert = true;
        }

        public override bool CanUseItem(Player player)
        {
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            return !modPlayer.zCool;
        }

        public override bool? UseItem(Player player)
        {
            SoundEngine.PlaySound(new SoundStyle("Laugicality/Sounds/zawarudo"), Item.position);
            LaugicalityPlayer modPlayer = LaugicalityPlayer.Get(player);
            if(Laugicality.zaWarudo < modPlayer.zaWarudoDuration)
            {
                Laugicality.zaWarudo = modPlayer.zaWarudoDuration;
                //LaugicalGlobalNPCs.zTime = modPlayer.zaWarudoDuration;
            }
            foreach ( Player player2 in Main.player){
                
            if (modPlayer.AndioChestguard == true)
                player.AddBuff(ModContent.BuffType<TimeExhausted>(), modPlayer.zCoolDown, true);
            else
                player.AddBuff(ModContent.BuffType<TimeExhausted>(), modPlayer.zCoolDown, true);
            }
            return true;
        }
    }
}