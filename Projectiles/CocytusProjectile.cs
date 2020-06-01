using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosRings3Mod.Projectiles
{
    class CocytusProjectile : ModProjectile
    {
        private int effectiveTime = 50;
        private int hitboxW = 60;
        private int hitboxH = 60;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cocytus");
        }

        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.width = hitboxW;
            projectile.height = hitboxH;
            projectile.scale = 2f;
            projectile.timeLeft = effectiveTime;
            projectile.penetrate = 100;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            drawOffsetX = hitboxW / 2;
            drawOriginOffsetY = hitboxH / 2;
        }

        public override void AI()
        {
            float gap = effectiveTime * 1 / 3;
            int thres1 = effectiveTime * 2 / 3;
            int thres2 = effectiveTime * 1 / 3;
            if (projectile.timeLeft >= thres1)
            {
                projectile.alpha = (int)((projectile.timeLeft - thres1) / gap * 255);
                projectile.scale = (effectiveTime - projectile.timeLeft) / gap * 2.0f;
            }
            else if (projectile.timeLeft > thres2 && projectile.timeLeft < thres1)
            {
                projectile.alpha = 0;
                projectile.scale = 2f;
            }
            else if (projectile.timeLeft <= thres2)
            {
                projectile.alpha = (int)((10 - projectile.timeLeft) / gap * 255);
                projectile.scale = (projectile.timeLeft) / gap * 2.0f;
            }
            if (Main.rand.NextBool(3))
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.Ice, Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5));
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Chilled, 5 * 60);
        }
    }
}
