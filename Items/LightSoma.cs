using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
namespace ChaosRings3Mod.Items
{
    class LightSoma : Soma
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Light Soma");
            Tooltip.SetDefault("Deals a small amount of light/magic damage to a single foe.\nEffective against dark.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 18;
        }

        public override bool UseItem(Player player)
        { 
            Projectile.NewProjectile(player.position, new Vector2(0, 0), mod.ProjectileType("ManaProjectileRoot"), (int) (item.damage * player.magicDamageMult), item.knockBack, Main.myPlayer);
            return true;
        }
    }
}
