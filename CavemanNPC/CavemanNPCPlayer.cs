using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using CavemanNPC.Items;
using CavemanNPC.Items.Pets;
using CavemanNPC.Projectiles.Pets;
using CavemanNPC.Buffs;
using static Terraria.ModLoader.ModContent;

namespace CavemanNPC
{
    public class CavemanNPCPlayer : ModPlayer
    {

        public bool PetRock = false;

        public override void ResetEffects()
        {
            // Inside this method, we reset all the bools, ints, floats to a "default" value
            PetRock = false;
        }

		public override void PostUpdateEquips()
        {
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if(player.armor[k].modItem != null)
                {
                    ModItem item = player.armor[k].modItem;
                    if(item.GetType().IsSubclassOf(typeof(CavemanNPCItems)))
                    {
                    }
                }
                
                
            }
        }
    }
}