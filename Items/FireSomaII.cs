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
    public class FireSomaII : Soma
    {
        public override string Texture => "ChaosRings3Mod/Items/FireSoma";
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Soma II");
            Tooltip.SetDefault("Deals a moderate amount of fire/magic damage to a single foe. \nEffective against ice.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.damage = 75;
        }

        public override bool UseItem(Player player)
        {
            Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y - 200), new Vector2(0, 0), mod.ProjectileType("AugmentedCremationProjectileRoot"), (int)(item.damage * player.magicDamageMult), item.knockBack, Main.myPlayer);
            return true;
        }
    }
}
