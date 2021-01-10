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
using UltimateCoolAwesomeTrashGame.MenuScreens;

namespace UltimateCoolAwesomeTrashGame
{
    /*Changes after 8Jan include*/

    //- End screen
        //Moving "You won" text to center
        //Making it so end screen doesn't contain the last level (replacing the Clear()=>see line 170)

    //- Resetting the playButton.isClicked boolean so the game doesn't instantly restart itself

    /*End of changes*/

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Boolean for intro
        bool StartGame = false;
        bool EndGame = false;
        //Buttons
        Button PlayBtn;
        Button QuitBtn;
        //Play again texture
        Texture2D ReplayText;
        Rectangle ReplayTextRec;
        //Camera
        private Cam camera;
        //Textures
        private Texture2D texture;
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

            //Intro Buttons
            PlayBtn = new Button();
            QuitBtn = new Button();

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

            //Buttons for the intro screen
            PlayBtn.Load(Content.Load<Texture2D>("PlayBtn"), new Vector2(275, 175));
            QuitBtn.Load(Content.Load<Texture2D>("QuitBtn"), new Vector2(275, 325));
            //You won text
            ReplayText = Content.Load<Texture2D>("PlayAgain");
            ReplayTextRec = new Rectangle(200, 0, ReplayText.Width, ReplayText.Height); /*Text Was off-center and bugging me*/
            //Camera to follow the player
            camera = new Cam(GraphicsDevice.Viewport);

            //PlayerTexture
            texture = Content.Load<Texture2D>("Blue&RedBlob");

            // TODO: use this.Content to load your game content here

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            blob = new Blob(texture, new KeyboardReader(), collisionManager);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (EndGame)
            {
                /*Reset the intro booleans*/
                StartGame = false;
                PlayBtn.isClicked = false;
                //Sets back to First level
                i = -1;
                hasWon = false;
            }
            if (!StartGame)
            {
                IntroScreen();
            }
            else
            {
                // TODO: Add your update logic here
                if (hasWon)
                {
                    //blob.reset();
                    i++;
                    if (i >= levels.Count)
                    {
                        //End of the whole game
                        EndGame = true;
                        StartGame = false;
                    }
                    if (!EndGame && levels[i] != null)
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
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); /*Replaced it so the end screen doesn't contain The last level*/
            _spriteBatch.Begin();
            if (!StartGame)
            {
                if (EndGame)
                {
                    _spriteBatch.Draw(ReplayText, ReplayTextRec, Color.White);
                }
                PlayBtn.Draw(_spriteBatch);
                QuitBtn.Draw(_spriteBatch);
            }
            _spriteBatch.End();
            // TODO: Add your drawing code here
            if (StartGame && !EndGame)
            {

                _spriteBatch.Begin(SpriteSortMode.Deferred,
                               BlendState.AlphaBlend,
                               null, null, null, null,
                               camera.Transform);

                blob.Draw(_spriteBatch);

                level.DrawWorld(_spriteBatch);
                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }

        void IntroScreen()
        {
            MouseState mouse = Mouse.GetState();

            if (PlayBtn.isClicked)
            {
                StartGame = true;
                EndGame = false;
            }
            if (QuitBtn.isClicked)
                Exit();

            PlayBtn.Update(mouse);
            QuitBtn.Update(mouse);

        }
    }
}
