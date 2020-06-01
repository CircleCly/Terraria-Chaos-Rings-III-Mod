using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace ChaosRings3Mod.Projectiles
{
    class ManaProjectile : ModProjectile
    {
        float baseSpeed = 0;
        public ManaProjectile()
        {
            baseSpeed = Main.rand.NextFloat(0.7f, 1.4f);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mana");
        }

        public override void SetDefaults()
        {

            projectile.magic = true;
            projectile.width = 64;
            projectile.height = 28;
            projectile.timeLeft = 600;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
        }

        public override void AI()
        {
            
            if (projectile.velocity.X < 0)
            {
                projectile.rotation = (float)(Math.Atan(projectile.velocity.Y / projectile.velocity.X)) + MathHelper.Pi;
            } else
            {
                projectile.rotation = (float)(Math.Atan(projectile.velocity.Y / projectile.velocity.X));
            }
            
            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (!target.friendly && target.type != NPCID.TargetDummy)
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 480f && !target.friendly && target.active)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 3f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX * baseSpeed;
                        projectile.velocity.Y = shootToY * baseSpeed;
                        
                    }
                }
            }
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Gold, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
        }
    }
}
