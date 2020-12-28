using Joie.Components.Property;
using Joie.ECS.Utilities;
using Joie.Extensions;
using Joie.Utilities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public class Entity
    {
        public const int frustumExtension = 100;
        public string Name { get; set; }
        public int ID { get; set; }
        public bool Enabled { get; set; } = true;
        public bool IsVisible
        {
            get
            {
                var rawSceneCameraMatrix = ParentScene.SceneCamera.RawSceneCameraMatrix;
                var topLeft = Position.WorldToScreen(rawSceneCameraMatrix);
                var topRight = (Position + new Vector2(EntitySize.X, 0)).WorldToScreen(rawSceneCameraMatrix);
                var bottomLeft = (Position + new Vector2(0, EntitySize.Y)).WorldToScreen(rawSceneCameraMatrix);
                var bottomRight = (Position + EntitySize).WorldToScreen(rawSceneCameraMatrix);
                var screenTopLeft = Vector2.Zero;
                var screenBottomRight = WindowManager.ViewportSize;

                return (topLeft.IsAround(frustumExtension, screenTopLeft, screenBottomRight)
                    && topRight.IsAround(frustumExtension, screenTopLeft, screenBottomRight)
                    && bottomLeft.IsAround(frustumExtension, screenTopLeft, screenBottomRight)
                    && bottomRight.IsAround(frustumExtension, screenTopLeft, screenBottomRight));
                //var entityScreenRect = new Rectangle(topLeftScreenPos.ToPoint(), (bottomRightScreenPos - topLeftScreenPos).ToPoint());
                //var windowRect = new Rectangle(-frustumExtension, -frustumExtension, (int)WindowManager.ViewportSize.X + frustumExtension, (int)WindowManager.ViewportSize.Y + frustumExtension);
                //return entityScreenRect.Intersects(windowRect);
            }
        }

        public bool FacingRight { get; set; } = true;
        public Scene ParentScene;

        public TransformPropertyComponent Transform { get; set; }
        public Vector2 Position { get => Transform.Position; set => Transform.Position = value; }
        public Vector2 EntitySize { get; set; } = Vector2.Zero;
        //public Vector2 CenterPosition { get => new Vector2(Transform.Position.X + EntitySize.X / 2, Transform.Position.Y + EntitySize.Y / 2); }

        //public List<Component> Components { get; set; } = new List<Component>();
        public ComponentList Components { get; set; }// = new ComponentList(entity: this);

        public Entity(string name, Vector2 position)
        {
            Name = name;
            //Transform = new Transform(position, Vector2.One);//Position = position;
            Components = new ComponentList(this);
        }

        public void InitializeEntity()
        {
            Components.InitializeComponents();
        }
        public void LoadContentEntity(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            Components.LoadContentComponents(content);
        }
        public void UpdateEntity(GameTime gameTime)
        {
            //Console.WriteLine(Components.Count);
            Components.UpdateComponents(gameTime);
        }
        public void DrawEntity(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            //if (Name == "background")
            //    Console.WriteLine("h");
            Components.DrawComponents(spriteBatch);
        }



        public void OnAddEntity(Scene parentScene)
        {
            ParentScene = parentScene;
        }

        //--------------------
        // Component Methods
        //--------------------
        public bool HasComponent<T>() where T : Component => Components.GetComponent<T>() != null;

        public T GetComponent<T>() where T : Component => Components.GetComponent<T>();
        public bool TryGetComponent<T>(out T component) where T : Component
        {
            component = GetComponent<T>();
            return component != null;
        }

        public T AddComponent<T>() where T : Component, new() => AddComponent(new T());
        public T AddComponent<T>(T component) where T : Component
        {
            Components.Add(component);
            return component;
        }

        public T GetOrAddComponent<T>() where T : Component, new() => Components.GetComponent<T>(true) ?? AddComponent<T>();

        public void RemoveComponent<T>(T component) where T : Component => Components.Remove(component);
        public void RemoveComponent<T>() where T : Component => RemoveComponent(GetComponent<T>());

        //public List<Component> AddComponentModule<T>() where T : ComponentModule, new() => AddComponentModule(new T());
        //public List<Component> AddComponentModule<T>(T module) where T : ComponentModule
        //{
        //    foreach (Component component in module.ModuleComponents)
        //        AddComponent(component);

        //    return module.ModuleComponents;
        //}
    }
}
