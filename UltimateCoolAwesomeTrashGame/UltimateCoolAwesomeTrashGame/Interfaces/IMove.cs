using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateCoolAwesomeTrashGame.Interfaces
{
    public interface IMove
    {
        public bool HasJumped { get; set; }
        public bool OnGround { get; set; }
        public Vector2 Velocity { get; set; }
        Vector2 Position { get; set; }

    }
}
