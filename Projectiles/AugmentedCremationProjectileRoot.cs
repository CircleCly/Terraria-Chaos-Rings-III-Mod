using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;

namespace ChaosRings3Mod.Projectiles
{
    class AugmentedCremationProjectileRoot : ProjectileRoot
    {
        int summonTimer = 0;
        public override void SetDefaults()
        {
            summonTimes = 1;
            summonDelay = 61;
            base.SetDefaults();
        }

        public override void AI()
        {
            
            if (summonTimer == 15 || summonTimer == 30 || summonTimer == 60)
            {
                Main.PlaySound(SoundID.Item34);
                Projectile.NewProjectile(new Vector2(projectile.position.X - 32, projectile.position.Y - 14), new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(14, 15)), mod.ProjectileType("AugmentedCremationProjectile"), projectile.damage, projectile.knockBack, projectile.owner);
                
            }
            summonTimer++;
            
        }
    }
}
