using System;
using System.Collections.Generic;
using System.Text;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
namespace ChaosRings3Mod.Items
{
    class TrueIncarnatusBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Incarnatus Blade");
            Tooltip.SetDefault("\"To the hell with the law of predator and prey!\"");
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.maxStack = 1;
            item.value = Item.buyPrice(0, 0, 0, 0);
            item.rare = 13;
            item.useStyle = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useTurn = false;
            item.autoReuse = true;
            item.melee = true;
            item.scale = 3.5f;
            item.UseSound = SoundID.Item1;
            item.damage = 1500;
            item.crit = 15;
            item.knockBack = 10f;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.channel = false;
            base.SetDefaults();
        }
    }
}
