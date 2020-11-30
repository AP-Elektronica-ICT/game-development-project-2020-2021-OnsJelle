using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateCoolAwesomeTrashGame.World
{
    class WorldLevel
    {
        public Texture2D texture;


        public byte[,] tileArray = new Byte[,]
        {
            {0,0,0,0,0,0 ,0,0,0,0,0,0 },
            {0,0,0,0,0,0 ,0,0,0,0,0,0},
            {0,0,0,0,0,0 ,0,0,0,0,0,0},
            {0,0,0,0,0,0 ,0,0,0,0,0,0},
            {0,0,0,0,0,0 ,0,0,0,0,0,0},
            {1,1,1,1,1,1 ,1,1,1,1,1,1},
        };

        private Block[,] blokArray = new Block[8, 12];

        private ContentManager content;

        public WorldLevel(ContentManager content)
        {
            this.content = content;

            InitializeContent();
        }

        private void InitializeContent()
        {
            texture = content.Load<Texture2D>("block");
        }


        public void CreateWorld()
        {
            for (int x = 0; x < tileArray.GetLength(0); x++)
            {
                for (int y = 0; y < tileArray.GetLength(1); y++)
                {
                    if (tileArray[x, y] == 1)
                    {
                        blokArray[x, y] = new Block(texture, new Vector2(y * 70, x * 80));
                    }
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
