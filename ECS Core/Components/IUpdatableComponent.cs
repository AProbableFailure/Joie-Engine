using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    interface IUpdatableComponent
    {
        void UpdateComponent(Microsoft.Xna.Framework.GameTime gameTime);
    }
}
