using Microsoft.Xna.Framework;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateCoolAwesomeTrashGame.Interfaces;

namespace UltimateCoolAwesomeTrashGame.Commands
{
    class MoveCommand : IGameCommand
    {
        public Vector2 speed;
        public Vector2 acceleration;

        public MoveCommand()
        {
            this.speed = new Vector2(5, 5);
            acceleration = new Vector2(0.1f,0f);
        }

        public void Execute(ITransform transform, Vector2 direction)
        {
            direction *= speed;
            transform.Position += direction;
            DragHandler(transform,direction);
        }

        public void DragHandler(ITransform transform, Vector2 direction)
        {
            if (transform.Position.Y < 1)
            {
                speed = new Vector2(5, 5);
            }
            if (direction.Y >= 1 && speed.X < 10)
            {
                speed += acceleration;
            }
        }
    }
}
