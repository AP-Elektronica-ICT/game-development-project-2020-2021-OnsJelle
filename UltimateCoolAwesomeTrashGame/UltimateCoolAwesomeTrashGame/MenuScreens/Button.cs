using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace UltimateCoolAwesomeTrashGame.MenuScreens
{
    public class Button
    {
        // Code bekomen dankzij Sayan
        

        private Color color = new Color(255, 255, 255, 255);
        private Texture2D buttonTexture;
        private Vector2 position;
        private Rectangle rectangle;

        public bool isClicked;

        public Button() { }

        public void Load(Texture2D newTexture, Vector2 newPosition)
        {
            buttonTexture = newTexture;
            position = newPosition;
        }

        public void Update(MouseState mouse)
        {
            mouse = Mouse.GetState();

            rectangle = new Rectangle((int)position.X, (int)position.Y, buttonTexture.Width, buttonTexture.Height);

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isClicked = true;                    
                }
            }            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(buttonTexture, rectangle, Color.White);
        }
    }
}

