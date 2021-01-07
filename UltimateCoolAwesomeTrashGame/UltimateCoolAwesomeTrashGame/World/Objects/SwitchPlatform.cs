using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateCoolAwesomeTrashGame.Animations;

namespace UltimateCoolAwesomeTrashGame.World.Objects
{
    public class SwitchPlatform : Platform, IEntityAnimation
    {
        
        public SwitchPlatform(Texture2D texture, Vector2 pos) : base(texture, pos)
        {
                        
        }

        public void animHandler(bool hasJumped)
        {
            _animation.clearFrame();
            if (hasJumped && blockTexture.Name == "PlatformBlue")
            {
                _animation.AddFrame(new AnimationFrame(new Rectangle(0, 5, 64, 5)));
                CollisionRectangle = new Rectangle(0, 0, 0, 0);
            }
            else if (!hasJumped && blockTexture.Name == "PlatformRed")
            {
                _animation.AddFrame(new AnimationFrame(new Rectangle(0, 5, 64, 5)));
                CollisionRectangle = new Rectangle(0, 0, 0, 0);
            }
            else
            {
                _animation.AddFrame(new AnimationFrame(new Rectangle(0, 0, 64, 5)));
                CollisionRectangle = new Rectangle((int)Position.X - 14, (int)Position.Y - 14, 32, 5);
            }
        }
    }
}
