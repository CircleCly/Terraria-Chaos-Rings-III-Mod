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
        AttributeManager.Attribute attribute;
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
        public override void SetDefaults(NPC npc)
        {
            
        }
        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            base.ModifyHitByItem(npc, player, item, ref damage, ref knockback, ref crit);
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            double dmgFactor = AttributeManager.GetDamageMultiplier(AttributeManager.projAttributes[projectile.type],
                AttributeManager.npcAttributes[npc.type]);
            damage = (int)(damage * dmgFactor);
            if (dmgFactor == AttributeManager.weakpointFactor)
            {
                if (Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().hitWeakpointDispTimer == 0)
                {
                    CombatText.NewText(new Rectangle(npc.Hitbox.X, npc.Hitbox.Y - 20, npc.Hitbox.Width, npc.Hitbox.Height), Color.Red, "Weakpoint!", true);
                    Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().hitWeakpointDispTimer = Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().hitWeakpointDispTimerMax;
                }
            }
            else if (dmgFactor == AttributeManager.strongpointFactor)
            {
                if (Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().hitWeakpointDispTimer == 0)
                {
                    CombatText.NewText(new Rectangle(npc.Hitbox.X, npc.Hitbox.Y - 20, npc.Hitbox.Width, npc.Hitbox.Height), Color.Gray, "Strongpoint!", true);
                    Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().hitWeakpointDispTimer = Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().hitWeakpointDispTimerMax;
                }

            }
        }
        public override void ModifyHitNPC(NPC npc, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            base.ModifyHitNPC(npc, target, ref damage, ref knockback, ref crit);
        }
        public override void ModifyHitPlayer(NPC npc, Player target, ref int damage, ref bool crit)
        {
            ChaosRings3Player modPlayer = target.GetModPlayer<ChaosRings3Player>();
            double dmgFactor = AttributeManager.GetDamageMultiplier(AttributeManager.npcAttributes[npc.type],
                 modPlayer.attr);
            damage = (int)(damage * dmgFactor);
            if (dmgFactor == AttributeManager.weakpointFactor)
            {
                if (modPlayer.playerWeakDispTimer == 0)
                {
                    CombatText.NewText(new Rectangle(target.Hitbox.X, target.Hitbox.Y - 20, target.Hitbox.Width, target.Hitbox.Height), Color.Red, "Weakpoint!", true);
                    modPlayer.playerWeakDispTimer = modPlayer.playerWeakDispTimerMax;
                }
            }
            else if (dmgFactor == AttributeManager.strongpointFactor)
            {
                if (modPlayer.playerWeakDispTimer == 0)
                {
                    CombatText.NewText(new Rectangle(target.Hitbox.X, target.Hitbox.Y - 20, target.Hitbox.Width, target.Hitbox.Height), Color.Gray, "Strongpoint!", true);
                    modPlayer.playerWeakDispTimer = modPlayer.playerWeakDispTimerMax;
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
