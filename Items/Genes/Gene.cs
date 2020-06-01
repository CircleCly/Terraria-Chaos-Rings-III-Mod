using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using ChaosRings3Mod.Skills;
using Terraria.ModLoader.IO;
using Terraria.UI;
using Microsoft.Xna.Framework;

namespace ChaosRings3Mod.Items
{
    abstract class Gene : ModItem
    {
        public override bool CloneNewInstances => true;
        protected int level = 1;
        protected AttributeManager.Attribute attribute;
        protected int curExp = 0;
        protected int expToUpgrade;
        public enum Rarity
        {
            N,
            R,
            SR
        };
        protected Rarity rarity;
        protected string name;
        protected float atkModifier, defModifier, spdModifier, luckModifier;
        protected List<string> skills;
        public Gene()
        {
            skills = new List<string>();
            expToUpgrade = CalculateExpToUpgrade();
        }

        public override string Texture => "ChaosRings3Mod/Items/Genes/Gene";
        public override void SetStaticDefaults()
        {
            String rare = "";
            switch (rarity)
            {
                case Rarity.N:
                    rare = "N";
                    break;
                case Rarity.R:
                    rare = "R";
                    break;
                case Rarity.SR:
                    rare = "SR";
                    break;
            }
            DisplayName.SetDefault(rare + ": " + name);
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        { 
            string geneInfo = "Level " + level + "\n"
                                + "Experience: " + curExp + "/" + expToUpgrade + "\n"
                                + "ATK " + (int)(atkModifier * 100 + 1) + "\n"
                                + "DEF " + (int)(defModifier * 100 + 1) + "\n"
                                + "SPD " + (int)(spdModifier * 100 + 1) + "\n"
                                + "LUK " + (int)(luckModifier * 100 + 1) + "\n";
            var geneTooltip = new TooltipLine(ChaosRings3Mod.instance, "GeneInfo", geneInfo);
            tooltips.Add(geneTooltip);
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 64;
            item.height = 64;
            item.maxStack = 1;
            item.value = 1000 * level;
            switch (rarity)
            {
                case Rarity.N:
                    item.rare = 1;
                    break;
                case Rarity.R:
                    item.rare = 5;
                    break;
                case Rarity.SR:
                    item.rare = 9;
                    break;
            }
            
        }
        public override TagCompound Save()
        {
            TagCompound data = new TagCompound();
            data.Add(nameof(level), level);
            data.Add(nameof(attribute), (int)attribute);
            data.Add(nameof(curExp), curExp);
            data.Add(nameof(expToUpgrade), expToUpgrade);
            data.Add(nameof(rarity), (int)rarity);
            data.Add(nameof(name), name);
            data.Add(nameof(atkModifier), atkModifier);
            data.Add(nameof(defModifier), defModifier);
            data.Add(nameof(spdModifier), spdModifier);
            data.Add(nameof(luckModifier), luckModifier);
            data.Add(nameof(skills), skills);
            return data;
        }

        public override void Load(TagCompound tag)
        {
            level = tag.GetInt(nameof(level));
            attribute = (AttributeManager.Attribute)tag.GetInt(nameof(attribute));
            curExp = tag.GetInt(nameof(curExp));
            expToUpgrade = tag.GetInt(nameof(expToUpgrade));
            rarity = (Rarity)tag.GetInt(nameof(rarity));
            name = tag.GetString(nameof(name));
            atkModifier = tag.GetFloat(nameof(atkModifier));
            defModifier = tag.GetFloat(nameof(defModifier));
            spdModifier = tag.GetFloat(nameof(spdModifier));
            luckModifier = tag.GetFloat(nameof(luckModifier));
            skills = tag.GetList<string>(nameof(skills)).ToList<string>();
        }
        public void ActivateSkill(int skillId)
        {
            ChaosRings3Mod.skillsList.skills[this.skills[skillId]].Activate(atkModifier + 1);
        }

        public int CalculateExpToUpgrade()
        {
            return (int) (Math.Floor(500 * Math.Pow(1.1, level) / 50) * 50);
        }

        public void gainExp(int exp)
        {
            CombatText.NewText(Main.LocalPlayer.Hitbox, Color.Green, "+ " + exp + " EXP", true);
            curExp += exp;
            while (curExp >= expToUpgrade)
            {
                if (!levelUp())
                {
                    curExp = expToUpgrade;
                    break;
                }
            }
        }

        public bool levelUp()
        {
            switch(rarity)
            {
                case Rarity.N:
                    if (level >= 30) return false;
                    break;
                case Rarity.R:
                    if (level >= 60) return false;
                    break;
                case Rarity.SR:
                    if (level >= 100) return false;
                    break;
            }
            level++;
            Main.NewText(name + " is now level " + level + "!", Color.Green);
            curExp -= expToUpgrade;
            expToUpgrade = CalculateExpToUpgrade();
            atkModifier += 0.05f;
            defModifier += 0.05f;
            spdModifier += 0.05f;
            luckModifier += 0.05f;
            return true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ChaosRings3Player>().equippedGene = this;
            player.moveSpeed += spdModifier / 3;
            player.maxRunSpeed *= 1 + spdModifier / 3;
            player.runAcceleration *= 1 + spdModifier / 3;
            player.statDefense += (int)(defModifier * 100 + 1) / 5;
            player.meleeDamageMult += atkModifier;
            player.rangedDamageMult += atkModifier;
            player.magicDamageMult += atkModifier;
            player.thrownDamageMult += atkModifier;
            player.minionDamageMult += atkModifier;
            player.meleeCrit += (int) (luckModifier * 20);
            player.rangedCrit += (int)(luckModifier * 20);
            player.magicCrit += (int)(luckModifier * 20);
            player.thrownCrit += (int)(luckModifier * 20);
            


        }
    }
}
