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
    class CremateProjectile : ModProjectile
    {
        float baseSpeed = 0;
        public override string Texture => "Terraria/Projectile_467";
        public CremateProjectile()
        {
            baseSpeed = Main.rand.NextFloat(0.3f, 0.9f);
        }
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cremate");
            Main.projFrames[projectile.type] = Main.projFrames[467];
        }
        
        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.frame = 3;
            projectile.width = 40;
            projectile.height = 40;
            projectile.timeLeft = 600;
            projectile.penetrate = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = false;
        }

        
        public override void AI()
        {
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
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        { 
            target.AddBuff(BuffID.OnFire, 5 * 60);
        }
        
    }
}
