using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace CavemanNPC.Buffs
{
    public class PetRock : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Pet Rock");
            Description.SetDefault("Rokk's friend Patrick lent him his faveorite rock!");
            Main.buffNoTimeDisplay[Type] = true; // This will make it so no time is displayed on the buff icon
            Main.vanityPet[Type] = true; // This buff is linked to pets
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CavemanNPCPlayer>().PetRock = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("PetRockProjectile")] <= 0;
            if(petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("PetRockProjectile"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}