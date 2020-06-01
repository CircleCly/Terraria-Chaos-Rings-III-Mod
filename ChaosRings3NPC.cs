using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChaosRings3Mod
{
    class ChaosRings3NPC : GlobalNPC
    {
        Dictionary<int, int> damageDealt = new Dictionary<int, int>();
        public override bool InstancePerEntity => true;
        public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
        {
            
            if (damageDealt.ContainsKey(player.whoAmI))
            {
                damageDealt[player.whoAmI] += damage;
            }
            else
            { 
                damageDealt.Add(player.whoAmI, Math.Min(npc.lifeMax, damage));
            }
            if (npc.life <= 0)
            {
                int[] keys = damageDealt.Keys.ToArray();
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i] == Main.LocalPlayer.whoAmI)
                    {
                        int exp = damageDealt[Main.LocalPlayer.whoAmI] / 5;
                        Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().equippedGene.gainExp(exp);
                        
                    }
                }
            } 
        }
        public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
        {
            
            if (damageDealt.ContainsKey(projectile.owner))
            {
                damageDealt[projectile.owner] += damage;
            }
            else
            {
                damageDealt.Add(projectile.owner, Math.Min(npc.lifeMax, damage));
            }
            if (npc.life <= 0)
            {
                int[] keys = damageDealt.Keys.ToArray();
                for (int i = 0; i < keys.Length; i++)
                {
                    if (keys[i] == Main.LocalPlayer.whoAmI)
                    {
                        int exp = damageDealt[Main.LocalPlayer.whoAmI] / 5;
                        Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().equippedGene.gainExp(exp);
                        
                    }
                }
            } 
        }
       
        
    }
}
