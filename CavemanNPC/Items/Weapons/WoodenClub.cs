using System;
using CavemanNPC.NPCs;
using CavemanNPC.Dusts;
using CavemanNPC.Items;
using CavemanNPC.Items.Weapons;
//using CavemanNPC.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CavemanNPC.Items.Weapons
{
	public class WoodenClub : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("A Wooden Club from Rokk's personal collection.");  //The (English) text shown below your weapon's name
		}

		public override void SetDefaults() {
			item.damage = 50;           //The damage of your weapon
			item.melee = true;          //Is your weapon a melee weapon?
			item.width = 40;            //Weapon's texture's width
			item.height = 40;           //Weapon's texture's height
			item.useTime = 12;          //The time span of using the weapon. Remember in terraria, 60 frames is a second.
			item.useAnimation = 20;     //The time span of the using animation of the weapon, suggest set it the same as useTime.
			item.useStyle = 1;          //The use style of weapon, 1 for swinging, 2 for drinking, 3 act like shortsword, 4 for use like life crystal, 5 for use staffs or guns
			item.knockBack = 6;         //The force of knockback of the weapon. Maximum is 20
			item.value = Item.buyPrice(silver: 20);           //The value of the weapon
			item.rare = 3;              //The rarity of the weapon, from -1 to 13
			item.expert = false;
			item.UseSound = SoundID.Item45;      //The sound when the weapon is using
			item.autoReuse = true;          //Whether the weapon can use automatically by pressing mousebutton
		}

		// This is the recipe
		/*
		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood), 20);
			recipe.AddTile(TileID.Workbenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		*/
	}
}