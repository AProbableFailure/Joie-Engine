using Joie.ECS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joie.Components
{
    public class Texture2DComponent : Component
    {
        public string TextureName { get; set; }

        public Texture2DComponent(string textureName)
        {
            TextureName = textureName;
        }
    }
}
