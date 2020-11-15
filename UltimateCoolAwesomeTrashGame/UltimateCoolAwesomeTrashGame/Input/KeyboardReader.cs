using Microsoft.Xna.Framework;
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
            {
                if (direction.X != 0)
                {
                    direction.Y = -1;
                }else
                    direction = new Vector2(0, -1);
            }            
            if (state.IsKeyDown(Keys.Down))
            {
                if (direction.X != 0)
                {
                    direction.Y = 1;
                }else
                    direction = new Vector2(0, 1);
            }

            

            return direction;
        }
    }
}
