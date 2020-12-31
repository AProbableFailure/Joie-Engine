using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public abstract class ECSSystem
    {
        public ECSSystem()
        {
            Core.SceneChanged += System_OnSceneChanged;
        }

        protected abstract void System_OnSceneChanged();
    }
}
