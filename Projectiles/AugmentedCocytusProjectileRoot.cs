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
    class AugmentedCocytusProjectileRoot : ProjectileRoot
    {
        
        public override void SetDefaults()
        {
            summonTimes = 3;
            summonDelay = 15;
            base.SetDefaults();
        }

        public override void AI()
        {

            if (projectile.timeLeft % summonDelay == 0)
            {
                Main.PlaySound(SoundID.Item28);
                Projectile.NewProjectile(new Vector2(projectile.position.X, projectile.position.Y), new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(14, 15)), mod.ProjectileType("AugmentedCocytusProjectile"), projectile.damage, projectile.knockBack, projectile.owner);
            }

        }
    }
}
