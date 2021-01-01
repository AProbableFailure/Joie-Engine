using Joie.Components;
using Joie.ECS;
using Joie.Input;
using Joie.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Scenes
{
    // TODO : IMPLEMENT A SYSTEM REGISTER METHOD IN COMPONENTS
    // In constructor, call a register method that adds itself to a list in the static systems


    public class TestingScene : Scene
    {
        public TestingScene()
        {
            SceneName = "First Scene";
        }

        public override void Scene_ContentCanvas()
        {
            AddContent(ContentType.Texture2D, "player", "SmileyWalk");
            //AddContent(ContentType.Texture2D, "moon", "moon_PNG36");
            AddContent(ContentType.Texture2D, "floor", "Test_Floor");
        }

        public override void Scene_Canvas()
        {
            var player = AddEntity("player");
            //player.AddComponent(new Texture2DComponent("player", 0.25f, 0.25f, 0.5f, 0.5f));

            var test = new Texture2DComponent("player", 0, 0, 256, 256, Utilities.DivisionMethod.ByPixel, register: false);
            var animation = player.AddComponent(new AnimationComponent());

            Func<bool> p = () => InputManager.IsInput(InputManager.Down, Inputs.Fire1);
            Func<bool> o = () => !InputManager.IsInput(InputManager.Down, Inputs.Fire1);

            animation.AddAnimation(o, new Animation(test, 0.25f, 0.25f));
            animation.AddAnimation(p, new Animation(test, 0.25f, 0.25f, speed: 200f));

            //var a = AddEntity("a");
            //player.AddComponent(new Texture2DComponent("floor"));
            //var b = AddEntity("b");
            //player.AddComponent(new Texture2DComponent("moon"));
            //var c = AddEntity("c");
            //player.AddComponent(new Texture2DComponent("moon"));
            //var d = AddEntity("d");
            //player.AddComponent(new Texture2DComponent("moon"));
        }
    }
}
