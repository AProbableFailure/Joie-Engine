using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public interface IUpdatableComponent
    {
        void Component_Update(Microsoft.Xna.Framework.GameTime gameTime);
    }
}
