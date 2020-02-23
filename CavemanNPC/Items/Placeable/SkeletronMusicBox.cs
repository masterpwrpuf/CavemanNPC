using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CavemanNPC.Items.Placeable
{
	public class SkeletronMusicBox : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Skeletron Music Box");
			Tooltip.SetDefault("Curse of the Dungeon from the Calamity Extra Music Mod");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.SkeletronMusicBox>();
			item.width = 24;
			item.height = 24;
			item.rare = -12;
			item.value = 500000; // 1 = 1 copper, 100 = 1 silver, 1000 = 10 silver, 10000 = 1 gold
			item.accessory = true;
		}
	}
}
