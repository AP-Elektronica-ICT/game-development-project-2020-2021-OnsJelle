using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateCoolAwesomeTrashGame.Interfaces;

namespace UltimateCoolAwesomeTrashGame.World
{
    class Block : ICollision, ITransform
    {
        private Texture2D blockTexture;
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        
        public Block(Texture2D texture, Vector2 pos)
        {
            blockTexture = texture;
            Position = pos;
            CollisionRectangle = new Rectangle((int)Position.X -14, (int)Position.Y - 14, 64, 80);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockTexture, Position, Color.AliceBlue);
        }

        public void Update()
        {

        }
    }
}
