using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
namespace ChaosRings3Mod.Items
{
    public abstract class Soma : ModItem
    {
        
        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.maxStack = 999;
            item.value = Item.buyPrice(0, 0, 2, 0);
            item.rare = 3;
            item.useStyle = 4;
            item.useTime = 75;
            item.useAnimation = 75;
            item.autoReuse = true;
            item.useTurn = true;
            item.consumable = true;
            item.magic = true;
            item.noUseGraphic = true;
            item.noMelee = true;
        }

    }
}
