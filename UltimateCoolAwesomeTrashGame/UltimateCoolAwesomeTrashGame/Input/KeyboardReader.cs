﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateCoolAwesomeTrashGame.Input
{
    class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
                direction = new Vector2(-1, 0);
            if (state.IsKeyDown(Keys.Right))
                direction = new Vector2(1, 0);
            if (state.IsKeyDown(Keys.Up))
                direction = new Vector2(direction.X, -1);
            //if (state.IsKeyDown(Keys.Down))
            //    direction = new Vector2(direction.X, 1);

            return direction;
        }
    }
}
