using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChaosRings3Mod.UI
{
    class MutationBar : UIState
    {
        public static bool visible = true;
        private ChaosRings3Player player;
        private MutationIndicator muIndicator;
        private UIPanel muBar;
        private UIText text;
        private const int muIndicatorWidth = 400;
        private const int muIndicatorHeight = 10;
        public override void OnInitialize()
        {
            UIPanel parent = new UIPanel();
            parent.Height.Set(80, 0);
            parent.Width.Set(400, 0);
            parent.Top.Set(0, 0);
            parent.Left.Set(Main.screenWidth * 0.70f, 0);
            parent.BackgroundColor = new Color(0, 0, 0, 0);
            parent.BorderColor = new Color(0, 0, 0, 0);
            Append(parent);

            UIPanel muIndicatorContainer = new UIPanel();
            muIndicatorContainer.Height.Set(muIndicatorHeight * 2, 0);
            muIndicatorContainer.Width.Set(muIndicatorWidth, 0);
            muIndicatorContainer.Top.Set(25, 0);
            muIndicatorContainer.Left.Set(0, 0);
            parent.Append(muIndicatorContainer);

            muIndicator = new MutationIndicator();
            muIndicator.SetPadding(0);
            muIndicator.Left.Set(8, 0);
            muIndicator.Top.Set(30, 0);
            muIndicator.backgroundColor = Color.Yellow;
            muIndicator.Width.Set(muIndicatorWidth, 0);
            muIndicator.Height.Set(muIndicatorHeight, 0);
            parent.Append(muIndicator);
            
            text = new UIText("Mutation Progress:");
            parent.Append(text);
            text.Width.Set(muIndicatorWidth, 0);
            text.Height.Set(25, 0);
            text.Top.Set(0, 0);
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            ChaosRings3Player player = Main.LocalPlayer.GetModPlayer<ChaosRings3Player>();
            float quotient = player.mutationValue / player.mutationThres;
            muIndicator.Width.Set(quotient * (muIndicatorWidth - 30), 0f);
            Recalculate();
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            ChaosRings3Player player = Main.LocalPlayer.GetModPlayer<ChaosRings3Player>();
            float quotient = player.mutationValue / player.mutationThres;
            text.SetText("Mutation Progress " + Math.Round(quotient * 100) + "%");
            base.Update(gameTime);
        }
    }

    class MutationIndicator : UIElement
    {
        public Color backgroundColor = new Color(0, 0, 0, 0);
        private static Texture2D _backgroundTexture;

        public MutationIndicator()
        {
            if (_backgroundTexture == null)
                _backgroundTexture = ModContent.GetTexture("ChaosRings3Mod/Textures/UI/Blank");
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();
            Point p1 = new Point((int)dimensions.X, (int)dimensions.Y);
            int width = (int)Math.Ceiling(dimensions.Width);
            int height = (int)Math.Ceiling(dimensions.Height);
            spriteBatch.Draw(_backgroundTexture, new Rectangle(p1.X, p1.Y, width, height), backgroundColor);
        }
    }
}

