using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosRings3Mod.Items
{
    public class DarkSoma : Soma
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dark Soma");
            Tooltip.SetDefault("Deals a small amount of dark/magic damage to a single foe. \nEffective against light.");

        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 23;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Item8);
            for (int i = 0; i < 1; i++)
            {
                Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(0, 0), mod.ProjectileType("OdetteProjectile"), (int) (item.damage * player.magicDamageMult), item.knockBack, Main.myPlayer);
            }
            return true;
        }
    }
}
