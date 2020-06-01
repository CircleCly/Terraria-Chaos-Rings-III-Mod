using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
namespace ChaosRings3Mod
{
    public class AttributeManager
    {
        public enum Attribute
        {
            FIRE,
            ICE,
            EARTH,
            BOLT,
            LIGHT,
            DARK,
            NEUTRAL
        };
        public static float weakpointFactor = 1.25f;
        public static float strongpointFactor = 0.75f;
        public static Dictionary<int, Attribute> projAttributes, npcAttributes;
        public static List<int> fireProj, fireNpc;
        public static List<int> iceProj, iceNpc;
        public static List<int> earthProj, earthNpc;
        public static List<int> boltProj, boltNpc;
        public static List<int> lightProj, lightNpc;
        public static List<int> darkProj, darkNpc;
        public AttributeManager()
        {
            projAttributes = new Dictionary<int, Attribute>();
            for (int i = 1; i < ProjectileID.Count; i++)
            {
                projAttributes.Add(i, Attribute.NEUTRAL);
            }
            fireProj = new List<int>
            {
                2, 15, 19, 34, 35, 41, 82, 85, 95, 96, 125
            };
            iceProj = new List<int>
            {
                22, 26, 27, 80, 109, 113, 118, 119, 120, 123, 128,
                166, 172, 174, 177
            };
            earthProj = new List<int>
            {
                17, 31, 33, 39, 40, 42, 51, 55, 65, 67, 68, 71, 99,
                111, 112, 124, 127, 130, 131, 132, 150, 151, 152
            };
            boltProj = new List<int>
            {
                20, 36, 38, 122
            };
            lightProj = new List<int>
            {
                5, 6, 9, 12, 16, 69, 72, 76, 77, 78, 79, 84, 86, 87,
                89, 90, 91, 92, 93, 94, 105, 106, 116, 126, 129, 156,
                173
            };
            darkProj = new List<int>
            {
                4, 7, 8, 21, 25, 44, 45, 46, 56, 70, 83, 88, 100, 101,
                103, 104, 114, 115, 117, 121, 153, 154, 157
            };

            for (int i = 0; i < fireProj.Count; i++)
            {
              
                projAttributes[fireProj[i]] = Attribute.FIRE;
            }
            for (int i = 0; i < iceProj.Count; i++)
            {
                projAttributes[iceProj[i]] = Attribute.ICE;
            }
            for (int i = 0; i < earthProj.Count; i++)
            {
                projAttributes[earthProj[i]] = Attribute.EARTH;
            }
            for (int i = 0; i < boltProj.Count; i++)
            {
                projAttributes[boltProj[i]] = Attribute.BOLT;
            }
            for (int i = 0; i < lightProj.Count; i++)
            {
                projAttributes[lightProj[i]] = Attribute.LIGHT;
            }
            for (int i = 0; i < darkProj.Count; i++)
            {
                projAttributes[darkProj[i]] = Attribute.DARK;
            }
            
            projAttributes[ChaosRings3Mod.instance.ProjectileType("CremateProjectile")] = Attribute.FIRE;
            projAttributes[ChaosRings3Mod.instance.ProjectileType("CocytusProjectile")] = Attribute.ICE;
            projAttributes[ChaosRings3Mod.instance.ProjectileType("DogaProjectile")] = Attribute.EARTH;
            projAttributes[ChaosRings3Mod.instance.ProjectileType("ElectraProjectile")] = Attribute.BOLT;
            projAttributes[ChaosRings3Mod.instance.ProjectileType("ManaProjectile")] = Attribute.LIGHT;
            projAttributes[ChaosRings3Mod.instance.ProjectileType("OdetteProjectile")] = Attribute.DARK;
            projAttributes[ChaosRings3Mod.instance.ProjectileType("AugmentedCremationProjectile")] = Attribute.FIRE;
            npcAttributes = new Dictionary<int, Attribute>();
            for (int i = 1; i <= NPCID.Count; i++)
            {
                npcAttributes.Add(i, Attribute.NEUTRAL);
            }
            fireNpc = new List<int>
            {
                NPCID.Lavabat,
                NPCID.LavaSlime,
                
            };
            iceNpc = new List<int>
            {
                NPCID.IceBat,
                NPCID.IceElemental,
                NPCID.IceGolem,
                NPCID.IceQueen,
                NPCID.IceSlime,
                NPCID.IceTortoise,
                NPCID.SpikedIceSlime
            };
            earthNpc = new List<int>
            {

            };
            boltNpc = new List<int>
            {

            };
            lightNpc = new List<int>
            {

            };
            darkNpc = new List<int>
            {
                NPCID.EyeofCthulhu,
                NPCID.EaterofSouls,
                NPCID.EaterofWorldsBody,
                NPCID.EaterofWorldsHead,
                NPCID.EaterofWorldsTail
            };
            for (int i = 0; i < fireNpc.Count; i++)
            {
                npcAttributes[fireNpc[i]] = Attribute.FIRE;
            }
            for (int i = 0; i < iceNpc.Count; i++)
            {
                npcAttributes[iceNpc[i]] = Attribute.ICE;
            }
            for (int i = 0; i < earthNpc.Count; i++)
            {
                npcAttributes[earthNpc[i]] = Attribute.EARTH;
            }
            for (int i = 0; i < boltNpc.Count; i++)
            {
                npcAttributes[boltNpc[i]] = Attribute.BOLT;
            }
            for (int i = 0; i < lightNpc.Count; i++)
            {
                npcAttributes[lightNpc[i]] = Attribute.LIGHT;
            }
            for (int i = 0; i < darkNpc.Count; i++)
            {
                npcAttributes[darkNpc[i]] = Attribute.DARK;
            }
        }

        public static float GetDamageMultiplier(Attribute a1, Attribute a2)
        {
            if (a1 == a2)
            {
                return a1 == Attribute.NEUTRAL? 1.0f : strongpointFactor;
            } else
            {
                switch (a1)
                {
                    case Attribute.FIRE:
                        return a2 == Attribute.ICE ? weakpointFactor : 1.0f;
                    case Attribute.ICE:
                        return a2 == Attribute.FIRE ? weakpointFactor : 1.0f;
                        
                    case Attribute.EARTH:
                        return a2 == Attribute.BOLT ? weakpointFactor : 1.0f;
                        
                    case Attribute.BOLT:
                        return a2 == Attribute.EARTH ? weakpointFactor : 1.0f;
                        
                    case Attribute.LIGHT:
                        return a2 == Attribute.DARK ? weakpointFactor : 1.0f;
                        
                    case Attribute.DARK:
                        return a2 == Attribute.LIGHT ? weakpointFactor : 1.0f;
                    default:
                        return 1.0f;
                }
            }
        }
        
        
    }
}
