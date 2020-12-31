using Joie;
using Joie.ECS;
using Joie.Structures;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Joie.Systems
{
    public enum ContentType
    {
        Texture2D,
        SoundEffect
    }

    public class RenderSystem
    {
        //public DelayedList<Texture2D> SpaceTextures;
        public Dictionary<string, Texture2D> SceneTextures = new Dictionary<string, Texture2D>();
        public Dictionary<string, SoundEffect> SceneAudio = new Dictionary<string, SoundEffect>();
        
        //Joie.Core.SceneChanged +=
        public RenderSystem()
        {
            Core.SceneChanged += RendererOnSceneChanged;
        }

        public void System_LoadContent(Scene scene)
        {
            //SceneTextures.Clear();
            //SceneAudio.Clear();

            scene.SceneContentCanvas();//(Core._content);
            LoadContentPaths(scene, Core._content);

            //Console.WriteLine(SceneTextures.Count);
            //Console.WriteLine(scene.SceneName);
            //Console.WriteLine(SceneAudio.Count);
        }

        private void LoadContentPaths(Scene scene, ContentManager content)
        {
            //var sceneContentPaths = scene.SceneContentPaths;//.Where(kvp => kvp.Key.Item1)
            //var sceneTexturePaths = sceneContentPaths.Where(kvp => kvp.Key.Item1 == ContentType.Texture2D);
            //SceneTextures.Clear();
            //SceneAudio.Clear();
            
            foreach (var kvp in scene.SceneContentPaths)
            {
                switch (kvp.Key.Item1)
                {
                    case ContentType.Texture2D:
                        SceneTextures.Add(kvp.Key.Item2, content.Load<Texture2D>(kvp.Value));
                        break;
                    case ContentType.SoundEffect:
                        SceneAudio.Add(kvp.Key.Item2, content.Load<SoundEffect>(kvp.Value));
                        break;
                    default:
                        break;
                }
            }
        }

        public void System_UnloadContent()
        {
            //Console.WriteLine("unload");
            Core._content.Unload();
        }

        public void System_Render(SpriteBatch spriteBatch, Scene scene)
        {
            spriteBatch.Begin();
            spriteBatch.End();
        }

        private void RendererOnSceneChanged()//(object sender)//(object sender, EventArgs e)
        {
            //SceneTextures.Clear();
            //Console.WriteLine("ha");
            //System_LoadContent(scene);
            SceneTextures.Clear();
            SceneAudio.Clear();

            System_LoadContent(Core.CurrentScene);
        }

    }
}
