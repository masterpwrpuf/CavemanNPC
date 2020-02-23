using CavemanNPC.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using static Terraria.ModLoader.ModContent;

namespace CavemanNPC
{
	public class CavemanNPC : Mod
	{
		public override void Load() {
			// All code below runs only if we're not loading on a server
			if (!Main.dedServ) {
				// Register a new music box
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/chungus"), ItemType("ChungusMusicBox"), TileType("ChungusMusicBox"));
				AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/CurseOfTheDungeon"), ItemType("SkeletronMusicBox"), TileType("SkeletronMusicBox"));
			}
		}

		public override void UpdateMusic(ref int music, ref MusicPriority priority) {
			if (Main.myPlayer == -1 || Main.gameMenu || !Main.LocalPlayer.active) {
				return;
			}
		}
	}
}