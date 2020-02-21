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
using static Terraria.ModLoader.ModContent;

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
			npc.damage = 20;
			npc.defense = 20;
			npc.lifeMax = 1000;
			npc.HitSound = SoundID.DD2_OgreHurt;
			npc.DeathSound = SoundID.DD2_JavelinThrowersDeath;
			npc.knockBackResist = 0.5f;
			animationType = NPCID.Guide;
		}
		
		public override void HitEffect(int hitDirection, double damage) {
			int num = npc.life > 0 ? 1 : 5;
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money) {
			for (int k = 0; k < 255; k++) {
				Player player = Main.player[k];
				if (!player.active) {
					continue;
				}
				//if (NPC.downedBoss1) = true {
				//	return true;
			}
			return false;
		}

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
			switch (Main.rand.Next(3)) {
				case 0:
					return "I big strong, you small weak.";
				case 1:
					return "Me once find big rock. Me now lost big rock.";
				default:
					return "Rokk!";
			}
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
		
		public override void SetupShop(Chest shop, ref int nextSlot)
		{
			shop.item[nextSlot].SetDefaults(ItemID.Leather);
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
			shop.item[nextSlot].SetDefaults(ItemType<Items.Pets.PetRock>());
			nextSlot++;
		}
			
		public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
			damage = 80;
			knockback = 4f;
		}
		
		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
			cooldown = 5;
			randExtraCooldown = 15;
		}
		
		// Magic Attack
		/*
		public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
			projType = ProjectileType<SparklingBall>();
			attackDelay = 1;
		}
		*/
		
		// Melee Attack
		public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)
        {
            scale = 1.5f;
            item = Main.itemTexture[mod.ItemType("WoodenClub")];
            itemSize = 56; //56
        }
		
		/*
		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
			multiplier = 12f;
			randomOffset = 2f;
			} */
		}
	}