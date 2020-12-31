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
        private Vector2 _defaultViewportSize;// = new Vector2(2560, 1440);

        public static ContentManager _content;
        public static GraphicsDeviceManager _graphics;
        public static SpriteBatch _spriteBatch;

        public static Scene CurrentScene;

        public RenderSystem Renderer = new RenderSystem();

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //CurrentScene.LoadContentScene(_content);
            Renderer.System_LoadContent(CurrentScene);
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

            //CurrentScene.UpdateScene(gameTime);

            //if (InputManager.IsInput(InputManager.Triggered, Inputs.Fire1))
            //    ChangeScene
            if (InputManager.IsKey(InputManager.Triggered, Microsoft.Xna.Framework.Input.Keys.O))
                ChangeScene(new TestingScene());
            if (InputManager.IsKey(InputManager.Triggered, Microsoft.Xna.Framework.Input.Keys.P))
                ChangeScene(new TestingScene2());
            //OnSceneChanged();
            //Renderer.UnloadContentSystem();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //CurrentScene.DrawScene(_spriteBatch);

            base.Draw(gameTime);
        }

        //public delegate void OnSceneChangeHandler(object sender, EventArgs e);
        public delegate void SceneChangedHandler();
        public static event SceneChangedHandler SceneChanged;
        //public static event EventHandler<Scene> SceneChanged;

        protected virtual void OnSceneChanged()//EventArgs e)
        {
            //SceneChangedHandler handler = SceneChanged;
            SceneChanged?.Invoke();//(this, CurrentScene);//(this, e);
        }

        public void ChangeScene(Scene scene)
        {
            CurrentScene = scene;
            OnSceneChanged();
            //Initialize();
            //LoadContent();
        }
    }
}
