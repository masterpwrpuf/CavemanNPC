using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CavemanNPC;

namespace CavemanNPC.Projectiles.Pets
{
    public class PetRockProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 1; // This pet has 4 frames that work as the animation
            Main.projPet[projectile.type] = true; // This just marks the projectile as a pet
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Bunny); // This will clone the defaults from another projectile.
            aiType = ProjectileID.Bunny;
			projectile.width = 35;
			projectile.height = 33;
			projectile.scale = 1f;
        }
		
        public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.bunny = false; // Relic from aiType
			return true;
		}

        public override void AI() {
			Player player = Main.player[projectile.owner];
			CavemanNPCPlayer modPlayer = player.GetModPlayer<CavemanNPCPlayer>();
			if (player.dead) {
				modPlayer.PetRock = false;
			}
			if (modPlayer.PetRock) {
				projectile.timeLeft = 2;
			}
		}
    }
}