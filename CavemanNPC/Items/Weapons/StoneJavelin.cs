using CavemanNPC.Projectiles;
using CavemanNPC.Dusts;
using CavemanNPC.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CavemanNPC.Items.Weapons
{
	public class StoneJavelin : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Stone Javelin");
			DisplayName.SetDefault("Stone Javelin");
		}

		public override void SetDefaults() {
			item.damage = 40;
			item.useStyle = 5;
			item.useAnimation = 18;
			item.useTime = 25;
			item.shootSpeed = 10.5f;
			item.knockBack = 6.5f;
			item.width = 32;
			item.height = 32;
			item.scale = 1f;
			item.rare = 1;
			item.value = Item.buyPrice(silver: 30);
			item.maxStack = 999;
			item.melee = true;
			item.noMelee = true; // Important because the spear is actually a projectile instead of an item. This prevents the melee hitbox of this item.
			item.noUseGraphic = true; // Important, it's kind of wired if people see two spears at one time. This prevents the melee animation of this item.
			item.autoReuse = true; // Most spears don't autoReuse, but it's possible when used in conjunction with CanUseItem()

			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<StoneJavelinProjectile>();
		}
		
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("Wood", 5);
			//recipe.AddIngredient(ItemID.anyWood, #); doesnt work, use recipe.AddRecipeGroup("Wood", #); instead
			//recipe.AddIngredient(ItemID.anyWood, 5);
			recipe.AddIngredient(ItemID.StoneBlock, 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
		
		public override bool CanUseItem(Player player) {
			// Ensures no more than one spear can be thrown out, use this when using autoReuse
			return player.ownedProjectileCounts[item.shoot] < 1;
		}
	}
}
