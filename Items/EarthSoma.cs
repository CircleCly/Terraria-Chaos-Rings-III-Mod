using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ChaosRings3Mod.Items
{
    public class EarthSoma : Soma
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth Soma");
            Tooltip.SetDefault("Deals a small amount of earth/magic damage to a single foe.\nEffective against bolt.");
        }
        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 30;
        }

        public override bool UseItem(Player player)
        {
            
            for (int i = 0; i < 1; i++)
            {
                Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(0, 0), mod.ProjectileType("DogaProjectileRoot"), (int)(item.damage * player.magicDamageMult), item.knockBack, Main.myPlayer);
            }
            return true;
        }
    }
}
