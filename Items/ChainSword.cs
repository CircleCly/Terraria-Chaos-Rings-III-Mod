using System;
using System.Collections.Generic;
using System.Text;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
namespace ChaosRings3Mod.Items
{
    class ChainSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Chain Sword");
            Tooltip.SetDefault("\"The time has come for you to fulfill the ancient promise.\"");
        }

        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.maxStack = 1;
            item.scale = 1.5f;
            item.value = Item.buyPrice(0, 0, 5, 0);
            item.rare = 0;

            item.useStyle = 1;
            item.useTime = 28;
            item.useAnimation = 28;
            item.useTurn = true;
            item.autoReuse = false;
            item.UseSound = SoundID.Item1;
            item.melee = true;

            item.damage = 17;
            item.crit = 4;
            item.knockBack = 6f;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.channel = false;

        }

    }
}
