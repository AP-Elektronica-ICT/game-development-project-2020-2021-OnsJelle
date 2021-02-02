using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateCoolAwesomeTrashGame.Interfaces;

namespace UltimateCoolAwesomeTrashGame.Collision
{
    /// <summary>
    /// Ook van Sayan
    /// </summary>
    public class CollisionHelper : ICollisionHelper
    {
        public bool CollisionTopOf(Rectangle rect1, Rectangle rect2)
        {
            return (rect1.Bottom >= rect2.Top - 1 &&
                    rect1.Bottom <= rect2.Top + (rect2.Height / 2) &&
                    rect1.Right >= rect2.Left + (rect2.Width / 5) &&
                    rect1.Left <= rect2.Right - (rect2.Width / 5));
        }

        public bool CollisionBottomOf(Rectangle rect1, Rectangle rect2)
        {
            return (rect1.Top >= rect2.Bottom - 1 &&
                    rect1.Top <= rect2.Bottom + (rect2.Height / 5) &&
                    rect1.Right >= rect2.Left + (rect2.Width / 5) &&
                    rect1.Left <= rect2.Right - (rect2.Width / 5));
        }

        public bool CollisionLeftOf(Rectangle rect1, Rectangle rect2)
        {
            return (rect1.Right <= rect2.Right &&
                    rect1.Right >= rect2.Left - 5 &&
                    rect1.Top <= rect2.Bottom - (rect2.Width / 4) &&
                    rect1.Bottom >= rect2.Top + (rect2.Width / 4));
        }

        public bool CollisionRightOf(Rectangle rect1, Rectangle rect2)
        {
            return (rect1.Left >= rect2.Left &&
                    rect1.Left <= rect2.Right + 5
                    &&
                    rect1.Top <= rect2.Bottom - (rect2.Width / 4) &&
                    rect1.Bottom >= rect2.Top + (rect2.Width / 4)); 
        }
    }
}
