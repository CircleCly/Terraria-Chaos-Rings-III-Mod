using ChaosRings3Mod.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace ChaosRings3Mod.UI
{
    class GeneUI : UIState
    {
        private GeneSlot geneSlot;

        public override void OnInitialize()
        {
            geneSlot = new GeneSlot(ItemSlot.Context.EquipAccessory, 0.85f) {
                Left = { Pixels = Main.screenWidth - 232 },
                Top = { Pixels = 654 }

            };
            Append(geneSlot);
        }


    }
}
