using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.XAudio2;
using System.Collections.Generic;
using System.Diagnostics;
using UltimateCoolAwesomeTrashGame.Camera;
using UltimateCoolAwesomeTrashGame.Collision;
using UltimateCoolAwesomeTrashGame.Input;
using UltimateCoolAwesomeTrashGame.World;
using UltimateCoolAwesomeTrashGame.World.Objects;

namespace UltimateCoolAwesomeTrashGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Cam camera;
        //Textures
        private Texture2D texture, blockTexture;
        //Objects
        Blob blob;
        //collision
        CollisionManager collisionManager;

        //Level list
        List<WorldLevel> levels = new List<WorldLevel>();
        int i = 0; //level counter
        //Level
        WorldLevel level;
        bool hasWon = false;

        //int i = 0;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //Add all levels
            levels.Add(new FirstLevel(Content));
            levels.Add(new SecondLevel(Content));
            //Begin Level
            level = levels[i];

            //collision
            collisionManager = new CollisionManager(new CollisionHelper());

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            camera = new Cam(GraphicsDevice.Viewport);

            texture = Content.Load<Texture2D>("Blue&RedBlob");
            blockTexture = Content.Load<Texture2D>("Block");
            // TODO: use this.Content to load your game content here

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            blob = new Blob(texture, new KeyboardReader(), collisionManager);
            //block = new Block(blockTexture, new Vector2(300, 50));
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (hasWon)
            {
                //blob.reset();
                i++;
                if (i > levels.Count)
                {
                    //End of the whole game
                }
                else
                {
                    level = levels[i];
                    hasWon = false;
                    blob.Position = level.StartPosition;
                }
            }

            blob.Update(gameTime);

            foreach (var item in level.BlokArray)
            {
                if (item != null)
                {
                    collisionManager.ExecuteCollision(blob.CollisionRectangle, item.CollisionRectangle, level.Width, level.Height, blob);
                }

                //collisionManager.CheckCollision(blob.CollisionRectangle, tile.Rectangle, lv1.Width, lv1.Height);
                //collisionManager.CheckUpdate(blob.HasJumped, blob.Velocity, blob.Position);
                //blob.Collision(blob.CollisionRectangle, tile.Rectangle, lv1.Width, lv1.Height);
                //blob.CheckCollision(blob.CollisionRectangle, tile.Rectangle, lv1.Width, lv1.Height);

            }
            camera.Update(blob.Position, level.Width, level.Height);

            foreach (var platform in level.Platforms)
            {
                platform.animHandler(blob.hasJumped);
            }


            //Game over check
            hasWon = collisionManager.CheckEndCollision(blob.CollisionRectangle, level.endPlatform.CollisionRectangle);



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin(SpriteSortMode.Deferred,
                               BlendState.AlphaBlend,
                               null, null, null, null,
                               camera.Transform);

            //block.Draw(_spriteBatch);
            blob.Draw(_spriteBatch);

            level.DrawWorld(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
