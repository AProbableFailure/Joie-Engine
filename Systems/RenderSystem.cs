using Joie;
using Joie.Components;
using Joie.ECS;
using Joie.Structures;
using Microsoft.Xna.Framework;
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
        SoundEffect,
    }

    public class RenderSystem : ECSSystem
    {
        public List<IUpdatableComponent> RegisteredUpdatableComponents = new List<IUpdatableComponent>();
        public List<IRenderableComponent> RegisteredRenderableComponents = new List<IRenderableComponent>();

        public Dictionary<string, Texture2D> SceneTextures = new Dictionary<string, Texture2D>(); // name, Texture2D
        //public Dictionary<string, SoundEffect> SceneAudio = new Dictionary<string, SoundEffect>(); // name, SoundEffect

        public Effect SceneShader;

        public void System_Update(GameTime gameTime, Scene scene)
        {
            scene.SceneCamera.UpdateSceneCamera(gameTime);
            //foreach (var component in RegisteredUpdatableComponents)
            //    component.Component_Update(gameTime);
            for (int i = 0; i < RegisteredUpdatableComponents.Count; i++)
            {
                RegisteredUpdatableComponents[i].Component_Update(gameTime);
            }
        }

        public void System_Render(SpriteBatch spriteBatch, Scene scene)
        {
            spriteBatch.Begin(transformMatrix: scene.SceneCamera.RawSceneCameraMatrix);

            //foreach (var component in RegisteredRenderableComponents)//RegisteredComponents)
            //{
            //    //Console.WriteLine("Updatable    " + RegisteredUpdatableComponents.Count);
            //    //Console.WriteLine("Drawable    " + RegisteredDrawableComponents.Count);
            //    component.Component_Draw(spriteBatch);
            //}

            for (int i = 0; i < RegisteredRenderableComponents.Count; i++)
            {
                RegisteredRenderableComponents[i].Component_Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        protected override void System_OnSceneChanged()
        {
            //Core._content.Unload();

            //System_UnloadContent();
            //System_LoadContent(Core.CurrentScene);
        }

        public void RegisterUpdatable(IUpdatableComponent updatable)
            => RegisteredUpdatableComponents.Add(updatable);

        public void RegisterRenderable(IRenderableComponent renderable)
            => RegisteredRenderableComponents.Add(renderable);
    }
}
