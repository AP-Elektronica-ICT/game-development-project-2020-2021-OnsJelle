using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace UltimateCoolAwesomeTrashGame.Animations
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
        
    }
}
