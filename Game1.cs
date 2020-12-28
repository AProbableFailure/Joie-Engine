using Joie.ECS;
using Joie.Input;
using Joie.Scenes;
using Joie.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Joie
{
    public class Game1 : Game
    {
        private ContentManager _content;
        public static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static Scene CurrentScene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _content = Content;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            WindowManager.ViewportSize = new Vector2(2560, 1440);

            CurrentScene = new TestingScene();
            CurrentScene.BuildScene();

            CurrentScene.InitializeScene();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            CurrentScene.LoadContentScene(_content);
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();

            InputManager.Update();

            if (InputManager.IsInput(InputManager.Down, Inputs.Exit))
                Exit();

            if (InputManager.IsInput(InputManager.Triggered, Inputs.Up))
                Console.WriteLine("Up");
            if (InputManager.IsInput(InputManager.Triggered, Inputs.Down))
                Console.WriteLine("Down");
            if (InputManager.IsInput(InputManager.Triggered, Inputs.Left))
                Console.WriteLine("Left");
            if (InputManager.IsInput(InputManager.Triggered, Inputs.Right))
                Console.WriteLine("Right");

            // TODO: Add your update logic here

            CurrentScene.UpdateScene(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            CurrentScene.DrawScene(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
