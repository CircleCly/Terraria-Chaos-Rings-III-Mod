using System;
using System.Collections.Generic;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;
using ChaosRings3Mod.UI;
using Microsoft.Xna.Framework;
using ChaosRings3Mod.Items;
using ChaosRings3Mod.Skills;

namespace ChaosRings3Mod
{
    public class ChaosRings3Mod : Mod
    {
        public static AttributeManager am;
        public static ModHotKey skill1, skill2, skill3, skill4, skill5, skill6, skill7, skill8;
        public static SkillsList skillsList;
        internal bool showGene = false;
        internal UserInterface mutationInterface, geneInterface;
        internal MutationBar mutationBar;
        internal GeneUI geneUI;
        private GameTime _lastUpdateUiGameTime;
        public static ChaosRings3Mod instance;
        public ChaosRings3Mod()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadBackgrounds = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }

        public override void Load()
        {
            instance = this;
            skill1 = RegisterHotKey("Skill 1", "F2");
            skill2 = RegisterHotKey("Skill 2", "F3");
            skill3 = RegisterHotKey("Skill 3", "F4");
            skill4 = RegisterHotKey("Skill 4", "F5");
            skill5 = RegisterHotKey("Skill 5", "F6");
            skill6 = RegisterHotKey("Skill 6", "F7");
            skill7 = RegisterHotKey("Skill 7", "F8");
            skill8 = RegisterHotKey("Skill 8", "F9");
            skillsList = new SkillsList();
            if (!Main.dedServ)
            {
                mutationInterface = new UserInterface();
                geneInterface = new UserInterface();
                mutationBar = new MutationBar();
                mutationBar.Activate();
                mutationInterface.SetState(mutationBar);

                geneUI = new GeneUI();
                geneUI.Activate();
                
            }
            am = new AttributeManager();
        }

        
        public override void Unload()
        {
            am = null;
            mutationBar = null;
            geneUI = null;
            skillsList = null;
            skill1 = null;
            skill2 = null;
            skill3 = null;
            skill4 = null;
            skill5 = null;
            skill6 = null;
            skill7 = null;
            skill8 = null;
        }

        
        public override void UpdateUI(GameTime gameTime)
        {
            short ks = Main.GetKeyState(27);
            if (ks == 0 || ks == -128)
            {
                showGene = false;
            } else
            {
                showGene = true;
            }
            if (showGene)
            {
                geneInterface.SetState(geneUI);

            }
            else
            {
                geneInterface.SetState(null);
            }
            _lastUpdateUiGameTime = gameTime;
            mutationInterface?.Update(gameTime);
            geneInterface?.Update(gameTime);
            
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "Chaos Rings 3: Mutation Bar",
                    delegate
                    {
                        if (_lastUpdateUiGameTime != null && mutationInterface?.CurrentState != null)
                        {
                            mutationInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                       InterfaceScaleType.UI));
            }
            int inventoryIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Inventory"));
            if (inventoryIndex != -1)
            {
                layers.Insert(inventoryIndex, new LegacyGameInterfaceLayer(
                    "Chaos Rings 3: Gene Slot",
                    delegate {
                        // If the current UIState of the UserInterface is null, nothing will draw. We don't need to track a separate .visible value.
                        if (_lastUpdateUiGameTime != null && mutationInterface?.CurrentState != null)
                        {
                            geneInterface.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }

        }
    }
}
