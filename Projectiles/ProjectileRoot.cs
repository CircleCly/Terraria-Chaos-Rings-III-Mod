using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ChaosRings3Mod.Projectiles
{
    abstract class ProjectileRoot : ModProjectile
    {
        protected int summonTimes = 0;
        protected int summonDelay = 0;
        public override string Texture => "ChaosRings3Mod/Projectiles/ProjectileRoot";
        public override void SetDefaults()
        {
            projectile.width = 0;
            projectile.height = 0;
            projectile.timeLeft = summonTimes * summonDelay;
        }

        public override void AI()
        {
            
        }
    }
}
