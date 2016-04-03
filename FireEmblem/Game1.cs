
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

using FireEmblem.Engine;
using FireEmblem.Engine.GameStates;
using FireEmblem.Controller;

namespace FireEmblem
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {

        // Drawing variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Game Manager
        GameStateManager m_game_state_manager;

        // Scale
        private int m_scale = Constants.SCALE_DEFAULT;

        // Input
        private KeyboardState m_old_keyboard_state;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            
            base.Initialize();

            // Create game state manager and push initial state
            m_game_state_manager = new GameStateManager();
            m_game_state_manager.pushState(new GameStateMatch());

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {

            // Init texture manager
            TextureManager.init(GraphicsDevice, this.Content.Load<Texture2D>(Constants.FILE_TEXTURE_NULL));

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Store textures
            TextureManager.storeTexture( Constants.TEXTURE_MAP, this.Content.Load<Texture2D>(Constants.FILE_TEXTURE_MAP) );
            TextureManager.storeTexture( Constants.TEXTURE_SELECTOR, this.Content.Load<Texture2D>(Constants.FILE_TEXTURE_SELECTOR) );
            TextureManager.storeTexture(Constants.TEXTURE_SELECTOR_STATIC, this.Content.Load<Texture2D>(Constants.FILE_TEXTURE_SELECTOR_STATIC));

            // Create spritesheets
            TextureManager.createSpritesheet( Constants.SPRITESHEET_MAP, TextureManager.getTexture(Constants.TEXTURE_MAP), 
                Constants.NUMSPRITES_MAP, Constants.SIZE_X_TILE, Constants.SIZE_Y_TILE, Constants.OFFSET_X_TILE, Constants.OFFSET_Y_TILE );
            TextureManager.createSpritesheet( Constants.SPRITESHEET_SELECTOR, TextureManager.getTexture(Constants.TEXTURE_SELECTOR), 
                Constants.NUMSPRITES_SELECTOR, Constants.SIZE_X_SELECTOR, Constants.SIZE_Y_SELECTOR, Constants.OFFSET_X_SELECTOR, Constants.OFFSET_Y_SELECTOR );

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            this.Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update current game state
            KeyboardState current_keyboard_state = Keyboard.GetState();
            m_game_state_manager.Update(gameTime.ElapsedGameTime.Milliseconds, current_keyboard_state, m_old_keyboard_state);
            m_old_keyboard_state = current_keyboard_state;

            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Draw all pixely and stuff
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

                // Draw current game state
                m_game_state_manager.Draw(spriteBatch, m_scale);

            // Stop drawing all pixely and stuff
            spriteBatch.End();

            base.Draw(gameTime);

        }
    }
}
