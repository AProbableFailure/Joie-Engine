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
    // TODO : IMPLEMENT A SYSTEM REGISTER METHOD IN COMPONENTS (DONE
    // In constructor, call a register method that adds itself to a list in the static systems
    // TODO : Implement interfaces with methods like Component_Draw() so that I don't need to pattern match every loop
    // make the list in each system a list of I_______Component (i.e. IRenderableComponent) instead of a generic Component


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
            var r = AddEntity("3");
            r.AddComponent(new Texture2DComponent("floor", 0, 0, 1f, 1f, Utilities.DivisionMethod.Fractional));

            var player = AddEntity("player");
            //player.AddComponent(new Texture2DComponent("player", 0.25f, 0.25f, 0.5f, 0.5f));
            //player.AddComponent(new TransformComponent());
            //player.AddComponent(new MovementComponent());

            player.AddComponent(new ControllerComponent());

            var test = new Texture2DComponent("player", 0f, 0f, 1f, 1f, Utilities.DivisionMethod.Fractional, register: false);
            var animation = player.AddComponent(new AnimationComponent());

            Func<bool> o = () => !InputManager.IsInput(InputManager.Down, Inputs.Fire1);
            Func<bool> p = () => InputManager.IsInput(InputManager.Down, Inputs.Fire1);

            animation.AddAnimation(o, new Animation(test, 1/4f, 1/4f));
            animation.AddAnimation(p, new Animation(test, 1/4f, 1/4f, speed: 200f));

            

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
