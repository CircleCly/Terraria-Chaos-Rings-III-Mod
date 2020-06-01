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
    class Cocytus : Skill
    {
        int baseDamage = 0;
        int baseKnockback = 0;
        public Cocytus()
        {
            requireMana = 4;
            baseDamage = 18;
            mutationFactor = 5;
        }
        public override void Activate(float atkModifier)
        {
            if (!ConsumeMana()) return;
            Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().attr = AttributeManager.Attribute.ICE;
            Main.PlaySound(SoundID.Item28);
            for (int i = 0; i < 1; i++)
            {
                Projectile.NewProjectile(new Vector2(Main.MouseWorld.X, Main.MouseWorld.Y), new Vector2(0, 0), ChaosRings3Mod.instance.ProjectileType("CocytusProjectile"), (int) (baseDamage * Main.LocalPlayer.magicDamageMult), baseKnockback, Main.myPlayer);
            }
        }
    }
}
