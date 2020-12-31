using Joie.Components;
using Joie.ECS;
using Joie.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Scenes
{
    public class TestingScene : Scene
    {
        public TestingScene()
        {
            SceneName = "First Scene";
        }

        //public override void Scene_ContentCanvas()
        //{
        //    AddContent(ContentType.Texture2D, "player", "SmileyWalk");
        //    AddContent(ContentType.Texture2D, "moon", "moon_PNG36");
        //    AddContent(ContentType.Texture2D, "floor", "Test_Floor");
        //}

        public override void Scene_Canvas()
        {
            AddContent(ContentType.Texture2D, "player", "SmileyWalk");
            AddContent(ContentType.Texture2D, "moon", "moon_PNG36");
            AddContent(ContentType.Texture2D, "floor", "Test_Floor");

            var player = AddEntity("player");
            player.AddComponent(new Texture2DComponent("player", 0.25f, 0.25f, 0.5f, 0.5f));

            //var test = new Texture2DComponent("player");
            //var animation = player.AddComponent(new AnimationComponent());
            //animation.AddAnimation(() => true, new Animation(test, 0.25f, 0.25f));

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
