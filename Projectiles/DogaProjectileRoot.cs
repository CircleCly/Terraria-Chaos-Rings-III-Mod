using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace ChaosRings3Mod.Projectiles
{
    class DogaProjectileRoot : ProjectileRoot
    {

        public override void SetDefaults()
        {
            summonTimes = 3;
            summonDelay = 30;
            base.SetDefaults();
        }

        public override void AI()
        {
            if (projectile.timeLeft % summonDelay == 0)
            {
                Main.PlaySound(SoundID.Item11);
                Projectile.NewProjectile(projectile.position, new Vector2(0, 0), mod.ProjectileType("DogaProjectile"), projectile.damage, projectile.knockBack, projectile.owner);
            }
        }
    }
}
