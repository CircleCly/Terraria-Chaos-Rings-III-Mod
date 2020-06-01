using System;
using System.Collections.Generic;
using System.Text;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
namespace ChaosRings3Mod.Items
{
    class LaTraviata : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("La Traviata");
        }
        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.maxStack = 1;
            item.scale = 1.9f;
            item.value = Item.buyPrice(0, 0, 5, 0);
            item.rare = 0;

            item.useStyle = 1;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useTurn = false;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.melee = true;

            item.damage = 12;
            item.crit = 3;
            item.knockBack = 3f;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.channel = false;
        }
    }
}
