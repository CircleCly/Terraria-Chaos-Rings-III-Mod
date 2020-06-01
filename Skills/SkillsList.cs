using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaosRings3Mod.Skills
{
    public class SkillsList
    {
        public Dictionary<string, Skill> skills;
        public SkillsList()
        {
            skills = new Dictionary<string, Skill>();
            skills.Add("Cremate", new Cremate());
            skills.Add("Cocytus", new Cocytus());
            skills.Add("Doga", new Doga());
            skills.Add("Electra", new Electra());
            skills.Add("Mana", new Mana());
            skills.Add("Odette", new Odette());

        }
    }
}
