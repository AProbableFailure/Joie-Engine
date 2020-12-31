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
    public class Game1 : Core
    {
        public Game1() : base(1280, 720)
        {

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            CurrentScene = new TestingScene();
            //CurrentScene.BuildScene();

            //CurrentScene.InitializeScene();

            base.Initialize();
        }
    }
}
