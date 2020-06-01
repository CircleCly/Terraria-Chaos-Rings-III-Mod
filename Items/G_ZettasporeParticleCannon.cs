using System;
using System.Collections.Generic;
using System.Text;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
namespace ChaosRings3Mod.Items
{
    class G_ZettasporeParticleCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("G-Zettaspore Particle Cannon");
            Tooltip.SetDefault("Shoots one very powerful bullet");
        }

        public override void SetDefaults()
        {
            item.width = 64;
            item.height = 64;
            item.maxStack = 1;
            item.value = Item.sellPrice(0, 0, 30, 0);
            item.rare = 2;

            item.useStyle = 5;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useTurn = false;
            item.autoReuse = false;
            item.UseSound = SoundID.Item9;
            item.ranged = true;

            item.damage = 54;
            item.crit = 22;
            item.knockBack = 10f;

            item.shoot = ProjectileID.MeteorShot;
            item.shootSpeed = 60f;

            item.useAmmo = AmmoID.Bullet;

            item.noMelee = true;
            item.noUseGraphic = false;
            item.channel = false;

        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MeteoriteBar, 24);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
