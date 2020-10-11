using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
namespace ChaosRings3Mod.Skills
{
    class Odette : Skill
    {
        int baseDamage = 0;
        int baseKnockback = 0;
        public Odette()
        {
            requireMana = 4;
            baseDamage = 23;
            mutationFactor = 5;
            maxCooldownTime = 120;
        }
        public override void Activate(float atkModifier)
        {
            if (!ConsumeMana()) return;
            Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().attr = AttributeManager.Attribute.DARK;
            Main.PlaySound(SoundID.Item8);
            for (int i = 0; i < 1; i++)
            {
                Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(0, 0), ChaosRings3Mod.instance.ProjectileType("Odette"), (int) (baseDamage * Main.LocalPlayer.magicDamageMult), baseKnockback, Main.myPlayer);
            }
        }
    }
}
