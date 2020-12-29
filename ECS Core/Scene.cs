using Joie.Extensions;
using Joie.ECS.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public class Scene
    {
        public List<uint> Entities { get; set; } = new List<uint>();
        public Dictionary<uint, string> EntityNameByID { get; set; } = new Dictionary<uint, string>();
        public List<Component> Components { get; set; } = new List<Component>();

        //private Effect SceneEffect;

        public Scene()
        { }

        //-----------------
        // Entity Methods
        //-----------------

        public bool HasEntity(uint entityID)
            => Entities.Contains(entityID);
        public string GetEntityNameByID(uint entityID)
        {
            if (EntityNameByID.ContainsKey(entityID))
                return EntityNameByID[entityID];
            return null;
        }
        public uint GetEntityIDByName(string name)
        {
            return EntityNameByID.KeyByValue(name);
        }
        public uint AddEntity(string name)
        {
            var entityID = IDGenerator.ID;
            Entities.Add(entityID);
            EntityNameByID.Add(entityID, name);
            return entityID;
        }
        public uint GetOrAddEntity(string name)
        {
            uint? temp = GetEntityIDByName(name);
            temp ??= AddEntity(name);
            return temp.Value;
        }
        public void RemoveEntity(uint entityID)
        {
            Entities.Remove(entityID);
            EntityNameByID.Remove(entityID);
            foreach (var component in Components)
                component.HandleEntityRemoval(entityID);
        }
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
        public bool SceneHasComponent<T>() where T : Component
            => SceneGetComponent<T>() != null;
        public bool EntityHasComponent<T>(uint entityID) where T : Component
            => EntityGetComponent<T>(entityID) != null;

        // Get component
        public T SceneGetComponent<T>() where T : Component
        {
            foreach (var component in Components)
                if (component is T TComponent)
                    return TComponent;
            return null;
        }
        public T EntityGetComponent<T>(uint entityID) where T : Component
        {
            var component = SceneGetComponent<T>();
            if (component.Entities.Contains(entityID))
                return component;
            return null;
        }

        // Add component
        public T SceneAddComponent<T>(T component) where T : Component
        {
            if (SceneHasComponent<T>())
                Components.Add(component);
            return component;
        }
        public T SceneAddComponent<T>() where T : Component, new()
            => SceneAddComponent(new T());
        public T EntityAddComponent<T>(uint entityID, T component) where T : Component
        {
            if (!SceneHasComponent<T>())
                SceneAddComponent(component);
            component.HandleEntityAddition(entityID);
            return component;
        }
        public T EntityAddComponent<T>(uint entityID) where T : Component, new()
            => EntityAddComponent(entityID, new T());

        // Get or Add component
        public T SceneGetOrAddComponent<T>(T component) where T : Component
            => SceneGetComponent<T>() ?? SceneAddComponent(component);
        public T SceneGetOrAddComponent<T>() where T : Component, new()
            => SceneGetComponent<T>() ?? SceneAddComponent(new T());
        public T EntityGetOrAddComponent<T>(uint entityID, T component) where T : Component
            => EntityGetComponent<T>(entityID) ?? EntityAddComponent(entityID, component);
        public T EntityGetOrAddComponent<T>(uint entityID) where T : Component, new()
            => EntityGetComponent<T>(entityID) ?? EntityAddComponent(entityID, new T());

        // Remove component
        public void SceneRemoveComponent<T>() where T : Component
            => Components.Remove(SceneGetComponent<T>());
        public void EntityRemoveComponent<T>(uint entityID) where T : Component
        {
            var component = SceneGetComponent<T>();
            if (component == null)
                return;
            component.HandleEntityRemoval(entityID);
        }

        // Try to Get component
        public bool SceneTryGetComponent<T>(out T component) where T : Component
        {
            component = SceneGetComponent<T>();
            return component != null;
        }
        public bool EntityTryGetComponent<T>(uint entityID, out T component) where T : Component
        {
            component = EntityGetComponent<T>(entityID);
            return component != null;
        }
    }
}
