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
    class ManaProjectileRoot : ProjectileRoot
    {
        public override void SetDefaults()
        {
            summonTimes = 5;
            summonDelay = 18;
            base.SetDefaults();
        }

        public override void AI()
        {
            
            projectile.velocity = Main.LocalPlayer.velocity;
            if (projectile.timeLeft % summonDelay == 0)
            {
                Main.PlaySound(SoundID.Pixie);
                Projectile.NewProjectile(new Vector2(projectile.position.X - 32, projectile.position.Y - 14), Main.rand.NextVector2Circular(10f, 15f), mod.ProjectileType("ManaProjectile"), projectile.damage, projectile.knockBack, projectile.owner);
            }
        }
    }
}
