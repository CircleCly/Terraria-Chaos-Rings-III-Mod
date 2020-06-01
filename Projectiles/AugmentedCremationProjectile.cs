using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;

namespace ChaosRings3Mod.Projectiles
{
    class AugmentedCremationProjectile : ModProjectile
    {
        
        public override string Texture => "Terraria/Projectile_" + ProjectileID.DD2BetsyFireball;
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Augmented Cremation");
            Main.projFrames[projectile.type] = Main.projFrames[ProjectileID.DD2BetsyFireball];
        }
        
        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.frame = 3;
            projectile.width = 30;
            projectile.height = 30;
            projectile.timeLeft = 600;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
            projectile.extraUpdates = 1;
        }

        
        public override void AI()
        {
            
            if (projectile.velocity.X < 0)
            {
                projectile.rotation = (float)(Math.Atan(projectile.velocity.Y / projectile.velocity.X)) - MathHelper.PiOver2;
            }
            else 
            {
                projectile.rotation = (float)(Math.Atan(projectile.velocity.Y / projectile.velocity.X)) + MathHelper.PiOver2;
            }
            
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        { 
            target.AddBuff(BuffID.OnFire, 5 * 60);
        }
        
    }
}
