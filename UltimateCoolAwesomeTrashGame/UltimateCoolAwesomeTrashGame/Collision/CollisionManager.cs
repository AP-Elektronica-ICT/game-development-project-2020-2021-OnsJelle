using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace UltimateCoolAwesomeTrashGame.Collision
{
    public class CollisionManager
    {
        public bool CheckCollision(Rectangle rect1, Rectangle rect2)
        {
            if (rect1.Intersects(rect2))
                return true;

            return false;
        }
    }
}
