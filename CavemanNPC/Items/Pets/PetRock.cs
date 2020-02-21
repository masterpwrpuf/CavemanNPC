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
    public class PetRock : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pet Rock");
            Tooltip.SetDefault("I know, I know, he's got nerves of steel.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Bunny); // This clones an existing item, this is to save time.
            item.shoot = mod.ProjectileType("PetRockProjectile");
            item.buffType = mod.BuffType("PetRock");
			item.rare = -12;
			item.value = Item.buyPrice(gold: 20);
			item.UseSound = SoundID.Item105;
			item.consumable = false;
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