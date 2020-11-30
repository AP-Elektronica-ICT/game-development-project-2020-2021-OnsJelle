using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.XAudio2;
using System.Diagnostics;
using UltimateCoolAwesomeTrashGame.Collision;
using UltimateCoolAwesomeTrashGame.Input;
using UltimateCoolAwesomeTrashGame.World;

namespace UltimateCoolAwesomeTrashGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //Textures
        private Texture2D texture, blockTexture;
        //Objects
        Blob blob;
        Block block;
        //collision
        CollisionManager collisionManager;
        //Level
        WorldLevel level;

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

            //Level
            level = new WorldLevel(Content);
            level.CreateWorld();

            //collision
            collisionManager = new CollisionManager();
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("Blue&RedBlob");
            blockTexture = Content.Load<Texture2D>("Block");
            // TODO: use this.Content to load your game content here

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            blob = new Blob(texture, new KeyboardReader());
            block = new Block(blockTexture, new Vector2(300, 50));
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            blob.Update(gameTime);
            block.Update();

          /*  if (collisionManager.CheckCollision(blob.CollisionRectangle, block.CollisionRectangle))
            {
                
                Debug.WriteLine(i++);
            }*/

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            block.Draw(_spriteBatch);
            blob.Draw(_spriteBatch);

            level.DrawWorld(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
