using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace UltimateCoolAwesomeTrashGame.World
{
    class FirstLevel : WorldLevel
    {

        public FirstLevel(ContentManager content) : base(content)
        {
            tileArray = new int[,] {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,4},
                {0,0,0,0,0,3,0,2,0,0,0,3,0,1,0,0,0,0,0,0,2},
                {0,0,0,2,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,3},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,2},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            };

            BlokArray = new ITransform[tileArray.GetLength(0), tileArray.GetLength(1)];
            
            InitializeContent();


            CreateWorld();
        }

        protected override void InitializeContent()
        {
            texture_block = content.Load<Texture2D>("block");
            texture_Pblue = content.Load<Texture2D>("PlatformBlue");            
            texture_Pred = content.Load<Texture2D>("PlatformRed");
            texture_Pgreen = content.Load<Texture2D>("PlatformGreen");
        }
        
    }

    class SecondLevel : WorldLevel
    {
        public SecondLevel(ContentManager tContent) : base(tContent)
        {
            tileArray = new int[,] {
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
                {0,0,0,0,0,0,3,0,0,0,0,3,0,1,0,0,2,0,0,0,2,0,3,0,0,0,4},
                {0,0,0,2,0,0,0,0,0,2,0,0,0,1,3,0,0,0,3,0,0,0,0,0,2,0,0},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}
            };

            BlokArray = new ITransform[tileArray.GetLength(0), tileArray.GetLength(1)];
            StartPosition = new Vector2(0, 200);
            
            InitializeContent();
            CreateWorld();
        }

        protected override void InitializeContent()
        {
            texture_block = content.Load<Texture2D>("block");
            texture_Pblue = content.Load<Texture2D>("PlatformBlue");
            texture_Pred = content.Load<Texture2D>("PlatformRed");
            texture_Pgreen = content.Load<Texture2D>("PlatformGreen");
        }
    }
}
