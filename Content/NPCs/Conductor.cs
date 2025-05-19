using Laugicality.Content.Dusts;
using Laugicality.Content.Items.Consumables;
using Laugicality.Content.Items.Equipables;
using Laugicality.Content.Items.Materials;
using Laugicality.Content.Projectiles.NPCProj;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Laugicality.Utilities;
using Laugicality.Utilities.Players;
using WebmilioCommonsAddon.UI.Slots;


namespace Laugicality.Content.NPCs
{
	[AutoloadHead]
	public class Conductor : ModNPC
	{
        public override void Load()
        {
            string ConductorSay = this.GetLocalization("Chat.ConductorSay").Value; // Heyo
            string ConductorSay1 = this.GetLocalization("Chat.ConductorSay1").Value; // How're you enjoying Enigma so far? I mean uh- ahem... Trains?
            string ConductorSay2 = this.GetLocalization("Chat.ConductorSay2").Value; // Oh, you aren't one of those 'Mystics' are you? The Moldyrians have such an ancient way of thinking. Steam power is where it's at!
            string ConductorSay3 = this.GetLocalization("Chat.ConductorSay3").Value; // "Oh, of course. My wares are much more valueable than that
            string ConductorSay4 = this.GetLocalization("Chat.ConductorSay4").Value; // 's.
            string ConductorSay5 = this.GetLocalization("Chat.ConductorSay5").Value; // I bet 
            string ConductorSay6 = this.GetLocalization("Chat.ConductorSay6").Value; // hasn't even invented a sentient machine yet!
            string ConductorSay71 = this.GetLocalization("Chat.ConductorSay7").Value; // A jetpack? Please. Tell 
            string ConductorSay72 = this.GetLocalization("Chat.ConductorSay8").Value; // those went out of style a few centuries ago. Jetboots are the best you can get! Besides trains, of course.

            string ConductorSay7 = this.GetLocalization("Chat.ConductorSay7").Value; // Spiffing!
            string ConductorSay8 = this.GetLocalization("Chat.ConductorSay8").Value; // Trains are all the rage in Vetruvia these days.
            string ConductorSay9 = this.GetLocalization("Chat.ConductorSay9").Value; // A train ride a day keeps the Steam Train away!
            string ConductorSay10 = this.GetLocalization("Chat.ConductorSay10").Value; // All aboard!
            string ConductorSay11 = this.GetLocalization("Chat.ConductorSay11").Value; // I wonder what happened to all of the Moldyrians. You wouldn't happen to have seen one recently, would you?
            string ConductorSay12 = this.GetLocalization("Chat.ConductorSay12").Value; // 'What is the meaning of life?' I, for one, think the answer probably involves lots of steam.
            string ConductorSay13 = this.GetLocalization("Chat.ConductorSay13").Value; // Hm? How did I get these items that call giant mechanical abominations at a whim? Through the power of Steam, of course!
            string ConductorSay14 = this.GetLocalization("Chat.ConductorSay14").Value; // Would you like to talk about Trains?
        }

        int _chatIndex = 0;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Conductor");
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 1000;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
        }

        public override void SetDefaults()
		{
            _chatIndex = 0;
            NPC.townNPC = true;
			NPC.friendly = true;
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 50;
			NPC.defense = 15;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;
			AnimationType = NPCID.Guide;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			int num = NPC.life > 0 ? 1 : 5;
			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<Steam>());
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs)
		{
            if (LaugicalityWorld.downedAnnihilator && LaugicalityWorld.downedSlybertron && LaugicalityWorld.downedSteamTrain)
            {
                return true;
            }
			return false;
		}
        public override List<string> SetNPCNameList() => new List<string>()
        {
            this.GetLocalizedValue("Name.LordCharles_III"),
            this.GetLocalizedValue("Name.SirChristopher"),
            this.GetLocalizedValue("Name.EarlCrane"),
            this.GetLocalizedValue("Name.LordCrimblesworth"),
            this.GetLocalizedValue("Name.BaronChester_von_Kingsly"),
            this.GetLocalizedValue("Name.Laugic"),
        };

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
            string ConductorSay = this.GetLocalization("Chat.ConductorSay").Value; // Heyo
            string ConductorSay1 = this.GetLocalization("Chat.ConductorSay1").Value; // How're you enjoying Enigma so far? I mean uh- ahem... Trains?
            string ConductorSay2 = this.GetLocalization("Chat.ConductorSay2").Value; // Oh, you aren't one of those 'Mystics' are you? The Moldyrians have such an ancient way of thinking. Steam power is where it's at!
            string ConductorSay3 = this.GetLocalization("Chat.ConductorSay3").Value; // "Oh, of course. My wares are much more valueable than that
            string ConductorSay4 = this.GetLocalization("Chat.ConductorSay4").Value; // 's.
            string ConductorSay5 = this.GetLocalization("Chat.ConductorSay5").Value; // I bet 
            string ConductorSay6 = this.GetLocalization("Chat.ConductorSay6").Value; // hasn't even invented a sentient machine yet!
            string ConductorSay71 = this.GetLocalization("Chat.ConductorSay71").Value; // A jetpack? Please. Tell 
            string ConductorSay72 = this.GetLocalization("Chat.ConductorSay72").Value; // those went out of style a few centuries ago. Jetboots are the best you can get! Besides trains, of course.

            string ConductorSay7 = this.GetLocalization("Chat.ConductorSay7").Value; // Spiffing!
            string ConductorSay8 = this.GetLocalization("Chat.ConductorSay8").Value; // Trains are all the rage in Vetruvia these days.
            string ConductorSay9 = this.GetLocalization("Chat.ConductorSay9").Value; // A train ride a day keeps the Steam Train away!
            string ConductorSay10 = this.GetLocalization("Chat.ConductorSay10").Value; // All aboard!
            string ConductorSay11 = this.GetLocalization("Chat.ConductorSay11").Value; // I wonder what happened to all of the Moldyrians. You wouldn't happen to have seen one recently, would you?
            string ConductorSay12 = this.GetLocalization("Chat.ConductorSay12").Value; // 'What is the meaning of life?' I, for one, think the answer probably involves lots of steam.
            string ConductorSay13 = this.GetLocalization("Chat.ConductorSay13").Value; // Hm? How did I get these items that call giant mechanical abominations at a whim? Through the power of Steam, of course!
            string ConductorSay14 = this.GetLocalization("Chat.ConductorSay14").Value; // Would you like to talk about Trains?

            int steampunker = NPC.FindFirstNPC(NPCID.Steampunker);

            _chatIndex++;

            if (SetNPCNameList().Contains("Laugic") && _chatIndex % 9 == 0)
                return ConductorSay + Main.LocalPlayer.name + ConductorSay1;
            if (LaugicalityPlayer.Get().MysticDamage > 1 && _chatIndex % 10 == 0)
                return ConductorSay2;


            if (steampunker >= 0 && Main.rand.Next(3) == 0)
			{
                switch (_chatIndex % 3)
                {
                    case 0:
				        return ConductorSay3 + Main.npc[steampunker].GivenName + ConductorSay4;
                    case 1:
                        return ConductorSay5 + Main.npc[steampunker].GivenName + ConductorSay6;
                    default:
                        return ConductorSay71 + Main.npc[steampunker].GivenName + ConductorSay72;
                }
			}

			switch (_chatIndex % 8)
			{
				case 0:
					return ConductorSay7;
                case 1:
                    return ConductorSay8;
                case 2:
                    return ConductorSay9;
                case 3:
                    return ConductorSay10;
                case 4:
                    return ConductorSay11;
                case 5:
                    return ConductorSay12;
                case 6:
                    return ConductorSay13;
                default:
					return ConductorSay14;
			}
		}

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28].Value;
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
                shopName = "ConductorShop";
        }

        public override void AddShops()
        {
            NPCShop shop = new(Type, "ConductorShop");
            shop.Add(ModContent.ItemType<Gear>());
            shop.Add(ModContent.ItemType<ToyTrain>());
            shop.Add(new Item(544) { shopCustomPrice = Item.buyPrice(gold: 5) });
            shop.Add(new Item(556) { shopCustomPrice = Item.buyPrice(gold: 5) });
            shop.Add(new Item(557) { shopCustomPrice = Item.buyPrice(gold: 5) });
            shop.Add(new Item(ModContent.ItemType<MechanicalMonitor>()) { shopCustomPrice = Item.buyPrice(gold: 6) });
            shop.Add(new Item(ModContent.ItemType<SteamCrown>()) { shopCustomPrice = Item.buyPrice(gold: 6) });
            shop.Add(new Item(ModContent.ItemType<SuspiciousTrainWhistle>()) { shopCustomPrice = Item.buyPrice(gold: 6) });
            shop.Register();
        }

        public override void ModifyActiveShop(string shopName, Item[] items)
		{

        }

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 50;
			knockback = 4f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 12;
			randExtraCooldown = 30;
		}

		public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
		{
			projType = ModContent.ProjectileType<ConductorProjectile>();
			attackDelay = 1;
		}

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 1f;
		}
	}
}