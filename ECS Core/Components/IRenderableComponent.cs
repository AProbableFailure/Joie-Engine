using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public interface IRenderableComponent
    {
        void Component_Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);
    }
}
