using System;
using System.Collections.Generic;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace ChaosRings3Mod.Items
{
    class Cross : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cross");
            base.SetStaticDefaults();
        }

        public override void SetDefaults()
        {
            item.width = 66;
            item.height = 74;
            item.maxStack = 1;
            item.magic = true;
            item.mana = 10;
            item.damage = 28;
            item.scale = 1.3f;
            item.value = Item.buyPrice(0, 0, 5, 0);
            item.rare = 0;
            item.noMelee = true;
            item.knockBack = 5;
            item.useStyle = 1;
            item.useTime = 33;
            item.useAnimation = 33;
            item.useTurn = false;
            item.autoReuse = false;
            item.UseSound = SoundID.Item43;
            item.shoot = mod.ProjectileType("MagicSphere");
            item.shootSpeed = 14.3f;
            base.SetDefaults();
        }
    }
}
