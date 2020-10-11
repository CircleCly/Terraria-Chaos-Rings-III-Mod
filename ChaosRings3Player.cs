using ChaosRings3Mod.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ChaosRings3Mod
{
    class ChaosRings3Player : ModPlayer
    {
        
        public float mutationThres = 10000;
        public float mutationValue = 0;
        public Gene equippedGene;
        public int hitWeakpointDispTimer = 0;
        public int hitWeakpointDispTimerMax = 30;
        public int playerWeakDispTimer = 0;
        public int playerWeakDispTimerMax = 30;
        public AttributeManager.Attribute attr;
        public void IncreaseMutation(float amount)
        {
            mutationValue += amount;
            if (mutationValue >= mutationThres)
            {
                mutationValue = mutationThres;
                mutationValue = 0;
                player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " exceeded the gene capacity."), 9999, 0);
            }
        }

        public void MutationDecay()
        {
            if (player.statMana == player.statManaMax2)
            {
                if (mutationValue > 0)
                    mutationValue -= mutationValue * 0.005f;
                if (mutationValue < 0)
                    mutationValue = 0;
            }
        }

        public void SkillCDDecay()
        {
            equippedGene?.SkillCDDecay();
        }

        public void WeakpointDispTimerDecrease()
        {
            if (hitWeakpointDispTimer > 0)
            {
                hitWeakpointDispTimer--;
            }
            if (playerWeakDispTimer > 0)
            {
                playerWeakDispTimer--;
            }

                
        }
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (ChaosRings3Mod.skill1.JustPressed)
            {
                equippedGene?.ActivateSkill(0);
            }
            player.GetModPlayer<ChaosRings3Player>().equippedGene = null;
        }
        public override void OnConsumeMana(Item item, int manaConsumed)
        {
            base.OnConsumeMana(item, manaConsumed);
            IncreaseMutation(manaConsumed * 5 * 10 * (float)(Main.LocalPlayer.statManaMax2 - Main.LocalPlayer.statMana) / Main.LocalPlayer.statManaMax2);
        }

        public override void PreUpdate()
        {
            MutationDecay();
            WeakpointDispTimerDecrease();
            SkillCDDecay();
        }

        public override TagCompound Save()
        {
            // Read https://github.com/tModLoader/tModLoader/wiki/Saving-and-loading-using-TagCompound to better understand Saving and Loading data.
            return new TagCompound {
				// {"somethingelse", somethingelse}, // To save more data, add additional lines
				{"mutationValue", mutationValue},
                {"mutationThres", mutationThres},
                {"attribute", (int)attr }
            };
            //note that C# 6.0 supports indexer initializers
            //return new TagCompound {
            //	["score"] = score
            //};
        }

        public override void Load(TagCompound tag)
        {
            mutationValue = tag.GetFloat("mutationValue");
            mutationThres = tag.GetFloat("mutationThres");
            attr = (AttributeManager.Attribute)tag.GetInt("attribute");
        }

        
    }
}
