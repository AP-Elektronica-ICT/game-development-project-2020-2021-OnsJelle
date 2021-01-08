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
using UltimateCoolAwesomeTrashGame.Collision;

namespace UltimateCoolAwesomeTrashGame
{
    public class Blob : ITransform, IMove
    {
        private Texture2D blobTexture;
        //check for change
        public bool HasJumped { get; set; }

        public bool hasJumped = false;
        public bool OnGround { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle CollisionRectangle { get; set; }
        private Rectangle _collisionRectangle;

        private IInputReader inputReader;
        //private IInputReader mouseReader;

        private IGameCommand moveCommand;
        //private IGameCommand moveToCommand;

        IEntityAnimation blobBlue, currentAnimation;

        public Blob(Texture2D texture, IInputReader reader, CollisionManager collisionManager) 
        {
            blobTexture = texture;
            blobBlue = new BlopAnimation(texture, this); // Needs change Still-----------------------------
            currentAnimation = blobBlue;

            //Read Input
            this.inputReader = reader;

            moveCommand = new MoveCommand();

            Position = new Vector2(0, 200);

            _collisionRectangle = new Rectangle((int)Position.X + 32, (int)Position.Y + 32,32,32);
        }

        public void Update(GameTime gameTime){
            var direction = inputReader.ReadInput();
           
            Move(direction);
            currentAnimation.animHandler(hasJumped);
            currentAnimation.Update(gameTime);

            _collisionRectangle.X = (int)Position.X;
            _collisionRectangle.Y = (int)Position.Y;
            CollisionRectangle = _collisionRectangle;
        }
               

        private void Move(Vector2 _direction)
        {
            //jumping movement
            if (_direction.Y == -1 && HasJumped == false)
            {                              
                Velocity = new Vector2(Velocity.X, -7f);
                HasJumped = true;
                hasJumped = !hasJumped;                
            }            


            Position += Velocity;

            if (!OnGround && Velocity.Y < 10)
            {
                Velocity += new Vector2(Velocity.X, 0.6f);              
            }
            
            
            moveCommand.Execute(this, _direction);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentAnimation.Draw(spriteBatch);
        }        
    }
}
