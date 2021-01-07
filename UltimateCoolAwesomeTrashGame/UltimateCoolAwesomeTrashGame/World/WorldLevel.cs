using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateCoolAwesomeTrashGame.Interfaces;
using UltimateCoolAwesomeTrashGame;
using UltimateCoolAwesomeTrashGame.World.Objects;

namespace UltimateCoolAwesomeTrashGame.World
{
    public abstract class WorldLevel
    {
        public Texture2D texture_block, texture_Pblue, texture_Pwhite, texture_Pred, texture_Pgreen;
        private int width, height;
        public Vector2 StartPosition;
        private List<SwitchPlatform> platforms = new List<SwitchPlatform>();
        public List<SwitchPlatform> Platforms { get { return platforms; } }
        public EndPlatform endPlatform;
        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        protected int[,] tileArray;

        private ITransform[,] blokArray;

        public ITransform[,] BlokArray { get { return blokArray; } set { blokArray = value; } }

        protected ContentManager content;

        public WorldLevel(ContentManager content)
        {
            this.content = content;            
        }

        protected abstract void InitializeContent();

        //{
        //texture_block = content.Load<Texture2D>("block");
        //texture_Pblue = content.Load<Texture2D>("PlatformBlue");
        ////texture_Pwhite= content.Load<Texture2D>("PlatformWhite");
        //texture_Pred = content.Load<Texture2D>("PlatformRed");
        //texture_Pgreen = content.Load<Texture2D>("PlatformGreen");
        //}


        //Yet to make this SOLID somehow
        public void CreateWorld()
        {
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        blokArray[x, y] = new Block(texture_block, new Vector2(y * 64, x * 80));
                    }
                    if (tileArray[x,y] == 2)
                    {
                        SwitchPlatform p = new SwitchPlatform(texture_Pblue, new Vector2(y * 64, x * 80));
                        blokArray[x, y] = p;
                        platforms.Add(p);
                    }
                    if (tileArray[x, y] == 3)
                    {
                        SwitchPlatform p = new SwitchPlatform(texture_Pred, new Vector2(y * 64, x * 80));
                        blokArray[x, y] = p;
                        platforms.Add(p);
                    }
                    if (tileArray[x, y] == 4)
                    {
                        endPlatform = new EndPlatform(texture_Pgreen, new Vector2(y * 64, x * 80));
                        blokArray[x, y] = endPlatform;
                    }
                    width = (y + 1) * 64;
                    height = (x + 1) * 80;
                }
            }
        }

        public void DrawWorld(SpriteBatch spritebatch)
        {
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    if (blokArray[x, y] != null)
                    {
                        blokArray[x, y].Draw(spritebatch);
                    }
                }
            }
        }
    }
}
