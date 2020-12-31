using Joie.ECS;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Systems
{
    public class BuildSystem : ECSSystem
    {
        public void System_BuildScene(Scene scene)
        {
            scene.Scene_Canvas();
        }

        public void System_LoadContent(Scene scene)
        {

        }

        public void System_LoadContentPaths(Scene scene, ContentManager content, RenderSystem renderer) //AudioSystem, etc...
        {

        }


        protected override void System_OnSceneChanged()
        {
            
        }
    }
}
