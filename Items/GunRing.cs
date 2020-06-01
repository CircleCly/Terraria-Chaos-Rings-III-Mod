using System;
using System.Collections.Generic;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ChaosRings3Mod.Items
{
    public class GunRing : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gun Ring");
            Tooltip.SetDefault("Shoots six bullets in a row\n\"Prime numbers? What the heck are they?\" ");
        }

        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.rare = 0;
            
            item.useStyle = 5;
            item.useTime = 6;  
            item.useAnimation = 36;
            item.reuseDelay = 10;
            item.useTurn = false;
            item.autoReuse = true;

            item.ranged = true;

            item.damage = 3;
            item.crit = 4;
            item.knockBack = 0.5f;

            item.shoot = ProjectileID.Bullet;
            item.shootSpeed = 9f;

            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true;
            item.noUseGraphic = false;
            item.channel = false;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IronBar, 15);
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
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
