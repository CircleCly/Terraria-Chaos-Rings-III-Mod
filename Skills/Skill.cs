using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
namespace ChaosRings3Mod.Skills
{
    public class Skill
    {
        protected int requireMana;
        protected int mutationFactor;
        public int maxCooldownTime;
        public bool ConsumeMana()
        {

            if (!Main.LocalPlayer.CheckMana(Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().equippedGene.item, requireMana, true, false))
            {
                return false;
            } else
            {
                Main.LocalPlayer.manaRegenDelay = 300;
                float increasedMutation = 
                    requireMana * 50 * (mutationFactor - 1) * (float)(Main.LocalPlayer.statManaMax2 - Main.LocalPlayer.statMana) / Main.LocalPlayer.statManaMax2;
                Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().IncreaseMutation(increasedMutation);
                return true;
            }
        }
        public virtual void Activate(float damageModifier)
        {
            
        }
    }
}
