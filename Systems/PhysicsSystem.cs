using Joie.ECS;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Systems
{
    public class PhysicsSystem : ECSSystem
    {
        private List<IUpdatableComponent> RegisteredUpdatableComponents = new List<IUpdatableComponent>();

        public void System_Update(GameTime gameTime, Scene scene)
        {
            scene.SceneCamera.UpdateSceneCamera(gameTime);

            //foreach (var component in RegisteredUpdatableComponents)
            //    component.Component_Update(gameTime);

            for (int i = 0; i < RegisteredUpdatableComponents.Count; i++)
            {
                RegisteredUpdatableComponents[i].Component_Update(gameTime);
            }

            //Console.WriteLine(RegisteredUpdatableComponents.Count);
        }


        protected override void System_OnSceneChanged()
        {
            //throw new NotImplementedException();
        }

        public void RegisterUpdatable(IUpdatableComponent updatable)
            => RegisteredUpdatableComponents.Add(updatable);
    }
}
