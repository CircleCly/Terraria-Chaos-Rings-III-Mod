using System;
using System.Collections.Generic;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
namespace ChaosRings3Mod.Items
{
    class TitaniumBullet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titanium Bullet");
            Tooltip.SetDefault("Shoots six bullets in a row");
        }

        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 10, 0);
            item.rare = 1;

            item.useStyle = 5;
            item.useTime = 5;
            item.useAnimation = 30;
            item.reuseDelay = 30;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.damage = 9;
            item.crit = 6;
            item.knockBack = 1.0f;

            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 11f;

            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true;
            item.noUseGraphic = false;
            item.channel = false;

        }

        public override bool ConsumeAmmo(Player player)
        {
            return !(player.itemAnimation < item.useAnimation - 2);
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Main.PlaySound(SoundID.Item41);
            return true;
        }
    }
}
