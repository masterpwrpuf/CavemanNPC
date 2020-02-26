using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CavemanNPC.Buffs;
using CavemanNPC.Projectiles;
using CavemanNPC.Items.Pets;

namespace CavemanNPC.Items.Pets
{
    public class SpaceDude : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Dude");
            Tooltip.SetDefault("Custom pet requested by 3CupsOfTea");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ZephyrFish); // This clones an existing item, this is to save time.
            item.shoot = mod.ProjectileType("SpaceDudeProjectile");
            item.buffType = mod.BuffType("SpaceDude");
			item.rare = -12;
			item.value = Item.buyPrice(gold: 100);
			item.UseSound = SoundID.Item25;
			item.consumable = false;
			item.maxStack = 1;
			item.width = 44;
			item.height = 114;
			item.scale = 1f;
        }

        public override void UseStyle(Player player)
        {
            if(player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                player.AddBuff(item.buffType, 3600, true);
            }
        }      
        
    }
}