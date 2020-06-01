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
    public class IceSoma : Soma
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Soma");
            Tooltip.SetDefault("Deals a small amount of ice/magic damage to a single foe. \nEffective against fire.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 18;
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Item28);
            for (int i = 0; i < 1; i++)
            {
                Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(0, 0), mod.ProjectileType("CocytusProjectile"), (int) (item.damage * player.magicDamageMult), item.knockBack, Main.myPlayer);
            }
            return true;
        }
    }
}
