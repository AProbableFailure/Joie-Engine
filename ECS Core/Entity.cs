﻿using Joie.ECS.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public class Entity
    {
        public Scene Scene { get; set; }
        public uint EntityID { get; set; }
        public string EntityName { get; set; }
        //public ComponentList Components { get; set; }
        public List<Component> Components { get; set; } = new List<Component>();

        public void OnAddEntity(string name, Scene scene)
        {
            EntityID = IDGenerator.GetNewID();
            EntityName = name;
            Scene = scene;
        }



        public bool HasComponent<T>() where T : Component
            => GetComponent<T>() != null;
        //public T GetComponent<T>() where T : Component
        //    => Components.GetComponent<T>();
        public T GetComponent<T>() where T : Component
        {
            foreach (var component in Components)
                if (component is T TComponent)
                    return TComponent;

            return null;
        }
        public T AddComponent<T>() where T : Component, new() => AddComponent(new T());
        public T AddComponent<T>(T component) where T : Component
        {
            Components.Add(component);
            component.OnAddComponent(this);
            return component;
        }
        //public T GetOrAddComponent<T>() where T : Component, new() 
        //    => Components.GetComponent<T>(true) ?? AddComponent<T>();
        public T GetOrAddComponent<T>() where T : Component, new()
            => GetComponent<T>() ?? AddComponent<T>();
        public T GetOrAddComponent<T>(T component) where T : Component
            => GetComponent<T>() ?? AddComponent<T>(component);
        public void RemoveComponent<T>(T component) where T : Component 
            => Components.Remove(component);
        public void RemoveComponent<T>() where T : Component 
            => RemoveComponent(GetComponent<T>());
    }
}
