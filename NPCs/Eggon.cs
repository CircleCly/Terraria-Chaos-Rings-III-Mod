using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChaosRings3Mod.NPCs
{
    public class Eggon : ModNPC
    {
        private int frameID = 0;
        private const int maxFrameTimer = 10;
        private const int frameCnt = 9;
        private int frameTimer = 10;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eggon");
            Main.npcFrameCount[npc.type] = 9;
        }

        public override void SetDefaults()
        {
            npc.width = 94;
            npc.height = 94;
            npc.damage = 26;
            npc.defense = 9999;
            npc.lifeMax = 30;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath6;
            npc.value = Item.buyPrice(0, 0, 80, 0);
            npc.knockBackResist = 1.4f;
            npc.aiStyle = 25;
            for (int i = 0; i < npc.buffImmune.Length; i++)
            {
                npc.buffImmune[i] = true;
            }
            aiType = NPCID.Mimic;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDay.Chance * 0.3f;
        }
        
        public override void AI()
        {
            
            
        }
        public override void NPCLoot()
        {
            Main.LocalPlayer.GetModPlayer<ChaosRings3Player>().equippedGene.gainExp(1500);
        }
        public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            crit = false;
        }

        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            crit = false;
        }
        public override void FindFrame(int frameHeight)
        {
            frameTimer--;
            if (frameTimer == 0)
            {
                frameTimer = maxFrameTimer;
                frameID++;
                if (frameID == frameCnt)
                {
                    frameID = 0;
                }
            }
            npc.frame.Y = frameID * frameHeight;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++)
            { 
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, 6);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }
        }
    }
}
