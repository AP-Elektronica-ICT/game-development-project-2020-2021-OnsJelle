using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateCoolAwesomeTrashGame.Animations;
using UltimateCoolAwesomeTrashGame.Interfaces;

namespace UltimateCoolAwesomeTrashGame.World
{
    abstract public class Platform : ICollision,ITransform
    {
        protected Texture2D blockTexture;
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }

        protected Animation _animation;
        public Animation Animation 
        {
            get { return _animation; }
            set { _animation = value; }
        }

        public Platform(Texture2D texture, Vector2 pos)
        {
            blockTexture = texture;
            Position = pos;
            CollisionRectangle = new Rectangle((int)Position.X - 14, (int)Position.Y - 14, 32, 5);
            _animation = new Animation();
            _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 64, 5)));

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(blockTexture, Position, _animation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
        }

        

        public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }
        
    }
}
