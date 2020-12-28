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
        public EntityList Entities { get; set; }
        public SceneCamera SceneCamera { get; set; } = new SceneCamera();

        //private Effect SceneEffect;

        public Scene()
        {
            Entities = new EntityList(this);
        }

        public void ChangeScene(Scene changeScene)
        {
            Joie.Game1.CurrentScene = changeScene;
            changeScene.BuildScene();
            changeScene.InitializeScene();
            //changeScene.LoadContentScene(Content);
        }

        public virtual void BuildScene() // the canvas on which you build on
        {

        }

        public void InitializeScene()
        {
            Entities.InitializeEntities();
        }
        public void LoadContentScene(Microsoft.Xna.Framework.Content.ContentManager content)
        {
            //SceneEffect = content.Load<Effect>("TestShader");
            Entities.LoadContentEntities(content);
        }
        public void UpdateScene(Microsoft.Xna.Framework.GameTime gameTime)
        {
            SceneCamera.UpdateSceneCamera(gameTime);
            Entities.UpdateEntities(gameTime);
        }
        public void DrawScene(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.Immediate, blendState: BlendState.AlphaBlend, transformMatrix: SceneCamera.RawSceneCameraMatrix);//, effect: SceneEffect);
            //SceneEffect.CurrentTechnique.Passes[0].Apply();
            Entities.DrawEntities(spriteBatch);
            spriteBatch.End();
        }



        // PUT DRAW COMPONENTS HERE














        //public bool HasEntity<T>() where T : Entity => Entities.GetComponent<T>() != null;

        //public T GetComponent<T>() where T : Component => Components.GetComponent<T>();
        //public bool TryGetComponent<T>(out T component) where T : Component
        //{
        //    component = GetComponent<T>();
        //    return component != null;
        //}

        public Entity AddEntity(string name, Vector2 position = default)
        {
            var entity = new Entity(name, position);
            Entities.Add(entity);
            entity.OnAddEntity(this);
            return entity;
        }
        public Entity AddEntity<T>(T entity) where T : Entity
        {
            Entities.Add(entity);
            entity.OnAddEntity(this);
            return entity;
        }

        public void RemoveEntity(Entity entity) => Entities.Remove(entity);
    }
}
