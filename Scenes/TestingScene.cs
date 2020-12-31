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

        public override void Scene_ContentCanvas()
        {
            AddContent(ContentType.Texture2D, "player", "SmileyWalk");
            AddContent(ContentType.Texture2D, "moon", "moon_PNG36");
            AddContent(ContentType.Texture2D, "floor", "Test_Floor");
        }

        public override void Scene_Canvas()
        {
            var player = AddEntity("player");
            player.AddComponent(new Texture2DComponent("player"));
        }
    }
}
