using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace ChaosRings3Mod.Skills
{
    class Cremate : Skill
    {
        int baseDamage = 0;
        int baseKnockback = 0;
        public Cremate()
        {
            requireMana = 4;
            baseDamage = 30;
            mutationFactor = 5;
            maxCooldownTime = 120;
        }
        public override void Activate(float atkModifier)
        {

            if (!ConsumeMana()) return;
            Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().attr = AttributeManager.Attribute.FIRE;
            Main.PlaySound(SoundID.Item34);
            for (int i = 0; i < 3; i++)
            {
                Vector2 v = new Vector2();
                if (Main.LocalPlayer.direction == 1)
                {
                    v = Main.rand.NextVector2Square(4, 12);
                }
                else
                {
                    v = Main.rand.NextVector2Square(-4, -12);
                }
                Projectile.NewProjectile(Main.LocalPlayer.position, v, ChaosRings3Mod.instance.ProjectileType("CremateProjectile"), (int) (baseDamage * Main.LocalPlayer.magicDamageMult), baseKnockback, Main.myPlayer);
            }
        }
    }
}
