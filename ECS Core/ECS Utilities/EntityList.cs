using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS.Utilities
{
    public class EntityList
    {
        Scene _scene;

        List<Entity> _entities = new List<Entity>();
        List<Entity> _entitiesToDraw = new List<Entity>();

        private const float frustumExtension = 100; // axtra edge buffer for rendering

        internal List<Entity> _entitiesToAdd = new List<Entity>();
        List<Entity> _entitiesToRemove = new List<Entity>();

        public EntityList(Scene scene)
        {
            _scene = scene;
        }

        public int Count => _entities.Count;
        public Entity this[int index] => _entities[index];

        public void Add(Entity entity)
        {
            _entitiesToAdd.Add(entity);
        }
        public void Remove(Entity entity)
        {
            if (_entitiesToRemove.Contains(entity))
                return;

            if (_entitiesToAdd.Contains(entity))
            {
                _entitiesToAdd.Remove(entity);
                return;
            }

            _entitiesToRemove.Add(entity);
        }

        public void RemoveAllComponents()
        {
            //for (var i = 0; i < _components.Count; i++)
            //    HandleRemove(_components[i]);
            foreach (var entity in _entities) HandleRemove(entity);

            _entities.Clear();
            _entitiesToAdd.Clear();
            _entitiesToRemove.Clear();
        }

        void HandleRemove(Entity entity)
        {
            //component.OnRemovedFromEntity();
            entity.ParentScene = null;
        }

        //public T GetEntity<T>(bool onlyInitializedEntities = false) where T : Component 
        //{
        //    foreach (var entity in _entities)
        //        if (entity is T TEntity)
        //            return TEntity;

        //    if (!onlyInitializedEntities)
        //        foreach (var entity in _entities)
        //            if (entity is T TEntity)
        //                return TEntity;

        //    return null;
        //}

        void UpdateLists()
        {
            if (_entitiesToRemove.Count > 0)
            {
                foreach (var component in _entitiesToRemove)
                {
                    HandleRemove(component);
                    _entitiesToRemove.Remove(component);
                }
                _entitiesToRemove.Clear();
            }

            if (_entitiesToAdd.Count > 0)
            {
                foreach (var entity in _entitiesToAdd)
                {
                    _entities.Add(entity);
                    //_tempBufferList.Add(component);
                }

                _entitiesToAdd.Clear();
            }

            //var rawSceneCameraMatrix = _scene.SceneCamera.RawSceneCameraMatrix;//_scene.SceneCamera.
            //foreach (Entity entity in _entities)
            //{
            //    var screenPos = entity.Position.WorldToScreen(rawSceneCameraMatrix);
            //    var screenPosBottomRight = (entity.Position + entity.EntitySize).WorldToScreen(rawSceneCameraMatrix);
            //    if (screenPosBottomRight.X >= frustumExtension || screenPosBottomRight.Y >= frustumExtension
            //        || screenPos.X <= WindowManager.ViewportSize.X + frustumExtension || screenPos.Y <= WindowManager.ViewportSize.Y + frustumExtension)
            //    {
            //        _entitiesToDraw.Add(entity);
            //    }
            //    else
            //        _entitiesToDraw.Remove(entity);


            //    //if (entity.Position.)//WindowManager.ViewportSize
            //    //{

            //    //}
            //}
        }

        public void InitializeEntities()
        {
            UpdateLists();

            foreach (var entity in _entities)
                if (entity.Enabled)
                    entity.InitializeEntity();
        }

        public void LoadContentEntities(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            UpdateLists();

            foreach (var entity in _entities)
                if (entity.Enabled)
                    entity.LoadContentEntity(content);
        }

        public void UpdateEntities(Microsoft.Xna.Framework.GameTime gameTime)
        {
            UpdateLists();

            foreach (var entity in _entities)
                if (entity.Enabled)
                    entity.UpdateEntity(gameTime);
        }

        public void DrawEntities(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            foreach (var entity in _entities)
                if (entity.Enabled && entity.IsVisible)
                    entity.DrawEntity(spriteBatch);
        }
    }
}
