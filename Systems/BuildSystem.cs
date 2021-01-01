using Joie.ECS;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Systems
{
    public class BuildSystem : ECSSystem
    {
        //public RenderSystem _renderer;
        //
        //public Dictionary<string, Texture2D> SceneTextures = new Dictionary<string, Texture2D>(); // name, Texture2D
        //public Dictionary<string, SoundEffect> SceneAudio = new Dictionary<string, SoundEffect>(); // name, SoundEffect
        //
        //public Effect SceneShader;
        //
        //public BuildSystem(RenderSystem renderer)
        //{
        //    _renderer = renderer;
        //}
        //public List<Component> RegisteredComponents = new List<Component>();

        private List<IBuildableComponent> RegisteredBuildableComponents = new List<IBuildableComponent>();

        public void System_BuildScene(Scene scene)
        {
            scene.Scene_ContentCanvas();
            System_LoadContent(scene);
            scene.Scene_Canvas();
            System_BuildComponents(scene);
        }

        public void System_BuildComponents(Scene scene)
        {
            //foreach (var initializable in RegisteredBuildableComponents)
            //{
            //    initializable.Component_Initialize();
            //}
            for (int i = 0; i < RegisteredBuildableComponents.Count; i++)
            {
                RegisteredBuildableComponents[i].Component_Initialize();
            }
        }

        public void System_LoadContent(Scene scene)
        {
            Core.Renderer.SceneTextures.Clear();
            //SceneAudio.Clear();
            Core.Renderer.SceneShader = null;

            System_LoadContentPaths(scene, Core._content);
        }

        public void System_LoadContentPaths(Scene scene, ContentManager content)//, RenderSystem renderer) //AudioSystem, etc...
        {
            if (scene.SceneShaderPath != null)
                Core.Renderer.SceneShader = content.Load<Effect>(scene.SceneShaderPath);


            // Loading all content from paths while organizing them to their respective dictionaries
            foreach (var kvp in scene.SceneContentPaths)
            {
                switch (kvp.Key.Item1)
                {
                    case ContentType.Texture2D:
                        Console.WriteLine("g");
                        Core.Renderer.SceneTextures.Add(kvp.Key.Item2, content.Load<Texture2D>(kvp.Value));
                        break;
                    case ContentType.SoundEffect:
                        //SceneAudio.Add(kvp.Key.Item2, content.Load<SoundEffect>(kvp.Value));
                        break;
                    default:
                        break;
                }
            }
        }

        public void System_UnloadContent()
        {
            Core._content.Unload();
        }

        protected override void System_OnSceneChanged()
        {
            System_UnloadContent();
            System_BuildScene(Core.CurrentScene);
        }

        public void RegisterBuildable(IBuildableComponent buildable)
            => RegisteredBuildableComponents.Add(buildable);
    }
}
