using Joie.Extensions;
using Joie.ECS.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Joie.Structures;
using Joie.Systems;

namespace Joie.ECS
{
    public abstract class Scene
    {
        public virtual string SceneName { get; set; }
        public List<Entity> Entities { get; set; } = new List<Entity>();
        public SceneCamera SceneCamera { get; set; } = new SceneCamera();

        //public Dictionary<string, Texture2D> SpaceTextures = new Dictionary<string, Texture2D>(); //name, texture
        public Dictionary<(ContentType, string), string> SceneContentPaths = new Dictionary<(ContentType, string), string>(); //name, path

        //private Effect SceneEffect;

        public Scene()
        { }

        public virtual void SceneCanvas()
        {
            // Add entities and whatnot here

            //LoadSceneContent(Core._content);
        }

        public virtual void SceneContentCanvas()//(ContentManager content)
        {

        }

        public void AddContent(ContentType contentType, string name, string filePath) //where T : Texture2D
        {
            //switch (contentType)
            //{
            //    case ContentType.Texture2D:
            //        SpaceContentPaths.Add((contentType, name), filePath);
            //        return;
            //    //case ContentTypes.SoundEffect:
            //    //SpaceTexturePaths.Add
            //    default:
            //        return;
            //}
            ////if (contentType == ContentTypes.Texture2D)
            ////    SpaceTexturePaths.Add(name, filePath);
            if (!SceneContentPaths.ContainsKey((contentType, name)))
                SceneContentPaths.Add((contentType, name), filePath);
        }






        //public void InitializeScene(ContentManager content)
        //{
        //    foreach (var entity in Entities)
        //    {
        //        entity.Components.InitializeComponents();
        //        entity.Components.LoadContentComponents(content);
        //    }
        //    //LoadContentScene(content);
        //}
        //public void LoadContentScene(ContentManager content)
        //{
        //    foreach (var entity in Entities)
        //    {
        //        entity.Components.LoadContentComponents(content);
        //    }
        //}
        //public void UpdateScene(GameTime gameTime)
        //{
        //    foreach (var entity in Entities)
        //    {
        //        entity.Components.UpdateComponents(gameTime);
        //    }
        //}
        //public void DrawScene(SpriteBatch spriteBatch)
        //{
        //    spriteBatch.Begin();
        //    foreach (var entity in Entities)
        //    {
        //        entity.Components.DrawComponents(spriteBatch);
        //    }
        //    spriteBatch.End();
        //}

        //public void ChangeScene(Scene changeScene, ContentManager content)
        //{
        //    Game1.CurrentScene = changeScene;
        //    changeScene.SceneCanvas();
        //    changeScene.InitializeScene(content);
        //    //changeScene.LoadContentScene(Content);
        //}



        //public Entity AddEntity(string name)
        //{
        //    var entity = new Entity();
        //    Entities.Add(entity);
        //    entity.OnAddEntity(name, this);
        //    return entity;
        //}
        //public Entity AddEntity<T>(string name, T entity) where T : Entity
        //{
        //    Entities.Add(entity);
        //    entity.OnAddEntity(name, this);
        //    return entity;
        //}
        //public void RemoveEntity(Entity entity) => Entities.Remove(entity);

    }
}
