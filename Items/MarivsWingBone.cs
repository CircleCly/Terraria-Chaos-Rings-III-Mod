using System;
using System.Collections.Generic;
using System.Text;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
namespace ChaosRings3Mod.Items
{
    class MarivsWingBone : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mariv's Wing Bone");
            Tooltip.SetDefault("\"Sorry, but you won't be getting anywhere near Mariv.\"");
        }

        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.maxStack = 1;
            item.value = Item.buyPrice(10, 0, 0, 0);
            item.rare = 13;
            item.useStyle = 1;
            item.useTime = 39;
            item.useAnimation = 39;
            item.useTurn = false;
            item.autoReuse = false;
            item.melee = true;
            item.scale = 2.3f;
            item.UseSound = SoundID.Item1;

            item.damage = 400;
            item.crit = 15;
            item.knockBack = 10f;
            item.noMelee = false;
            item.noUseGraphic = false;
            item.channel = false;
        }
    }
}
