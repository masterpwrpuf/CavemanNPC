using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CavemanNPC.Items.Placeable
{
	public class ChungusMusicBox : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Big Chungus Music Box");
			Tooltip.SetDefault("Its Big Chungus!");
		}

		public override void SetDefaults() {
			item.useStyle = 1;
			item.useTurn = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.autoReuse = true;
			item.consumable = true;
			item.createTile = TileType<Tiles.ChungusMusicBox>();
			item.width = 24;
			item.height = 24;
			item.rare = -12;
			item.value = 500000;
			item.accessory = true;
		}
	}
}
