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
        public Dictionary<string, Texture2D> SceneTextures = new Dictionary<string, Texture2D>(); // name, Texture2D
        //public Dictionary<string, SoundEffect> SceneAudio = new Dictionary<string, SoundEffect>(); // name, SoundEffect

        public Effect SceneShader;
        public void System_Update(GameTime gameTime, Scene scene)
        {
            scene.SceneCamera.UpdateSceneCamera(gameTime);
            foreach (var component in RegisteredComponents)
            {
                if (component is AnimationComponent acomp)
                    acomp.Component_Update(gameTime);
            }
            //foreach (var entity in scene.Entities)
            //{
            //    foreach (var component in entity.Components)
            //    {
            //        if (component is AnimationComponent acomp)
            //        {
            //            acomp.Component_Update(gameTime);//, SceneTextures[acomp.CurrentAnimation.Texture.TextureName]);
            //        }
            //        //spriteBatch.Draw(SceneTextures[tcomp.TextureName], new Vector2(100, 100), Color.White);
            //    }
            //}
        }

        public void System_Render(SpriteBatch spriteBatch, Scene scene)
        {
            spriteBatch.Begin(transformMatrix: scene.SceneCamera.RawSceneCameraMatrix);

            //foreach (var entity in scene.Entities)
            //{
            //    foreach (var component in entity.Components)
            //    {
            //        if (component is Texture2DComponent tcomp)
            //            tcomp.Component_Draw(spriteBatch);//, SceneTextures[tcomp.TextureName]);
            //        else if (component is AnimationComponent acomp)
            //            acomp.Component_Draw(spriteBatch);//, SceneTextures[acomp.CurrentAnimation.Texture.TextureName]);
            //            //spriteBatch.Draw(SceneTextures[tcomp.TextureName], new Vector2(100, 100), Color.White);
            //    }
            //}
            foreach (var component in RegisteredComponents)
            {
                Console.WriteLine(RegisteredComponents.Count);
                if (component is Texture2DComponent tcomp)
                    tcomp.Component_Draw(spriteBatch);//, SceneTextures[tcomp.TextureName]);
                else if (component is AnimationComponent acomp)
                    acomp.Component_Draw(spriteBatch);//, SceneTextures[acomp.CurrentAnimation.Texture.TextureName]);
                                                      //spriteBatch.Draw(SceneTextures[tcomp.TextureName], new Vector2(100, 100), Color.White);
            }

            spriteBatch.End();
        }

        protected override void System_OnSceneChanged()
        {
            //Core._content.Unload();

            //System_UnloadContent();
            //System_LoadContent(Core.CurrentScene);
        }
    }
}
