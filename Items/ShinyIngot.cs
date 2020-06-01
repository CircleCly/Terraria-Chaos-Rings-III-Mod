using System;
using System.Collections.Generic;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace ChaosRings3Mod.Items
{
    class ShinyIngot : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shiny Ingot");
            Tooltip.SetDefault("Summons Mocktopus");
            base.SetStaticDefaults();
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.consumable = true;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.scale = 0.7f;
            item.useStyle = 4;
            item.consumable = true;
            item.maxStack = 99;
            item.width = 64;
            item.height = 64;
            item.noMelee = true;

        }
    }
}
