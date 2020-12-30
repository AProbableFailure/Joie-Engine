using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.ECS
{
    public abstract class ECSSystem
    {
        public Scene Scene { get; set; }
        public abstract void InitializeSystem();
        public abstract void LoadContentSystem(Microsoft.Xna.Framework.Content.ContentManager content);
        public abstract void UpdateSystem(Microsoft.Xna.Framework.GameTime gameTime);
        public abstract void DrawSystem(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch);
    }
}
