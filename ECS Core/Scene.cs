using Joie.Extensions;
using Joie.ECS.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Joie.ECS
{
    public class Scene
    {
        public List<Entity> Entities { get; set; } = new List<Entity>();
        public SceneCamera SceneCamera { get; set; } = new SceneCamera();

        //private Effect SceneEffect;

        public Scene()
        { }

        public virtual void SceneCanvas()
        {

        }

        public void InitializeScene(ContentManager content)
        {
            foreach (var entity in Entities)
            {
                entity.Components.InitializeComponents();
                entity.Components.LoadContentComponents(content);
            }
            //LoadContentScene(content);
        }
        public void LoadContentScene(ContentManager content)
        {
            foreach (var entity in Entities)
            {
                entity.Components.LoadContentComponents(content);
            }
        }
        public void UpdateScene(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                entity.Components.UpdateComponents(gameTime);
            }
        }
        public void DrawScene(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach (var entity in Entities)
            {
                entity.Components.DrawComponents(spriteBatch);
            }
            spriteBatch.End();
        }

        public void ChangeScene(Scene changeScene, ContentManager content)
        {
            Game1.CurrentScene = changeScene;
            changeScene.SceneCanvas();
            changeScene.InitializeScene(content);
            //changeScene.LoadContentScene(Content);
        }



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


        //-----------------
        // Entity Methods
        //-----------------

        //public bool HasEntity(uint entityID)
        //    => Entities.Contains(entityID);
        //public string GetEntityNameByID(uint entityID)
        //{
        //    if (EntityNameByID.ContainsKey(entityID))
        //        return EntityNameByID[entityID];
        //    return null;
        //}
        //public uint GetEntityIDByName(string name)
        //{
        //    return EntityNameByID.KeyByValue(name);
        //}
        //public uint AddEntity(string name)
        //{
        //    var entityID = IDGenerator.ID;
        //    Entities.Add(entityID);
        //    EntityNameByID.Add(entityID, name);
        //    return entityID;
        //}
        //public uint GetOrAddEntity(string name)
        //{
        //    uint? temp = GetEntityIDByName(name);
        //    temp ??= AddEntity(name);
        //    return temp.Value;
        //}
        //public void RemoveEntity(uint entityID)
        //{
        //    Entities.Remove(entityID);
        //    EntityNameByID.Remove(entityID);
        //    foreach (var component in Components)
        //        component.HandleEntityRemoval(entityID);
        //}
        /*public bool TryGetEntityNameByID(uint entityID, out string name)
        {
            name = GetEntityNameByID(entityID);
            return name != null;
        }
        public bool TryGetEntityIDByName(string name, uint? entityID)
        {
            entityID = GetEntityIDByName(name);
            return entityID != null;
        }*/



        //--------------------
        // Component Methods
        //--------------------

        // Has component
        //public bool SceneHasComponent<T>() where T : Component
        //    => SceneGetComponent<T>() != null;

        //// Get component
        //public T SceneGetComponent<T>() where T : Component
        //{
        //    foreach (var component in Components)
        //        if (component is T TComponent)
        //            return TComponent;
        //    return null;
        //}

        //// Add component
        //public T SceneAddComponent<T>(T component) where T : Component
        //{
        //    if (SceneHasComponent<T>())
        //        Components.Add(component);
        //    return component;
        //}
        //public T SceneAddComponent<T>() where T : Component, new()
        //    => SceneAddComponent(new T());

        //// Get or Add component
        //public T SceneGetOrAddComponent<T>(T component) where T : Component
        //    => SceneGetComponent<T>() ?? SceneAddComponent(component);
        //public T SceneGetOrAddComponent<T>() where T : Component, new()
        //    => SceneGetComponent<T>() ?? SceneAddComponent(new T());

        //// Remove component
        //public void SceneRemoveComponent<T>() where T : Component
        //    => Components.Remove(SceneGetComponent<T>());

        //// Try to Get component
        //public bool SceneTryGetComponent<T>(out T component) where T : Component
        //{
        //    component = SceneGetComponent<T>();
        //    return component != null;
        //}
    }
}
