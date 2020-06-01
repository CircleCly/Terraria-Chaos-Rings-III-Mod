using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
namespace ChaosRings3Mod.Projectiles
{
    class ElectraProjectileRoot : ProjectileRoot
    {
        public override void SetDefaults()
        {
            summonTimes = 4;
            summonDelay = 20;
            base.SetDefaults();
        }

        public override void AI()
        {
            if (projectile.timeLeft % summonDelay == 0)
            {
                Main.PlaySound(SoundID.Item12);
                Projectile.NewProjectile(new Vector2(projectile.position.X - 9, projectile.position.Y - 123), new Vector2(0, 0), mod.ProjectileType("ElectraProjectile"), projectile.damage, projectile.knockBack, projectile.owner);
            }
        }
    }
}
