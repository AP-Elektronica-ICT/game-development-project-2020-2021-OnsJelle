using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Text;
using UltimateCoolAwesomeTrashGame.Animations;
using UltimateCoolAwesomeTrashGame.Commands;
using UltimateCoolAwesomeTrashGame.Interfaces;
using UltimateCoolAwesomeTrashGame.Input;
using UltimateCoolAwesomeTrashGame.Animations.ColorChangeAnimation;

namespace UltimateCoolAwesomeTrashGame
{
    class Blob : ITransform
    {
        private Texture2D blobTexture;        
        //check for change
        private bool hasJumped = false;
        public Vector2 Position { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;

        private IInputReader inputReader;
        //private IInputReader mouseReader;

        private IGameCommand moveCommand;
        //private IGameCommand moveToCommand;

        IEntityAnimation blobBlue, currentAnimation;
        

        public Blob(Texture2D texture, IInputReader reader) 
        {
            blobTexture = texture;
            blobBlue = new BlopAnimation(texture, this); // Needs change Still-----------------------------
            currentAnimation = blobBlue;
            

            //Read Input
            this.inputReader = reader;

            moveCommand = new MoveCommand();

            Position = new Vector2(0, 0);

            _collisionRectangle = new Rectangle((int)Position.X, (int)Position.Y,64,64);
        }

        public void Update(GameTime gameTime){

            var direction = inputReader.ReadInput();

            HasJumped(direction);
            MoveHorizontal(direction);
            


            
            currentAnimation.Update(gameTime);

            _collisionRectangle.X = (int)Position.X;
            CollisionRectangle = _collisionRectangle;

        }

        private void MoveHorizontal(Vector2 _direction)
        {
            moveCommand.Execute(this, _direction);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch);
            
        }

        public void HasJumped(Vector2 direction)
        {
            if (direction.Y == 1)
            {
                hasJumped = !hasJumped;
                blobBlue.animHandler(hasJumped);
            }
        }
    }
}
