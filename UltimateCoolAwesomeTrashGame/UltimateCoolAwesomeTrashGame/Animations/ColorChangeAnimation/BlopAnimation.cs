using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateCoolAwesomeTrashGame.Animations.ColorChangeAnimation
{
    public class BlopAnimation : IEntityAnimation
    {
        private Animation _animation;        
        Texture2D texture;
        ITransform transform;

        public BlopAnimation(Texture2D texture, ITransform transform)
        {
            this.transform = transform;
            this.texture = texture;
            _animation = new Animation();           

            for (int i = 0; i < 5 * 128; i += 128)
            {
                _animation.AddFrame(new AnimationFrame(new Rectangle(i, 0, 128, 128)));
            }
            
            
        }

        public Animation Animation
        {
            get { return _animation; }
            set { _animation = value; }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, transform.Position, _animation.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 0.5f, SpriteEffects.None, 0);
        }

        public void Update(GameTime gameTime)
        {
            _animation.Update(gameTime);
        }

        public void animHandler(bool hasJumped)
        {
            _animation.clearFrame();
            if (hasJumped)
            {
                for (int i = 0; i < 5 * 128; i += 128)
                {
                    _animation.AddFrame(new AnimationFrame(new Rectangle(i, 128, 128, 128)));
                }
            }
            else
            {                
                for (int i = 0; i < 5 * 128; i += 128)
                {
                    _animation.AddFrame(new AnimationFrame(new Rectangle(i, 0, 128, 128)));
                }
            }
        }
    }
}
