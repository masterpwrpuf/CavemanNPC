using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace CavemanNPC.Buffs
{
    public class SpaceDude : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Space Dude");
            Description.SetDefault("Custom pet requested by 3CupsOfTea");
            Main.buffNoTimeDisplay[Type] = true; // This will make it so no time is displayed on the buff icon
            Main.vanityPet[Type] = true; // This buff is linked to pets
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.buffTime[buffIndex] = 18000;
            player.GetModPlayer<CavemanNPCPlayer>().SpaceDude = true;
            bool petProjectileNotSpawned = player.ownedProjectileCounts[mod.ProjectileType("SpaceDudeProjectile")] <= 0;
            if(petProjectileNotSpawned && player.whoAmI == Main.myPlayer)
            {
                Projectile.NewProjectile(player.position.X + (float)(player.width / 2), player.position.Y + (float)(player.height / 2), 0f, 0f, mod.ProjectileType("SpaceDudeProjectile"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
    }
}