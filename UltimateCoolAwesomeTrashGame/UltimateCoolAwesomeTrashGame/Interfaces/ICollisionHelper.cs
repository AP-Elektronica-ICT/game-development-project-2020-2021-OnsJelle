using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace UltimateCoolAwesomeTrashGame.Interfaces
{
    public interface ICollisionHelper
    {
        public bool CollisionTopOf(Rectangle rect1, Rectangle rect2);
        public bool CollisionBottomOf(Rectangle rect1, Rectangle rect2);
        public bool CollisionLeftOf(Rectangle rect1, Rectangle rect2);
        public bool CollisionRightOf(Rectangle rect1, Rectangle rect2);
    }
}
