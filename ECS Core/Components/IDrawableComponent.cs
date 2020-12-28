using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    interface IDrawableComponent
    {
        void DrawComponent(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);
    }
}
