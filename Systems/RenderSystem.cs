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

        //public void System_LoadContent(Scene scene)
        //{
        //    scene.Scene_ContentCanvas();
        //    System_LoadContentPaths(scene, Core._content);
        //}

        //private void System_LoadContentPaths(Scene scene, ContentManager content)
        //{
        //    // Clear all asset 
        //    // TODO: MAKE IT SO THAT IT DOES NOT CLEAR ON SCENE CHANGE IF CONTENT ALREADY EXISTS IN A LIST
        //    SceneTextures.Clear();
        //    //SceneAudio.Clear();
        //    SceneShader = null;

        //    // Setting shader
        //    //if (scene.SceneShaderPath != null)
        //    //    SceneShader = content.Load<Effect>(scene.SceneShaderPath);
            

        //    //// Loading all content from paths while organizing them to their respective dictionaries
        //    //foreach (var kvp in scene.SceneContentPaths)
        //    //{
        //    //    switch (kvp.Key.Item1)
        //    //    {
        //    //        case ContentType.Texture2D:
        //    //            SceneTextures.Add(kvp.Key.Item2, content.Load<Texture2D>(kvp.Value));
        //    //            break;
        //    //        case ContentType.SoundEffect:
        //    //            SceneAudio.Add(kvp.Key.Item2, content.Load<SoundEffect>(kvp.Value));
        //    //            break;
        //    //        default:
        //    //            break;
        //    //    }
        //    //}
        //}

        //public void System_UnloadContent()
        //{
        //    Core._content.Unload();
        //}
        public void System_Update(GameTime gameTime, Scene scene)
        {
            foreach (var entity in scene.Entities)
            {
                foreach (var component in entity.Components)
                {
                    if (component is AnimationComponent acomp)
                    {
                        acomp.Component_Update(gameTime);//, SceneTextures[acomp.CurrentAnimation.Texture.TextureName]);
                    }
                    //spriteBatch.Draw(SceneTextures[tcomp.TextureName], new Vector2(100, 100), Color.White);
                }
            }
        }

        public void System_Render(SpriteBatch spriteBatch, Scene scene)
        {
            spriteBatch.Begin();

            foreach (var entity in scene.Entities)
            {
                foreach (var component in entity.Components)
                {
                    if (component is Texture2DComponent tcomp)
                    {
                        tcomp.Component_Draw(spriteBatch);//, SceneTextures[tcomp.TextureName]);
                        //var texture = SceneTextures[tcomp.TextureName];
                        //var textureSize = new Vector2(texture.Width, texture.Height);
                        //spriteBatch.Draw(texture//SceneTextures[tcomp.TextureName]
                        //                , new Vector2(100, 100)
                        //                , tcomp.Division == DivisionMethod.ByPixel
                        //                    ? tcomp.SourceRectangle
                        //                    : new Rectangle((textureSize * tcomp.SourceRectanglePosition).ToPoint(), (textureSize * tcomp.SourceRectangleSize).ToPoint())
                        //                , Color.White);
                    }
                    else if (component is AnimationComponent acomp)
                    {
                        acomp.Component_Draw(spriteBatch);//, SceneTextures[acomp.CurrentAnimation.Texture.TextureName]);
                    }
                        //spriteBatch.Draw(SceneTextures[tcomp.TextureName], new Vector2(100, 100), Color.White);
                }
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
