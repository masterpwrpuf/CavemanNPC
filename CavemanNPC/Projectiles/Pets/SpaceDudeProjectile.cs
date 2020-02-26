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
    public class SpaceDudeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 4; // This pet has 4 frames that work as the animation
            Main.projPet[projectile.type] = true; // This just marks the projectile as a pet
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.ZephyrFish); // This will clone the defaults from another projectile.
            aiType = ProjectileID.ZephyrFish;
			projectile.width = 24;
			projectile.height = 102;
			projectile.scale = 1f;
			Main.projFrames[projectile.type] = 4;
            Main.projPet[projectile.type] = true;
        }
		
        public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

        public override void AI() {
			Player player = Main.player[projectile.owner];
			CavemanNPCPlayer modPlayer = player.GetModPlayer<CavemanNPCPlayer>();
			if (player.dead) {
				modPlayer.SpaceDude = false;
			}
			if (modPlayer.SpaceDude) {
				projectile.timeLeft = 2;
			}/*
			if (++projectile.frameCounter >= 5) {
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4) {
					projectile.frame = 0;
				}
			}*/
		}
    }
}