using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public abstract class ECSSystem
    {
        public List<Component> RegisteredComponents = new List<Component>();
        public ECSSystem()
        {
            Core.SceneChanged += System_OnSceneChanged;
        }

        protected abstract void System_OnSceneChanged();

        public void Register(Component component)
            => RegisteredComponents.Add(component);
    }
}
