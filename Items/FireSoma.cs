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
    public class FireSoma : Soma
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Soma");
            Tooltip.SetDefault("Deals a small amount of fire/magic damage to a single foe. \nEffective against ice.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 30;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Item34);
            for (int i = 0; i < 3; i++)
            {
                Vector2 v = new Vector2();
                if (player.direction == 1)
                {
                    v = Main.rand.NextVector2Square(4, 12);
                }
                else
                {
                    v = Main.rand.NextVector2Square(-4, -12);
                }
                Projectile.NewProjectile(player.position, v, mod.ProjectileType("CremateProjectile"), (int)(item.damage * player.magicDamageMult), item.knockBack, Main.myPlayer);
            }
            return true;
        }
    }
}
