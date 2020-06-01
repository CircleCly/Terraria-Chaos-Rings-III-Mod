using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ChaosRings3Mod.Items
{
    class BoltSoma : Soma
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bolt Soma");
            Tooltip.SetDefault("Deals a small amount of bolt/magic damage to a single foe.\nEffective against earth.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 23;
        }

        public override bool UseItem(Player player)
        {
            
            for (int i = 0; i < 1; i++)
            {
                Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(0, 0), mod.ProjectileType("ElectraProjectileRoot"), (int)(item.damage * player.magicDamageMult), item.knockBack, Main.myPlayer);
            }
            return true;
        }
    }
}
