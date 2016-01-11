using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using System;

namespace Triple
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TripleTriad : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ContentPackage assets;
        RenderManager renderer;
        Board playField;

        public TripleTriad()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 500;
            graphics.ApplyChanges();
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            MediaPlayer.Volume = 0.5f;
            assets = new ContentPackage(this.Content);
            playField = new Board();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            assets.LoadContent();
            spriteBatch = new SpriteBatch(GraphicsDevice);

            renderer = new RenderManager(assets, spriteBatch);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        KeyboardState oldKeyboardState;
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && oldKeyboardState.IsKeyUp(Keys.Space))
            {
                //playField.Shuffle();
                playField.DatTrain();
                foreach(int ID in playField.playedCards)
                {
                    Console.WriteLine(ID);
                }
                assets.Sfx.Play();
            }


            if (MediaPlayer.State != MediaState.Playing)
            {
                //MediaPlayer.Play(assets.Music);
            }

            //playField.Shuffle();

            oldKeyboardState = Keyboard.GetState();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            renderer.DrawBoard(playField);

            base.Draw(gameTime);
        }
    }
}
