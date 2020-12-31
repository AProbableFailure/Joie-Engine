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
        public string SceneName { get; set; }
        public List<Entity> Entities { get; set; } = new List<Entity>();
        public SceneCamera SceneCamera { get; set; } = new SceneCamera();

        public Dictionary<(ContentType, string), string> SceneContentPaths = new Dictionary<(ContentType, string), string>(); // (type, name), path
        public string SceneShaderPath { get; set; } = null;

        //public Scene()
        //{ }

        public abstract void Scene_Canvas();
        //{
        //    // Add entities and whatnot here
        //}

        public abstract void Scene_ContentCanvas();//(ContentManager content)
        

        public void AddContent(ContentType contentType, string name, string filePath)
        {
            if (!SceneContentPaths.ContainsKey((contentType, name)))
                SceneContentPaths.Add((contentType, name), filePath);
        }

        public void SetShader(string filepath) 
            => SceneShaderPath = filepath;

        public Entity AddEntity(string name)
        {
            var entity = new Entity();
            Entities.Add(entity);
            entity.OnAddEntity(name, this);
            return entity;
        }
        public Entity AddEntity<T>(string name, T entity) where T : Entity
        {
            Entities.Add(entity);
            entity.OnAddEntity(name, this);
            return entity;
        }
        public void RemoveEntity(Entity entity) => Entities.Remove(entity);



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
