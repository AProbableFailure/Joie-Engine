using Joie.ECS;
using Joie.Input;
using Joie.Scenes;
using Joie.Systems;
using Joie.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie
{
    public class Core : Game
    {
        private Vector2 _defaultViewportSize;

        public static ContentManager _content;
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;

        public static Scene CurrentScene;

        public static BuildSystem Builder;// = new BuildSystem();
        public static RenderSystem Renderer;// = new RenderSystem();

        public Core(int defaultViewportX = 2650, int defaultViewportY = 1440)
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _content = Content;

            _defaultViewportSize = new Vector2(defaultViewportX, defaultViewportY);
        }

        // ADD TO GAME1
        protected override void Initialize()
        {
            WindowManager.ViewportSize = _defaultViewportSize;

            Renderer = new RenderSystem();
            Builder = new BuildSystem();//BuildSystem(Renderer);

            //CurrentScene.Scene_Canvas();
            Builder.System_BuildScene(CurrentScene);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //Renderer.System_LoadContent(CurrentScene);
        }

        protected override void Update(GameTime gameTime)
        {
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

            if (InputManager.IsKey(InputManager.Triggered, Microsoft.Xna.Framework.Input.Keys.O))
                ChangeScene(new TestingScene());
            if (InputManager.IsKey(InputManager.Triggered, Microsoft.Xna.Framework.Input.Keys.P))
                ChangeScene(new TestingScene2());

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //CurrentScene.DrawScene(_spriteBatch);
            Renderer.System_Render(_spriteBatch, CurrentScene);

            base.Draw(gameTime);
        }

        public delegate void SceneChangedHandler();
        public static event SceneChangedHandler SceneChanged;

        protected virtual void OnSceneChanged()
            => SceneChanged?.Invoke();

        public void ChangeScene(Scene scene)
        {
            CurrentScene = scene;
            OnSceneChanged();
        }
    }
}
