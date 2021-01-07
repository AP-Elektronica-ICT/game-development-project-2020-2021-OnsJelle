using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UltimateCoolAwesomeTrashGame.World;

namespace UltimateCoolAwesomeTrashGame.Camera
{
    public class Cam
    {
        private Matrix transform;
        public Matrix Transform
        {
            get { return transform; }
        }

        private Vector2 centre;
        private Viewport viewport;

        public Cam(Viewport newViewport)
        {
            viewport = newViewport;
        }

        public void Update(Vector2 position, int xOffcet, int yOffcet)
        {
            if (position.X < viewport.Width / 2)
                centre.X = viewport.Width / 2;
            else if (position.X > xOffcet - (viewport.Width / 2))
                centre.X = xOffcet - (viewport.Width / 2);
            else centre.X = position.X;

            /*if (position.Y < viewport.Height / 2)
                centre.Y = viewport.Height / 2;
            else if (position.Y > yOffcet - (viewport.Height / 2))
                centre.Y = yOffcet - (viewport.Height / 2);
            else centre.Y = position.Y;*/

            transform = Matrix.CreateTranslation(new Vector3(-centre.X + (viewport.Width / 2)
                                                             ,0, 0));
        }
    }
}

