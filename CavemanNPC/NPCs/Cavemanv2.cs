using System;
using CavemanNPC;
//using CavemanNPC.Buffs;
using CavemanNPC.Dusts;
using CavemanNPC.NPCs;
using CavemanNPC.Projectiles;
using CavemanNPC.Items.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

		/* Checks
		downedMechBossAny = true/false;
		downedMechBoss1/2/3 = true/false;
		downedBoss1/2/3 = true/false;
		downedQueenBee = true/false;
		downedSlimeKing = true/false;
		downedGoblins = true/false;
		downedFrost = true/false;
		downedPirates = true/false;
		downedClown = true/false;
		downedPlantBoss = true/false;
		downedGolemBoss = true/false;
		downedMartians = true/false;
		downedFishron = true/false;
		downedHalloweenTree = true/false;
		downedHalloweenKing = true/false;
		downedChristmanIceQueen = true/false;
		downedChristmasTree = true/false;
		downedChristmasSantank = true/false;
		downedAncientCultist = true/false;
		downedMoonLord = true/false;
		downedTowerSolar = true/false;
		downedTowerVortex = true/false;
		downedTowerNebula = true/false;
		downedTowerStardust = true/false;		
		*/

namespace CavemanNPC.NPCs
{
		[AutoloadHead] // Must have for custom NPCs
		public class Caveman : ModNPC
		{
			public override string Texture => "CavemanNPC/NPCs/Caveman";
			
			public override string[] AltTextures => new[] { "CavemanNPC/NPCs/Caveman_Alt_1" };
			
			public override bool Autoload(ref string name) {
				name = "Caveman";
				return mod.Properties.Autoload;
			}
			
			public override void SetStaticDefaults() {
			DisplayName.SetDefault("Caveman");
			Main.npcFrameCount[npc.type] = 25;
			NPCID.Sets.ExtraFramesCount[npc.type] = 9;
			NPCID.Sets.AttackFrameCount[npc.type] = 4;
			NPCID.Sets.DangerDetectRange[npc.type] = 100;
			NPCID.Sets.AttackType[npc.type] = 3;
			NPCID.Sets.AttackTime[npc.type] = 30;
			NPCID.Sets.AttackAverageChance[npc.type] = 10;
			NPCID.Sets.HatOffsetY[npc.type] = 4;
		}
		
		public override void SetDefaults() {
			npc.townNPC = true;
			npc.friendly = true;
			npc.width = 18;
			npc.height = 40;
			npc.aiStyle = 7;
			npc.damage = 15;
			npc.defense = 20;
			npc.lifeMax = 250;
			npc.HitSound = SoundID.DD2_OgreHurt;
			npc.DeathSound = SoundID.DD2_JavelinThrowersDeath;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedSlimeKing == true); {
				return true;
			}
			return false;
        }
	//} // Un-comment if using downedBoss1

		public override string TownNPCName() {
			switch (WorldGen.genRand.Next(2)) {
				case 0:
					return "Rokk";
				default:
					return "Rokk";
			}
		}
		
		public override string GetChat() {
			int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
			if (partyGirl >= 0 && Main.rand.NextBool(4)) {
				return Main.npc[partyGirl].GivenName + " is ooga booga!";
			} 
			int Wizard = NPC.FindFirstNPC(NPCID.Wizard);
			if (Wizard >= 0 && Main.rand.NextBool(4)) {
				return Main.npc[Wizard].GivenName + " is big brain.";
			}
			int Merchant = NPC.FindFirstNPC(NPCID.Merchant);
			if (Merchant >= 0 && Main.rand.NextBool(4)) {
				return Main.npc[Merchant].GivenName + " has shiny pebble rocks.";
			}
			int ArmsDealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
			if (ArmsDealer >= 0 && Main.rand.NextBool(4)) {
				return Main.npc[ArmsDealer].GivenName + " has scary boom stick.";
			}
			// Old Chat Options
			/*switch (Main.rand.Next(4)) {
				case 0:
					return "I big strong, you small weak.";
				case 1:
					return "Me once find big rock. Me now lost big rock.";
				case 2:
					return "How I get home? I scared of strange land.";
				case 3:
					return "I give you Wooden Club, good price.";
				default:
					return "Have you seen Big Chungus? Scary rabbit!";
			}*/
			// New Chat Options
			WeightedRandom<string> chat = new WeightedRandom<string>();
			chat.Add("I big strong, you small weak.", 5.0);
			chat.Add("How I get home? I scared of strange land.", 10.0);
			chat.Add("Have you seen Big Chungus? Scary rabbit!", 0.1);
			chat.Add("I give you Wooden Club, good price.", 3.0);
			return chat.Get();
		}
		
		public override void SetChatButtons(ref string button, ref string button2) {
			button = Language.GetTextValue("LegacyInterface.28");
		}
		
		public override void OnChatButtonClicked(bool firstButton, ref bool shop) {
			if (firstButton) {
				Main.playerInventory = true;
				shop = true;
			}
		}
		
		// 1 = 1 copper, 100 = 1 silver, 1000 = 10 silver, 10000 = 1 gold
		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ItemID.Leather);
			shop.item[nextSlot].shopCustomPrice = 100;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.TigerSkin);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.LeopardSkin);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.ZebraSkin);
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.WoodenClub>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.StoneJavelin>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Weapons.StoneSpear>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.PetRock>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.ChungusMusicBox>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Placeable.SkeletronMusicBox>());
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemID.BoneJavelin);
			shop.item[nextSlot].shopCustomPrice = 200;
			nextSlot++;
			shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.SpaceDude>());
			nextSlot++;
		}
			
		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 80;
			knockback = 4f;
		}
		
		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 3;
			randExtraCooldown = 15;
		}
		
		// Magic Attack
		/*
		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileType<SparklingBall>();
			attackDelay = 1;
		}
		*/
		
		public override void NPCLoot() {
			Item.NewItem(npc.getRect(), ItemType<Items.Weapons.RokkClub>());
		}
		
		// Melee Attack
		public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
        {
            scale = 1.5f;
            item = Main.itemTexture[mod.ItemType("Rokk's Club")];
            itemSize = 56; //56
        }

		// TownNPCAttackSwing is not the same as TownAttackSwing even though it will compile
		public override void TownNPCAttackSwing(ref int itemwidth, ref int itemheight)
		{
			itemwidth = 40;
			itemheight = 40;
		}
	}
}