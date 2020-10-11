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
    class Mana : Skill
    {
        int baseDamage = 0;
        int baseKnockback = 0;
        public Mana()
        {
            requireMana = 4;
            baseDamage = 18;
            mutationFactor = 5;
            maxCooldownTime = 120;
        }
        public override void Activate(float atkModifier)
        {
            if (!ConsumeMana()) return;
            Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().attr = AttributeManager.Attribute.LIGHT;
            Main.PlaySound(SoundID.Pixie);
            for (int i = 0; i < 1; i++)
            {
                Projectile.NewProjectile(Main.LocalPlayer.position, Main.LocalPlayer.velocity, ChaosRings3Mod.instance.ProjectileType("ManaProjectileRoot"), (int) (baseDamage * Main.LocalPlayer.magicDamageMult), baseKnockback, Main.myPlayer);
            }
        }
    }
}
