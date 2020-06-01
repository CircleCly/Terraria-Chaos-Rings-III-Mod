using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChaosRings3Mod.Skills;
namespace ChaosRings3Mod.Items.Genes
{
    class Michael : Gene
    {
        public Michael() : base()
        {
            attribute = AttributeManager.Attribute.ICE;
            atkModifier = 0.03f;
            defModifier = 0.02f;
            spdModifier = 0.03f;
            luckModifier = 0.02f;
            skills.Add("Cocytus");
            name = "Michael";
        }

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
        }
    }
}
