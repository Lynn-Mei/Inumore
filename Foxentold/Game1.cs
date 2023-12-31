﻿using Foxentold.Links;
using Foxentold.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Foxentold
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Settings _settings;
        private Scene _scene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 920;
            Content.RootDirectory = "Content";
            Window.Title = ("Inumore");
            StaticContentManager.Initialize(Content);
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this._settings = new Settings(Enums.LanguageCode.EN);
            SceneFactory.CreateTitleScreen(0, 0);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteFont spriteFont = Content.Load<SpriteFont>("Default");
            SpriteBatchManager.Initialize(new SpriteBatch(GraphicsDevice), spriteFont);
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardInputReceiver.currentKeyboardState = Keyboard.GetState();
            // TODO: Add your update logic here
            SceneFactory.Scene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatchManager.Begin();

            SceneFactory.Scene.Draw(gameTime);

            SpriteBatchManager.End();
            
            base.Draw(gameTime);
        }
    }
}